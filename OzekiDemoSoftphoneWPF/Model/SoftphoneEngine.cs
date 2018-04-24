using System;
using System.Collections.Generic;
using System.Linq;
using Ozeki.VoIP;
using OzekiDemoSoftphoneWPF.Model.Data;
using TestSoftphone;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Windows;
using Ozeki.Media;
using Ozeki.Network;
using Ozeki.Common;
using System.Collections.Concurrent;


namespace OzekiDemoSoftphoneWPF.Model
{
    public class SoftphoneEngine : IDisposable, INotifyPropertyChanged, ILogger
    {
        #region Fields, Properties

        object _sync;

        private IPhoneCall selectedCall;
        private IPhoneLine selectedLine;

        /// <summary>
        /// The basic softphone interface of the VoIP SIP SDK.
        /// </summary>
        private ISoftPhone softPhone;

        /// <summary>
        /// Gets the collection of the available local IP addresses.
        /// </summary>
        public List<IPAddress> LocalIPAddressList
        {
            get { return SoftPhoneFactory.GetAddressList(); }
        }

        /// <summary>
        /// Gets or sets the minimum port number for network communication. (requires restart)
        /// </summary>
        public int MinPort { get; set; }

        /// <summary>
        /// Gets or sets the minimum port number for network communication. (requires restart)
        /// </summary>
        public int MaxPort { get; set; }

        /// <summary>
        /// Gets or sets the local IP of the softphone.
        /// </summary>
        public IPAddress LocalIP { get; set; }

        /// <summary>
        /// Gets the list of the available phone lines.
        /// </summary>
        public ObservableList<IPhoneLine> PhoneLines { get; private set; }

        public ObservableList<LogEntry> LogEntries { get; set; }

        private ConcurrentDictionary<IPhoneLine, ISIPSubscription> _subs { get; set; }

        /// <summary>
        /// Gets or sets the currently selected phone line.
        /// </summary>
        public IPhoneLine SelectedLine
        {
            get { return selectedLine; }
            set
            {
                selectedLine = value;
                OnPropertyChanged("SelectedLine");
            }
        }

        /// <summary>
        /// Gets the list of the active phone calls.
        /// </summary>
        public ObservableList<IPhoneCall> PhoneCalls { get; private set; }

        /// <summary>
        /// Gets or sets the currently selected phone call.
        /// </summary>
        public IPhoneCall SelectedCall
        {
            get { return selectedCall; }
            set
            {
                selectedCall = value;
                MediaHandlers.DetachAudio();
                MediaHandlers.DetachVideo();

                if (selectedCall != null && selectedCall.CallState.IsRemoteMediaCommunication())
                {
                    MediaHandlers.AttachAudio(selectedCall);
                    MediaHandlers.AttachVideo(selectedCall);
                }

                OnPropertyChanged("SelectedCall");
            }
        }

        /// <summary>
        /// Gets the list of the previous phone calls.
        /// </summary>
        public CallHistory CallHistory { get; private set; }

        /// <summary>
        /// Gets a collection of call types.
        /// </summary>
        public List<CallType> CallTypes { get; private set; }

        /// <summary>
        /// Gets the media system (microhone, speaker etc.)
        /// </summary>
        public MediaHandlers MediaHandlers { get; private set; }

        /// <summary>
        /// Gets the collection of the sent and received instant messages.
        /// </summary>
        public ObservableList<string> InstantMessages { get; set; }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the state of a phone line has changed.
        /// </summary>
        public event EventHandler<GEventArgs<IPhoneLine>> PhoneLineStateChanged;

        /// <summary>
        /// Occurs when an incoming call received.
        /// </summary>
        public event EventHandler<GEventArgs<IPhoneCall>> IncomingCall;

        /// <summary>
        /// Occurs when the state of a phone line has changed.
        /// </summary>
        public event EventHandler<GEventArgs<IPhoneCall>> PhoneCallStateChanged;

        /// <summary>
        /// Occurs when an instant message received through a phone call.
        /// </summary>
        public event EventHandler<PhoneCallInstantMessageArgs> CallInstantMessageReceived;

        /// <summary>
        /// Occurs when a message summary indication received in a phone line.
        /// </summary>
        public event EventHandler<MessageSummaryArgs> MessageSummaryReceived;

        /// <summary>
        /// Occurs when the NAT discovery process has finished.
        /// </summary>
        public event EventHandler<GEventArgs<NatInfo>> NatDiscoveryFinished;


        #endregion

        #region Init, Dispose

