using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using OzekiDemoSoftphoneWPF.GUI.GUIModels;
using OzekiDemoSoftphoneWPF.Model;
using Ozeki.VoIP;
using System;
using OzekiDemoSoftphoneWPF.Model.Data;
using TestSoftphone;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using Ozeki.Media;
using Ozeki.Network;

namespace OzekiDemoSoftphoneWPF.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public SoftphoneEngine Model { get; private set; }
        public MediaHandlers MediaHandlers { get { return Model.MediaHandlers; } }

        #region GUI Properties

        public string TitleString
        {
            get { return string.Format("Ozeki VoIP SIP SDK - Demo Application {0}", Assembly.GetExecutingAssembly().GetName().Version); }
        }

        public IPhoneLine SelectedLine
        {
            get { return cbPhoneLines.SelectedItem as IPhoneLine; }
        }

        private string dialNumber;
        private static string subtitlevalue;
        private string wavPlaybackFileName;
        private string wavRecordFileName;
        private string mp3PlaybackFileName;
        private string ringtoneFileName;
        private string ringbackFileName;
        private string recipient;
        private string instantMessage;

        public string WavPlaybackFileName
        {
            get { return wavPlaybackFileName; }
            private set
            {
                wavPlaybackFileName = value;
                OnNotifyPropertyChanged("WavPlaybackFileName");
            }
        }

        public string WavRecordFileName
        {
            get { return wavRecordFileName; }
            private set
            {
                wavRecordFileName = value;
                OnNotifyPropertyChanged("WavRecordFileName");
            }
        }

        public string MP3PlaybackFileName
        {
            get { return mp3PlaybackFileName; }
            private set
            {
                mp3PlaybackFileName = value;
                OnNotifyPropertyChanged("MP3PlaybackFileName");
            }
        }
        
        public string DialNumber
        {
            get { return dialNumber; }
            set
            {
                dialNumber = value;
                OnNotifyPropertyChanged("DialNumber");
            }
        }

        public string SubTitle
        {
            get { return subtitlevalue; }
            set {
                subtitlevalue = value;
                OnNotifyPropertyChanged("SubTitle");
            }
        }

        public string RingtoneFileName
        {
            get { return ringtoneFileName; }
            private set
            {
                ringtoneFileName = value;
                OnNotifyPropertyChanged("RingtoneFileName");
            }
        }

        public string RingbackFileName
        {
            get { return ringbackFileName; }
            private set
            {
                ringbackFileName = value;
                OnNotifyPropertyChanged("RingbackFileName");
            }
        }

        public string Recipient
        {
            get { return recipient; }
            set
            {
                recipient = value;
                OnNotifyPropertyChanged("Recipient");
            }
        }

        public string InstantMessage
        {
            get { return instantMessage; }
            set
            {
                instantMessage = value;
                OnNotifyPropertyChanged("InstantMessage");
            }
        }

        public List<KeepAliveMode> KeepAliveValues { get; private set; }
        public List<VideoQuality> VideoQualities { get; private set; }

        #endregion

        public MainWindow(SoftphoneEngine model)
        {
            Model = model;

          

            VideoQualities = new List<VideoQuality>();
            var qualities = Enum.GetValues(typeof(VideoQuality));
            foreach (VideoQuality quality in qualities)
                VideoQualities.Add(quality);
            //VideoEncoderQuality = VideoQuality.High;

            InitializeComponent();

            Model.PhoneLineStateChanged += (Model_PhoneLineStateChanged);
            Model.PhoneCallStateChanged += (Model_PhoneCallStateChanged);
            Model.MessageSummaryReceived += (Model_MessageSummaryReceived);
            Model.NatDiscoveryFinished += Model_NatDiscoveryFinished;
            Model.CallInstantMessageReceived += (Model_CallInstantMessageReceived);
            Model.MediaHandlers.MicrophoneStopped += MediaHandlers_MicrophoneStopped;
            Model.MediaHandlers.SpeakerStopped += MediaHandlers_SpeakerStopped;


            KeepAliveValues = new List<KeepAliveMode>();
            var keelAliveValues = Enum.GetValues(typeof(KeepAliveMode));
            foreach (KeepAliveMode mode in keelAliveValues)
                KeepAliveValues.Add(mode);

            OnNotifyPropertyChanged("KeepAliveValues");
        }

        #region Window events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            remoteVideoViewer.SetImageProvider(MediaHandlers.RemoteImageProvider);
            localVideoViewer.SetImageProvider(MediaHandlers.LocalImageProvider);

            remoteVideoViewer.Start();
            localVideoViewer.Start();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Model.PhoneLineStateChanged -= (Model_PhoneLineStateChanged);
            Model.PhoneCallStateChanged -= (Model_PhoneCallStateChanged);
            Model.MessageSummaryReceived -= (Model_MessageSummaryReceived);
            Model.NatDiscoveryFinished -= (Model_NatDiscoveryFinished);
            Model.CallInstantMessageReceived -= (Model_CallInstantMessageReceived);
            Model.Dispose();
        }

        #endregion

        #region Model events

        private void Model_PhoneLineStateChanged(object sender, GEventArgs<IPhoneLine> e)
        {
            tbPhoneLineStatus.Dispatcher.Invoke(new Action(() => tbPhoneLineStatus.GetBindingExpression(TextBox.TextProperty).UpdateTarget()));
        }

        private void Model_PhoneCallStateChanged(object sender, GEventArgs<IPhoneCall> e)
        {
            UpdatePhoneCalls();
        }

        private void Model_MessageSummaryReceived(object sender, MessageSummaryArgs e)
        {
            btnMessageSummary.Dispatcher.Invoke(new Action(() => {
                btnMessageSummary.GetBindingExpression(Button.ContentProperty).UpdateTarget();
                btnMessageSummary.GetBindingExpression(Button.IsEnabledProperty).UpdateTarget();
            }));
        }

        private void Model_CallInstantMessageReceived(object sender, PhoneCallInstantMessageArgs e)
        {
            string sipAccount = string.Format("{0}@{1}", e.PhoneCall.PhoneLine.SIPAccount.UserName, e.PhoneCall.PhoneLine.SIPAccount.DomainServerHost);

            StringBuilder sb = new StringBuilder();
            sb.Append("Instant message received\r\n");
            sb.Append(string.Format("Call: {0} - {1}\r\n", sipAccount, e.PhoneCall.DialInfo));
            sb.Append(string.Format("Message: {0}", e.Message.Content));

            MessageBox.Show(sb.ToString());
        }

        private void Model_NatDiscoveryFinished(object sender, GEventArgs<NatInfo> e)
        {
            NatInfo info = e.Item;
            natDiscoveryWin.Dispatcher.Invoke(new Action(() => natDiscoveryWin.Close()));

            MessageBox.Show(string.Format("NAT discovery finished. NAT Type: {0}, Public address: {1}", info.NatType, info.PublicAddress));
        }

        private void MediaHandlers_SpeakerStopped(object sender, EventArgs e)
        {
            RefreshSpeakerDevices();
        }

        private void MediaHandlers_MicrophoneStopped(object sender, EventArgs e)
        {
            RefreshMicrophoneDevices();
        }

        private void UpdatePhoneCalls()
        {
            lvPhoneCalls.Dispatcher.Invoke(new Action(() => lvPhoneCalls.Items.Refresh()));
        }

        #endregion

        #region PhoneLine

        private void btnAddPhoneLine_Click(object sender, RoutedEventArgs e)
        {
            AccountModel model = new AccountModel();
            AccountWindow accountWin = new AccountWindow(this, model);
            bool? ok = accountWin.ShowDialog();

            if (ok != null && ok == true)
            {
                int keepaliveInterval = 5;
                KeepAliveMode keepalive = KeepAliveMode.NONE;
                if (cbKeepAlive.SelectedItem != null)
                {
                    keepalive = (KeepAliveMode)cbKeepAlive.SelectedItem;

                }
                try
                {
                    keepaliveInterval = int.Parse(tbKeepAliveInterval.Text);
                }
                catch { }
                var line = Model.AddPhoneLine(model.SIPAccount, model.TransportType, model.NatConfig, model.SRTPMode,keepalive, keepaliveInterval);

                //if (Model.SelectedLine == null)
                Model.SelectedLine = line;
            }
        }

        private void btnModifyPhoneLine_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedLine == null)
                return;

            AccountModel model = new AccountModel();

            model.DisplayName = Model.SelectedLine.SIPAccount.DisplayName;
            model.Domain = Model.SelectedLine.SIPAccount.DomainServerHost;
            model.UserName = Model.SelectedLine.SIPAccount.UserName;
            model.RegisterName = Model.SelectedLine.SIPAccount.RegisterName;
            model.Password = Model.SelectedLine.SIPAccount.RegisterPassword;
            model.RegistrationRequired = Model.SelectedLine.SIPAccount.RegistrationRequired;
            model.OutboundProxy = Model.SelectedLine.SIPAccount.OutboundProxy;
            model.TransportType = Model.SelectedLine.Config.TransportType;
            model.SRTPMode = Model.SelectedLine.Config.SRTPMode;
            model.AutoDetectNat = Model.SelectedLine.Config.NatConfig.AutoDetect;
            model.NatTraversalMethod = Model.SelectedLine.Config.NatConfig.TraversalMethodType;
            model.STUNServerAddress = Model.SelectedLine.Config.NatConfig.StunServerAddress;

            AccountWindow accountWin = new AccountWindow(this, model);
            bool? ok = accountWin.ShowDialog();
            if (ok != null && ok == true)
            {
                Model.RemovePhoneLine();
                int keepaliveInterval = 5;
                KeepAliveMode keepalive = KeepAliveMode.NONE;
                if (cbKeepAlive.SelectedItem != null)
                {
                    keepalive = (KeepAliveMode)cbKeepAlive.SelectedItem;

                }
                try
                {
                    keepaliveInterval = int.Parse(tbKeepAliveInterval.Text);
                }
                catch { }

                var line = Model.AddPhoneLine(model.SIPAccount, model.TransportType, model.NatConfig, model.SRTPMode, keepalive,keepaliveInterval);

                //if (Model.SelectedLine == null)
                Model.SelectedLine = line;
            }
        }

        private void btnRemovePhoneLine_Click(object sender, RoutedEventArgs e)
        {
            Model.RemovePhoneLine();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.RegisterPhoneLine();
            }
            catch (Exception ex)
            {
                ShowLicenseError(ex.Message);
            }
        }

        private void btnUnregister_Click(object sender, RoutedEventArgs e)
        {
            Model.UnregisterPhoneLine();
        }

        private void btnMessageSummary_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedLine == null)
                return;

            var messageSummary = SelectedLine.CustomProperties.Get<MessageSummary>("MessageSummary");
            if (messageSummary == null)
                return;

            MessageSummaryWindow messageSummaryWin = new MessageSummaryWindow(this, messageSummary);
            messageSummaryWin.ShowDialog();
        }

        #endregion        

        #region About

        private void btnAboutOzeki_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow box = new AboutWindow(this);
            box.ShowDialog();
        }

        private void btnProjects_Click(object sender, RoutedEventArgs e)
        {
            var myDocuments = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Ozeki"), "Ozeki VoIP SDK");

            OpenUrl(myDocuments);
        }

        private void btnWebsite_Click(object sender, RoutedEventArgs e)
        {
            OpenUrl("http://www.voip-sip-sdk.com");
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            OpenUrl("file://" + SDKPath + "Documentation\\SDKHelp\\index.html");
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private string path;
        private string SDKPath
        {
            get
            {
                if (string.IsNullOrEmpty(path))
                {
                    try
                    {
                        path =
                            Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Ozeki").OpenSubKey("VOIP SIP SDK").
                                GetValue("PATH").ToString();
                    }
                    catch
                    {
                        path = Environment.CurrentDirectory;
                    }
                }

                return path;
            }
        }

        #endregion

        #region Dialpad

        private void btnKeyPad_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
                return;

            // if no calls selected, extend the dial number
            if (Model.SelectedCall == null)
                DialNumber += button.Content.ToString();
        }

        private void btnKeyPad_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
                return;

            // start DTMF
            int signal;
            if (int.TryParse(button.Tag.ToString(), out signal))
                Model.StartDtmfSignal(signal);
        }

        private void btnKeyPad_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
                return;

            // stop DTMF
            int signal;
            if (int.TryParse(button.Tag.ToString(), out signal))
                Model.StopDtmfSignal(signal);
        }

        private void btnDialAudio_Click(object sender, RoutedEventArgs e)
        {
            Dial(CallType.Audio, false);
        }

        private void btnDialVideo_Click(object sender, RoutedEventArgs e)
        {
            Dial(CallType.AudioVideo, false);
        }

        private void btnDialPadIP_Click(object sender, RoutedEventArgs e)
        {
            Dial(CallType.Audio, true);
        }

        private void Dial(CallType callType, bool dialIP)
        {
            if (SelectedLine == null)
                return;

            if (!SelectedLine.RegState.IsRegistered())
            {
                MessageBox.Show("Cannot start calls while the selected line is not registered.");
                return;
            }
            try
            {
                if (!dialIP)
                    Model.Dial(DialNumber, callType);
                else
                    Model.DialIP(DialNumber, callType);
            }
            catch (Exception ex)
            {
                ShowLicenseError(ex.Message);
            }

            DialNumber = string.Empty;
        }

        #endregion

        #region Phone Call Functions

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.AnswerCall();
            }
            catch (Exception ex)
            {
                ShowLicenseError(ex.Message);
            }
        }

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            Model.RejectCall();
        }

        private void btnHangup_Click(object sender, RoutedEventArgs e)
        {
            Model.HangUpCall();
        }

        private void btnHold_Click(object sender, RoutedEventArgs e)
        {
            Model.HoldCall();
        }

        private void btnUnhold_Click(object sender, RoutedEventArgs e)
        {
            Model.UnholdCall();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedCall == null)
                return;

            if (!Model.SelectedCall.IsIncoming || !Model.SelectedCall.CallState.IsRinging())
                return;

            ForwardWindow forwardWin = new ForwardWindow(this);
            bool? ok = forwardWin.ShowDialog();
            if (ok != null && ok == true)
            {
                string target = forwardWin.Target;

                // forward call
                Model.ForwardCall(target);
            }
        }

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (Model.SelectedCall == null)
                return;

            if (!Model.SelectedCall.CallState.IsInCall())
                return;

            TransferModel transferSettings = new TransferModel(Model.PhoneCalls, Model.SelectedCall);
            TransferWindow tranferWin = new TransferWindow(this, transferSettings);
            bool? ok = tranferWin.ShowDialog();
            if (ok != null && ok == true)
            {
                // blind transfer
                if (transferSettings.TransferMode == TransferMode.Blind)
                {
                    Model.BlindTransfer(transferSettings.BlindTransferTarget);
                    return;
                }

                // attended transfer
                if (transferSettings.TransferMode == TransferMode.Attended)
                {
                    Model.AttendedTransfer(transferSettings.AttendedTransferTarget);
                    return;
                }
            }
        }

        private void cbAudioVideoCall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbAudioVideoCall.SelectedIndex)
            {
                case 0:
                    Model.ModifyCallType(CallType.Audio);
                    return;

                case 1:
                    Model.ModifyCallType(CallType.AudioVideo);
                    return;
            }
        }

        #endregion

        #region Call History

        private void lvCallHistory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Redial();
        }

        private void btnRedial_Click(object sender, RoutedEventArgs e)
        {
            Redial();
        }

        private void btnClearCallHistory_Click(object sender, RoutedEventArgs e)
        {
            Model.CallHistory.Clear();
        }

        private void Redial()
        {
            CallHistoryInfo info = lvCallHistory.SelectedItem as CallHistoryInfo;
            if (info == null)
                return;

            DialNumber = info.OtherParty.Dialed;
            Dial(CallType.Audio, false);

            tiPhoneCalls.IsSelected = true;
        }

        #endregion

        #region Microphone, Speaker

        private void btnRefreshMicrophones_Click(object sender, RoutedEventArgs e)
        {
            RefreshMicrophoneDevices();
        }

        private void RefreshMicrophoneDevices()
        {
            Dispatcher.BeginInvoke(new Action(() => cbMicrophoneDevices.GetBindingExpression(ComboBox.ItemsSourceProperty).UpdateTarget()));
        }

        private void cbMicrophoneDevices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AudioDeviceInfo selected = cbMicrophoneDevices.SelectedItem as AudioDeviceInfo;
            if (selected == null)
                return;

            bool forceStart = lvPhoneCalls.HasItems;
            MediaHandlers.ChangeMicrophone(selected);
        }

        private void btnRefreshSpeakers_Click(object sender, RoutedEventArgs e)
        {
            RefreshSpeakerDevices();
        }

        private void RefreshSpeakerDevices()
        {
            Dispatcher.BeginInvoke(new Action(() => cbSpeakerDevices.GetBindingExpression(ComboBox.ItemsSourceProperty).UpdateTarget()));
        }

        private void cbSpeakerDevices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AudioDeviceInfo selected = cbSpeakerDevices.SelectedItem as AudioDeviceInfo;
            if (selected == null)
                return;

            bool forceStart = lvPhoneCalls.HasItems;
            MediaHandlers.ChangeSpeaker(selected);
        }

        #endregion

        #region Wav Playback

        private void btnBrowseWavPlaybackFile_Click(object sender, RoutedEventArgs e)
        {
            string fileName = DisplayOpenFileDialog("wav");
            if (string.IsNullOrEmpty(fileName))
                return;

            WavPlaybackFileName = fileName;
            MediaHandlers.LoadPlaybackWavFile(WavPlaybackFileName);
        }

        private void btnPlayWavPlaybackFile_Click(object sender, RoutedEventArgs e)
        {
            MediaHandlers.StartWavPlayback();
        }

        private void btnPauseWavPlaybackFile_Click(object sender, RoutedEventArgs e)
        {
            MediaHandlers.PauseWavPlayback();
        }

        private void btnStopWavPlaybackFile_Click(object sender, RoutedEventArgs e)
        {
            MediaHandlers.StopWavPlayback();
        }

        #endregion

        #region MP3 Playback

        private void btnBrowseMP3PlaybackFile_Click(object sender, RoutedEventArgs e)
        {
            string fileName = DisplayOpenFileDialog("mp3");
            if (string.IsNullOrEmpty(fileName))
                return;

            MP3PlaybackFileName = fileName;
            MediaHandlers.LoadPlaybackMP3File(MP3PlaybackFileName);
        }

        private void btnPlayMP3PlaybackFile_Click(object sender, RoutedEventArgs e)
        {
            MediaHandlers.StartMP3Playback();
        }

        private void btnPauseMP3PlaybackFile_Click(object sender, RoutedEventArgs e)
        {
            MediaHandlers.PauseMP3Playback();
        }

        private void btnStopMP3PlaybackFile_Click(object sender, RoutedEventArgs e)
        {
            MediaHandlers.StopMP3Playback();
        }

        #endregion

        #region Wav Recorder

        private void btnBrowseWavRecordFile_Click(object sender, RoutedEventArgs e)
        {
            string fileName = DisplaySaveFileDialog("wav");
            if (string.IsNullOrEmpty(fileName))
                return;

            WavRecordFileName = fileName;
            MediaHandlers.LoadRecordWavFile(WavRecordFileName);
        }

        private void btnPlayWavRecordFile_Click(object sender, RoutedEventArgs e)
        {
            MediaHandlers.StartWavRecording();
        }

        private void btnPauseWavRecordFile_Click(object sender, RoutedEventArgs e)
        {
            MediaHandlers.PauseWavRecording();
        }

        private void btnStopWavRecordFile_Click(object sender, RoutedEventArgs e)
        {
            MediaHandlers.StopWavRecording();
            WavRecordFileName = null;
        }

        #endregion

        #region Ringtones

        private void btnBrowseRingbackFile_Click(object sender, RoutedEventArgs e)
        {
            string fileName = DisplayOpenFileDialog("wav");
            if (string.IsNullOrEmpty(fileName))
                return;

            MediaHandlers.SetRingback(fileName);
            RingbackFileName = fileName;
        }

        private void btnBrowseRingtoneFile_Click(object sender, RoutedEventArgs e)
        {
            string fileName = DisplayOpenFileDialog("wav");
            if (string.IsNullOrEmpty(fileName))
                return;

            MediaHandlers.SetRingtone(fileName);
            RingtoneFileName = fileName;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Camera

        private void cbCameraDevices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VideoDeviceInfo deviceInfo = cbCameraDevices.SelectedItem as VideoDeviceInfo;
            if (deviceInfo == null)
                return;

            MediaHandlers.ChangeCamera(deviceInfo.DeviceID);
        }

        private void btnRefreshCameras_Click(object sender, RoutedEventArgs e)
        {
            cbCameraDevices.GetBindingExpression(ComboBox.ItemsSourceProperty).UpdateTarget();
        }

        private void btnStartVideo_Click(object sender, RoutedEventArgs e)
        {
            // start camera
            MediaHandlers.StartVideo();

            // start GUI control
            localVideoViewer.Start();
        }

        private void btnStopVideo_Click(object sender, RoutedEventArgs e)
        {
            // stop camera
            MediaHandlers.StopVideo();

            // stop GUI control
            localVideoViewer.Stop();
        }

        #endregion

        #region File Dialogs

        private string DisplayOpenFileDialog(string extension)
        {
            string filter = string.Empty;
            switch (extension.ToLower())
            {
                case "wav":
                    filter = "Wave files (.wav)|*.wav";
                    break;

                case "mp3":
                    filter = "MP3 files (.mp3)|*.mp3";
                    break;
            }

            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = filter;
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.FileName;
            }

            return null;
        }

        private string DisplaySaveFileDialog(string extension)
        {
            string filter = string.Empty;
            switch (extension.ToLower())
            {
                case "wav":
                    filter = "Wave files (.wav)|*.wav";
                    break;

                case "mp3":
                    filter = "MP3 files (.mp3)|*.mp3";
                    break;
            }

            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = filter;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return dialog.FileName;
            }

            return null;
        }

        #endregion

        #region Codecs

        private void CodecCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null)
                return;

            // determine payload type        
            int payloadType;
            if (!int.TryParse(checkBox.Tag.ToString(), out payloadType))
                return;

            // enable codec
            Model.EnableCodec(payloadType);
        }

        private void CodecCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null)
                return;

            // determine payload type        
            int payloadType;
            if (!int.TryParse(checkBox.Tag.ToString(), out payloadType))
                return;

            // disable codec
            Model.DisableCodec(payloadType);
        }

        private void btnSelectAllAudioCodecs_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lbAudioCodecs.Items)
            {
                CodecInfo info = item as CodecInfo;
                if (info == null)
                    continue;

                Model.EnableCodec(info.PayloadType);
            }

            lbAudioCodecs.GetBindingExpression(ListBox.ItemsSourceProperty).UpdateTarget();
        }

        private void btnDeselectAllAudioCodecs_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lbAudioCodecs.Items)
            {
                CodecInfo info = item as CodecInfo;
                if (info == null)
                    continue;

                Model.DisableCodec(info.PayloadType);
            }

            lbAudioCodecs.GetBindingExpression(ListBox.ItemsSourceProperty).UpdateTarget();
        }

        private void btnSelectAllVideoCodecs_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lbVideoCodecs.Items)
            {
                CodecInfo info = item as CodecInfo;
                if (info == null)
                    continue;

                Model.EnableCodec(info.PayloadType);
            }

            lbVideoCodecs.GetBindingExpression(ListBox.ItemsSourceProperty).UpdateTarget();
        }

        private void btnDeselectAllVideoCodecs_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in lbVideoCodecs.Items)
            {
                CodecInfo info = item as CodecInfo;
                if (info == null)
                    continue;

                Model.DisableCodec(info.PayloadType);
            }

            lbVideoCodecs.GetBindingExpression(ListBox.ItemsSourceProperty).UpdateTarget();
        }

        VideoQuality videoEncoderQuality;
        public VideoQuality VideoEncoderQuality
        {
            get { return videoEncoderQuality; }
            set
            {
                videoEncoderQuality = value;
                Model.SetVideoEncoderQuality(videoEncoderQuality);
            }
        }

        #endregion

        #region Network

        public bool UseFixIP { get; set; }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            Model.InitSoftphone(UseFixIP);
        }

        NatDiscoveryWindow natDiscoveryWin;
        private void btnNatDiscovery_Click(object sender, RoutedEventArgs e)
        {
            Model.BeginNatDiscovery();

            natDiscoveryWin = new NatDiscoveryWindow(this);
            natDiscoveryWin.ShowDialog();
        }

        #endregion

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedLine == null)
                return;

            var message = new InstantMessage(Recipient, InstantMessage);
            SelectedLine.InstantMessaging.SendMessage(message);

            string msgSender = string.Format("{0}", SelectedLine.SIPAccount);
            Model.AddInstantMessage(msgSender, InstantMessage);
            InstantMessage = "";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Model.ClearInstantMessages();
        }

        private void ShowLicenseError(string message)
        {
            MessageBox.Show(message, "Ozeki VoIP SIP SDK", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        
    }
}
