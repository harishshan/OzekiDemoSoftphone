using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ozeki.Media;

namespace OzekiDemoSoftphoneWPF.Model
{
    public class HSpeechRecognitionEngine : ISpeechToText
    {
        private AudioFormat _audioFormat;
        private SpeechRecognitionEngine _recognition;
        private SpeechAudioFormatInfo _speechFormat;
        private ManualResetEvent manualResetEvent;
        private object _sync;
        public HSpeechRecognitionEngine()
        {
            _sync = new object();
        }
        public string Name
        {
            get { return "HSpeechRecognitionEngine"; }
        }

        public SpeechRecognizerInfo RecognizerInfo
        {
            get
            {
                var info = new SpeechRecognizerInfo();
                if (_recognition == null)
                    return info;

                return GetRecognizerInfo(_recognition.RecognizerInfo);
            }
        }

        public bool Initialized { get; private set; }

        public event EventHandler<SpeechDetectionEventArgs> WordRecognized;
        public event EventHandler<SpeechDetectionEventArgs> WordHypothesized;
        public event EventHandler SpeechDetected;
        public event EventHandler RecognitionCompleted;

        public bool Init(AudioFormat audioFormat, IEnumerable<string> choices)
        {
            _audioFormat = audioFormat;
            return InitSTT();
        }

        public void StartRecognition(Stream stream)
        {
            Console.WriteLine("StartRecognition");
            manualResetEvent = new ManualResetEvent(false);
            _recognition.SetInputToAudioStream(stream, _speechFormat);
            _recognition.RecognizeAsync(RecognizeMode.Multiple);
            //manualResetEvent.WaitOne();
        }
        public void StopRecognition()
        {
            Console.WriteLine("StopRecognition");
            //lock (_sync)
            //{
            //    if (_recognition == null)
            //        return;
            //    _recognition.RecognizeAsyncStop();
            //}
        }

        public IEnumerable<SpeechRecognizerInfo> GetRecognizers()
        {
            var list = new List<SpeechRecognizerInfo>();

            var installed = SpeechRecognitionEngine.InstalledRecognizers();
            foreach (var sr in installed)
            {
                var info = GetRecognizerInfo(sr);
                list.Add(info);
            }

            return list;
        }
        private SpeechRecognizerInfo GetRecognizerInfo(RecognizerInfo recognizerInfo)
        {
            var info = new SpeechRecognizerInfo();
            info.ID = recognizerInfo.Id;
            info.Name = recognizerInfo.Name;
            info.Culture = recognizerInfo.Culture;
            foreach (var format in recognizerInfo.SupportedAudioFormats)
                info.SupportedAudioFormats.Add(new AudioFormat(format.SamplesPerSecond, format.ChannelCount, format.BitsPerSample));
            return info;
        }
        public bool ChangeRecognizer(string recognizerID)
        {
            if (!Initialized)
                return false;

            StopRecognition();
            CloseSTT();
            return InitSTT(recognizerID);
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose");
            CloseSTT();
        }
        public bool InitSTT(string recognizerID = null)
        {
            try
            {
                Console.Write("InitSTT");
                Initialized = false;
                var RecognizerInfoLit = SpeechRecognitionEngine.InstalledRecognizers();
                _recognition = new SpeechRecognitionEngine(new CultureInfo("en-US"));
                _recognition.LoadGrammar(new Grammar(new GrammarBuilder("exit")));
                _recognition.LoadGrammar(new DictationGrammar());
                loadAdditionalGrammer(_recognition);

                //_recognition.BabbleTimeout = new TimeSpan(0);
               // _recognition.InitialSilenceTimeout = new TimeSpan(0);

                _recognition.SpeechHypothesized += recognition_SpeechHypothesized;
                _recognition.SpeechRecognized += recognition_SpeechRecognized;
                _recognition.SpeechDetected += recognition_SpeechDetected;
                _recognition.RecognizeCompleted += recognition_RecognizeCompleted;
                _recognition.SpeechRecognitionRejected += (recognition_SpeechRecognizedRejected);
                _speechFormat = new SpeechAudioFormatInfo(_audioFormat.SampleRate, (AudioBitsPerSample)_audioFormat.BitRate, (AudioChannel)_audioFormat.Channels);
                //_recognition.UnloadAllGrammars();
                Initialized = true;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }
        public void loadAdditionalGrammer(SpeechRecognitionEngine sre)
        {
            Console.Write("loadAdditionalGrammer");
            DictationGrammar spellingDictationGrammar = new DictationGrammar("grammar:dictation#spelling");
            spellingDictationGrammar.Enabled = true;
            DictationGrammar customDictationGrammar = new DictationGrammar("grammar:dictation");
            customDictationGrammar.Enabled = true;
            sre.LoadGrammar(spellingDictationGrammar);
            sre.LoadGrammar(customDictationGrammar);
        }
        private void CloseSTT()
        {
            Console.Write("CloseSTT");
            if (!Initialized)
                return;

            _recognition.RecognizeCompleted -= recognition_RecognizeCompleted;
            _recognition.SpeechDetected -= recognition_SpeechDetected;
            _recognition.SpeechRecognized -= recognition_SpeechRecognized;
            _recognition.SpeechHypothesized -= recognition_SpeechHypothesized;
            _recognition.Dispose();
            _recognition = null;
            Initialized = false;
        }

        void recognition_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            foreach (var word in e.Result.Words)
            {
                Console.Write("Hypothesized:" + word);
                OnWordRecognized(word.Text, word.Confidence);
            }
        }
        private void OnWordHypothesized(string word, float confidence)
        {
            var handler = WordHypothesized;
            if (handler != null)
                handler(this, new SpeechDetectionEventArgs(word, confidence));
        }
        void recognition_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (var word in e.Result.Words)
            {
                Console.Write("Recognized:" + word);
                OnWordRecognized(word.Text, word.Confidence);
               // manualResetEvent.Set();
            }
        }
        private void OnWordRecognized(string word, float confidence)
        {
            var handler = WordRecognized;
            if (handler != null)
                handler(this, new SpeechDetectionEventArgs(word, confidence));
        }
        void recognition_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            Console.Write("recognition_SpeechDetected");
            OnSpeechDetected();
        }
        private void OnSpeechDetected()
        {
            var handler = SpeechDetected;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        void recognition_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            Console.Write("recognition_RecognizeCompleted");
            OnRecognitionCompleted();
        }
        private void OnRecognitionCompleted()
        {
            var handler = RecognitionCompleted;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        void recognition_SpeechRecognizedRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Console.WriteLine("recognition_SpeechRecognizedRejected");
            foreach (RecognizedPhrase phrase in e.Result.Alternates)
            {
                Console.WriteLine("  Rejected phrase: " + phrase.Text+ "  Confidence score: " + phrase.Confidence);
                App.window.SubTitle = App.window.SubTitle + " " + phrase.Text;
            }
        }
    }
}