        public SoftphoneEngine()
        {
            _sync = new object();


            // set license here

            PhoneLines = new ObservableList<IPhoneLine>();
            PhoneCalls = new ObservableList<IPhoneCall>();
            LogEntries = new ObservableList<LogEntry>();
            InstantMessages = new ObservableList<string>();
            CallHistory = new CallHistory();
            CallTypes = new List<CallType> { CallType.Audio, CallType.AudioVideo };

            _subs = new ConcurrentDictionary<IPhoneLine, ISIPSubscription>();

            // enable file logging
            InitLogger();

            // create softphone
            MinPort = 20000;
            MaxPort = 20500;
            //LocalIP = SoftPhoneFactory.GetLocalIP();
            InitSoftphone(false);

            // create media
            MediaHandlers = new MediaHandlers();
            MediaHandlers.Init();
        }

        /// <summary>
        /// Initializes the base softphone engine.
        /// </summary>
        internal void InitSoftphone(bool useFixIP)
        {
            // if the softphone is already created, then close it
            if (softPhone != null)
            {
                // unregister the phone lines, because if the local IP address changed, the existing registrations will not work
                foreach (var line in PhoneLines)
                {
                    if (line.RegState == RegState.RegistrationSucceeded)
                        softPhone.UnregisterPhoneLine(line);
                }

                softPhone.IncomingCall -= (SoftPhone_IncomingCall);
                softPhone.Close();
            }

            // create new softphone
            if (LocalIP == null || !useFixIP)
                softPhone = SoftPhoneFactory.CreateSoftPhone(MinPort, MaxPort);
            else
                softPhone = SoftPhoneFactory.CreateSoftPhone(LocalIP, MinPort, MaxPort);

            softPhone.IncomingCall += (SoftPhone_IncomingCall);
        }

        /// <summary>
        /// Disposes the softphone engine. Hangs up calls, unregisters phone lines and disposes the media handlers.
        /// </summary>
        public void Dispose()
        {
            lock (_sync)
            {
                PhoneCalls.Clear();

                // unregister phone lines
                foreach (IPhoneLine line in PhoneLines)
                {
                    if (line.RegState == RegState.RegistrationSucceeded)
                        softPhone.UnregisterPhoneLine(line);

                    UnsubscribeFromLineEvents(line);
                    line.Dispose();
                }
                PhoneLines.Clear();

                // dispose media
                MediaHandlers.Dispose();

                // close softphone
                softPhone.Close();
            }
        }

        /// <summary>
        /// Creates the file logger.
        /// </summary>
        private void InitLogger()
        {
            try
            {
                string baseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Ozeki");
                if (!Directory.Exists(baseDir))
                    Directory.CreateDirectory(baseDir);

                baseDir = Path.Combine(baseDir, "Ozeki Demo Softphone");
                if (!Directory.Exists(baseDir))
                    Directory.CreateDirectory(baseDir);

                string logFilePath = Path.Combine(baseDir, "log.txt");

                var logConfig = new LogConfig(LogLevel.Error) { MediaLogLevel = LogLevel.Debug, CallLogLevel = LogLevel.Information };
                Logger.Attach(new DefaultFileLogger(logFilePath), logConfig);
                Logger.Attach(this, new LogConfig(LogLevel.Error) { CallLogLevel = LogLevel.Information/*, SIPLogLevel = LogLevel.Debug*/ });
                Logger.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot create log file. " + ex.Message);
            }
        }

        #endregion

        #region Invocators

        private void OnIncomingCall(IPhoneCall call)
        {
            var handler = IncomingCall;
            if (handler != null)
                handler(this, new GEventArgs<IPhoneCall>(call));
        }

        private void OnPhoneCallStateChanged(IPhoneCall call)
        {
            var handler = PhoneCallStateChanged;
            if (handler != null)
                handler(this, new GEventArgs<IPhoneCall>(call));
        }

        private void OnCallInstantMessageReceived(PhoneCallInstantMessageArgs args)
        {
            var handler = CallInstantMessageReceived;
            if (handler != null)
                handler(this, args);
        }

        private void OnPhoneLineStateChanged(IPhoneLine line)
        {
            var handler = PhoneLineStateChanged;
            if (handler != null)
                handler(this, new GEventArgs<IPhoneLine>(line));
        }

        private void OnMessageSummaryReceived(MessageSummaryArgs args)
        {
            var handler = MessageSummaryReceived;
            if (handler != null)
                handler(this, args);
        }

        private void OnNatDiscoveryFinished(NatInfo args)
        {
            var handler = NatDiscoveryFinished;
            if (handler != null)
                handler(this, new GEventArgs<NatInfo>(args));
        }

        #endregion

        #region PhoneLine Methods

        /// <summary>
        /// Creates a phone line and adds it to the collection.
        /// </summary>
        public IPhoneLine AddPhoneLine(SIPAccount account, Ozeki.Network.TransportType transportType, NatConfiguration natConfig, SRTPMode srtpMode, KeepAliveMode kepalive, int KeepaliveInterval)
        {
            var config = new PhoneLineConfiguration(account);
            config.TransportType = transportType;
            config.NatConfig = natConfig;
            config.SRTPMode = srtpMode;
            return AddPhoneLine(config);
        }

        /// <summary>
        /// Creates a phone line and adds it to the collection.
        /// </summary>
        public IPhoneLine AddPhoneLine(PhoneLineConfiguration config)
        {
            IPhoneLine line = softPhone.CreatePhoneLine(config);
            SubscribeToLineEvents(line);

            // add to collection
            PhoneLines.Add(line);

            return line;
        }

        /// <summary>
        /// Disposes the selected phone line and removes it from the collection.
        /// </summary>
        public void RemovePhoneLine()
        {
            if (SelectedLine == null)
                return;

            ClosePhoneLine(SelectedLine);
            PhoneLines.Remove(SelectedLine);
        }

        /// <summary>
        /// Closes the calls on the phone line and unregisters the SIP account.
        /// </summary>
        private void ClosePhoneLine(IPhoneLine line)
        {
            if (line == null)
                return;

            foreach (var call in line.PhoneCalls)
                call.HangUp();

            softPhone.UnregisterPhoneLine(SelectedLine);
        }

        /// <summary>
        /// Registers the selected phone line to the PBX.
        /// </summary>
        public void RegisterPhoneLine()
        {
            if (SelectedLine == null)
                return;

            softPhone.RegisterPhoneLine(SelectedLine);
        }

        /// <summary>
        /// Unregisters the selected phone line from the PBX.
        /// </summary>
        public void UnregisterPhoneLine()
        {
            if (SelectedLine == null)
                return;

            if (!_subs.ContainsKey(SelectedLine)) return;

            SelectedLine.Subscription.Unsubscribe(_subs[SelectedLine]);
            ISIPSubscription sub;
            _subs.TryRemove(SelectedLine, out sub);
            softPhone.UnregisterPhoneLine(SelectedLine);
        }

        /// <summary>
        /// Line event subscriptions.
        /// </summary>
        private void SubscribeToLineEvents(IPhoneLine line)
        {
            if (line == null)
                return;

            line.RegistrationStateChanged += Line_RegistrationStateChanged;
            line.InstantMessaging.MessageReceived += (Line_InstantMessageReceived);
        }

        /// <summary>
        /// Line event unsubscriptions.
        /// </summary>
        private void UnsubscribeFromLineEvents(IPhoneLine line)
        {
            if (line == null)
                return;

            line.RegistrationStateChanged -= Line_RegistrationStateChanged;
            line.InstantMessaging.MessageReceived -= (Line_InstantMessageReceived);
        }

        #endregion

        #region PhoneLine EventHandlers

        /// <summary>
        /// This will be called when the state of a phone line has changed.
        /// </summary>
        private void Line_RegistrationStateChanged(object sender, RegistrationStateChangedArgs e)
        {
            IPhoneLine line = sender as IPhoneLine;
            if (line == null)
                return;

            RegState state = e.State;

            // registration succeeded, subscribe for MWI
            if (state == RegState.RegistrationSucceeded)//&& line.SIPAccount.RegistrationRequired
            {
                var subscription = line.Subscription.Create(SIPEventType.MessageSummary);
                subscription.NotificationReceived += MWISubscription_NotificationReceived;
                _subs.TryAdd(line, subscription);
                line.Subscription.Subscribe(subscription);
            }

            OnPhoneLineStateChanged(line);
            OnPropertyChanged("SelectedLine.RegisteredInfo");
        }

        /// <summary>
        /// This will be called when a message-summary notification received fromt the PBX.
        /// </summary>
        void MWISubscription_NotificationReceived(object sender, SIPEventNotificationArgs e)
        {
            var subscription = sender as ISIPSubscription;
            if (subscription == null)
                return;

            var line = subscription.Owner as IPhoneLine;
            if (line == null)
                return;

            line.CustomProperties.AddOrUpdate("MessageSummary", e.MessageSummary);

            OnMessageSummaryReceived(new MessageSummaryArgs(line, e.MessageSummary));
        }

        /// <summary>
        /// This will be called when an instant message received through a phone line.
        /// </summary>
        private void Line_InstantMessageReceived(object sender, InstantMessage e)
        {
            AddInstantMessage(e.Sender, e.Content);
        }

        /// <summary>
        /// Adds an instant message to the history.
        /// </summary>
        public void AddInstantMessage(string sender, string data)
        {
            InstantMessages.Add(string.Format("{0}: {1}", sender, data));
        }

        internal void ClearInstantMessages()
        {
            InstantMessages.Clear();
        }

        #endregion

        #region PhoneCall Methods

        /// <summary>
        /// Starts dialling a number on the selected phone line.
        /// </summary>
        public void Dial(string dialNumber, CallType callType)
        {
            if (string.IsNullOrEmpty(dialNumber))
                return;

            var dialParams = new DialParameters(dialNumber);
            dialParams.CallType = callType;

            IPhoneCall call = softPhone.CreateCallObject(SelectedLine, dialParams);
            StartCall(call);
        }

        /// <summary>
        /// Starts dialling a number on the selected phone line.
        /// </summary>
        public void DialIP(string address, CallType callType)
        {
            if (string.IsNullOrEmpty(address))
                return;

            var dialParams = new DirectIPDialParameters("5060");
            dialParams.CallType = callType;

            IPhoneCall call = softPhone.CreateDirectIPCallObject(SelectedLine, dialParams, address);
            StartCall(call);
        }

        private void StartCall(IPhoneCall call)
        {
            lock (_sync)
            {
                if (call == null)
                    return;

                SubscribeToCallEvents(call);
                call.Start();
                MediaHandlers.LoadSpeechToText();
                PhoneCalls.Add(call);

                if (SelectedCall == null)
                    SelectedCall = call;
            }
        }

        /// <summary>
        /// Accepts the selected incoming call.
        /// </summary>
        public void AnswerCall()
        {
            lock (_sync)
            {
                if (SelectedCall == null)
                    return;

                SelectedCall.Answer(CallType.AudioVideo);
            }
        }

        /// <summary>
        /// Rejects the selected incoming call.
        /// </summary>
        public void RejectCall()
        {
            lock (_sync)
            {
                if (SelectedCall == null)
                    return;

                SelectedCall.Reject();
            }
        }

        /// <summary>
        /// Hangs up the selected call.
        /// </summary>
        internal void HangUpCall()
        {
            lock (_sync)
            {
                if (SelectedCall == null)
                    return;

                SelectedCall.HangUp();
            }
        }

        /// <summary>
        /// Puts on hold selected call.
        /// </summary>
        public void HoldCall()
        {
            lock (_sync)
            {
                if (SelectedCall == null)
                    return;

                SelectedCall.Hold();
            }
        }

        /// <summary>
        /// Takes the selected call off hold.
        /// </summary>
        public void UnholdCall()
        {
            if (SelectedCall == null)
                return;

            SelectedCall.Unhold();
        }

        /// <summary>
        /// Forwards the selected incoming call.
        /// </summary>
        internal void ForwardCall(string target)
        {
            lock (_sync)
            {
                if (SelectedCall == null)
                    return;

                if (!SelectedCall.IsIncoming)
                    return;

                SelectedCall.Forward(target);
            }
        }

        /// <summary>
        /// Routes the selected call to a third party.
        /// </summary>
        public void BlindTransfer(string target)
        {
            lock (_sync)
            {
                if (string.IsNullOrEmpty(target))
                    return;

                if (SelectedCall == null)
                    return;

                SelectedCall.BlindTransfer(target);
            }
        }

        /// <summary>
        /// Routes the selected call to another.
        /// </summary>
        public void AttendedTransfer(IPhoneCall targetCall)
        {
            lock (_sync)
            {
                if (SelectedCall == null)
                    return;

                if (targetCall == null)
                    return;

                SelectedCall.AttendedTransfer(targetCall);
            }
        }

        /// <summary>
        /// Sends a message to the other party.
        /// </summary>
        public void SendInstantMessage(string message)
        {
            lock (_sync)
            {
                if (SelectedCall == null)
                    return;

                SelectedCall.SendInstantMessage(message);
            }
        }

        /// <summary>
        /// Modifies the media channels of the selected phone call.
        /// </summary>
        public void ModifyCallType(CallType callType)
        {
            lock (_sync)
            {
                if (SelectedCall == null)
                    return;

                SelectedCall.ModifyCallType(callType);
            }
        }

        #endregion

        #region PhoneCall EventHandlers

        /// <summary>
        /// This will be called when an incoming call received.
        /// </summary>
        private void SoftPhone_IncomingCall(object sender, VoIPEventArgs<IPhoneCall> e)
        {
            IPhoneCall call = e.Item;

            lock (_sync)
            {
                SubscribeToCallEvents(call);

                // automatically rejected for some reason
                if (call.CallState.IsCallEnded())
                {
                    CallHistory.Add(call);
                    return;
                }

                // add to call container
                PhoneCalls.Add(call);

                // if no call is in progress, select the incoming call as current call and attach the audio to hear the ringtone
                if (SelectedCall == null)
                {
                    SelectedCall = call;
                    //MediaHandlers.AttachAudio(call);
                }
            }
            // raise IncomingCall event
            OnIncomingCall(call);
        }

        /// <summary>
        /// This will be called when the state of a call has changed.
        /// </summary>
        private void Call_CallStateChanged(object sender, CallStateChangedArgs e)
        {
            IPhoneCall call = sender as IPhoneCall;
            if (call == null)
                return;

            CallState state = e.State;

            OnPhoneCallStateChanged(call);
            CheckStopRingback();
            CheckStopRingtone();

            lock (_sync)
            {
                // start ringtones
                if (state.IsRinging())
                {
                    if (call.IsIncoming)
                        MediaHandlers.StartRingtone();
                    else
                        MediaHandlers.StartRingback();

                    return;
                }

                // call has been answered
                if (state == CallState.Answered)
                {

                    return;
                }

                // attach media to the selected call when the remote party sends media data
                if (state.IsRemoteMediaCommunication())
                {
                    if (SelectedCall.Equals(call))
                    {
                        MediaHandlers.AttachAudio(call);
                        MediaHandlers.AttachVideo(call);
                    }
                    return;
                }

                // detach media from the selected call in hold state or when the call has ended
                if (state == CallState.LocalHeld || state == CallState.InactiveHeld || state.IsCallEnded())
                {
                    if (SelectedCall != null && SelectedCall.Equals(call))
                    {
                        MediaHandlers.DetachAudio();
                        MediaHandlers.DetachVideo();
                    }
                }

                // call has ended, clean up
                if (state.IsCallEnded())
                {
                    DisposeCall(call);

                    CallHistory.Add(call);
                    PhoneCalls.Remove(call);
                }
            }
        }

        private void CheckStopRingback()
        {
            lock (_sync)
            {
                bool stopRinging = true;
                foreach (var phoneCall in PhoneCalls)
                {
                    if (!phoneCall.IsIncoming && phoneCall.CallState.IsRinging())
                    {
                        stopRinging = false;
                        break;
                    }
                }

                if (stopRinging)
                    MediaHandlers.StopRingback();
            }
        }

        private void CheckStopRingtone()
        {
            lock (_sync)
            {
                bool stopRinging = true;
                foreach (var phoneCall in PhoneCalls)
                {
                    if (phoneCall.IsIncoming && phoneCall.CallState.IsRinging())
                    {
                        stopRinging = false;
                        break;
                    }
                }

                if (stopRinging)
                    MediaHandlers.StopRingtone();
            }
        }

        /// <summary>
        /// This will be called when an instant message received through a call.
        /// </summary>
        private void Call_InstantMessageReceived(object sender, InstantMessage e)
        {
            IPhoneCall call = sender as IPhoneCall;
            if (call == null)
                return;

            OnCallInstantMessageReceived(new PhoneCallInstantMessageArgs(call, e));
        }

        void DisposeCall(IPhoneCall call)
        {
            lock (_sync)
            {
                UnsubscribeFromCallEvents(call);

                if (call.Equals(SelectedCall))
                    SelectedCall = null;
            }
        }

        /// <summary>
        /// Call event subscriptions.
        /// </summary>
        private void SubscribeToCallEvents(IPhoneCall call)
        {
            if (call == null)
                return;

            call.CallStateChanged += (Call_CallStateChanged);
            call.DtmfReceived += (Call_DtmfReceived);
            call.DtmfStarted += (Call_DtmfStarted);
            call.InstantMessageReceived += (Call_InstantMessageReceived);
        }

        /// <summary>
        /// Call event unsubscriptions.
        /// </summary>
        private void UnsubscribeFromCallEvents(IPhoneCall call)
        {
            if (call == null)
                return;

            call.CallStateChanged -= (Call_CallStateChanged);
            call.DtmfReceived -= (Call_DtmfReceived);
            call.DtmfStarted -= (Call_DtmfStarted);
            call.InstantMessageReceived -= (Call_InstantMessageReceived);
        }

        #endregion

        #region Codecs

        /// <summary>
        /// Gets the supported codecs.
        /// </summary>
        public IEnumerable<CodecInfo> AudioCodecs
        {
            get { return softPhone.Codecs.Where(c => c.MediaType == CodecMediaType.Audio); }
        }

        /// <summary>
        /// Gets the supported codecs.
        /// </summary>
        public IEnumerable<CodecInfo> VideoCodecs
        {
            get { return softPhone.Codecs.Where(c => c.MediaType == CodecMediaType.Video); }
        }

        /// <summary>
        /// Enables a codec.
        /// </summary>
        /// <param name="payloadType">The payload type of the codec.</param>
        internal void EnableCodec(int payloadType)
        {
            softPhone.EnableCodec(payloadType);
        }

        /// <summary>
        /// Disables a codec.
        /// </summary>
        /// <param name="payloadType">The payload type of the codec.</param>
        internal void DisableCodec(int payloadType)
        {
            softPhone.DisableCodec(payloadType);
        }

        /// <summary>
        /// Sets the quality of the sent video data.
        /// </summary>
        internal void SetVideoEncoderQuality(VideoQuality videoQuality)
        {
            softPhone.VideoEncoderQuality = videoQuality;
        }

        #endregion

        #region DTMF

        /// <summary>
        /// Starts the DTMF signalling.
        /// </summary>
        public void StartDtmfSignal(int signal)
        {
            StartDtmfSignal((DtmfNamedEvents)signal);
        }

        /// <summary>
        /// Starts the DTMF signalling.
        /// </summary>
        public void StartDtmfSignal(DtmfNamedEvents signal)
        {
            lock (_sync)
            {
                MediaHandlers.StartDtmf(signal);

                if (SelectedCall == null)
                    return;

                SelectedCall.StartDTMFSignal(signal);
            }
        }

        /// <summary>
        /// Stops the DTMF singalling.
        /// </summary>
        internal void StopDtmfSignal(int signal)
        {
            StopDtmfSignal((DtmfNamedEvents)signal);
        }

        /// <summary>
        /// Stops the DTMF singalling.
        /// </summary>
        internal void StopDtmfSignal(DtmfNamedEvents signal)
        {
            lock (_sync)
            {
                MediaHandlers.StopDtmf(signal);

                if (SelectedCall == null)
                    return;

                SelectedCall.StopDTMFSignal(signal);
            }
        }

        /// <summary>
        /// This will be called when the other party started DTMF signaling.
        /// </summary>
        private void Call_DtmfStarted(object sender, VoIPEventArgs<DtmfInfo> e)
        {
            int signal = e.Item.Signal.Signal;
            MediaHandlers.StartDtmf(signal);
        }

        /// <summary>
        /// This will be called when the other party stopped DTMF signaling.
        /// </summary>
        private void Call_DtmfReceived(object sender, VoIPEventArgs<DtmfInfo> e)
        {
            DtmfSignal signal = e.Item.Signal;
            MediaHandlers.StopDtmf(signal.Signal);
        }

        #endregion

        #region NAT Discovery

        public void BeginNatDiscovery()
        {
            // determine which local address used for NAT discovery
            string localAddress = string.Empty;
            if (LocalIP == null)
            {
                var localIP = SoftPhoneFactory.GetLocalIP();
                if (localIP != null)
                    localAddress = localIP.ToString();
            }
            else
                localAddress = LocalIP.ToString();


            // begin NAT discovery
            softPhone.BeginNatDiscovery(localAddress, "stun.ozekiphone.com", Callback);
        }

        private void Callback(NatInfo info)
        {
            OnNatDiscoveryFinished(info);
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region ILogger

        private int counter;

        public void Append(LogEvent logEvent)
        {
            if (logEvent.EventCode > 30000 && logEvent.EventCode < 40000)
            {
                if (logEvent.EventCode != 30008 && logEvent.EventCode != 30010)
                    return;
            }

            LogEntries.Add(new LogEntry() { DateTime = DateTime.Now, Index = ++counter, Message = logEvent.Message, LogLevel = logEvent.Level });


        }
        #endregion
    }
}