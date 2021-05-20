using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clary
{
    class Clary
    {
        //Declaring variables
        protected SpeechSynthesizer _clary = new SpeechSynthesizer();
        //private string sWelcomeMessage = "Hello " + Environment.UserName + ", my name is clary, how may i help you?";
        private string sWelcomeMessage = "gentlemans, how can i be useful?";
        public SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        public SpeechRecognitionEngine _recognizerSleep = new SpeechRecognitionEngine();
        private static string sGrammarPath = @"../../claryGrammar.xml";
        Grammar claryGrammar = new Grammar(sGrammarPath);
        Grammar clarySleepGrammar = new Grammar(sGrammarPath);
        string sTime, sWelcomeMessageBeginning;
        int iHours;
        public Clary()
        {
            recognitionSetup();
            _clary.SelectVoice("Microsoft Hazel Desktop");
        }

        public SpeechSynthesizer clary
        {
            get
            {
                return _clary;
            }
        }

        public void claryStart()
        {
            sTime = DateTime.Now.ToString("HH tt"); //Getting the current hours
            iHours = Convert.ToInt16(sTime.Substring(0,2)); //Converting hours to int
            if(iHours >= 6 && iHours < 12)
            {
                sWelcomeMessageBeginning = "Good morning";
            }
            else if ((iHours >= 12 && iHours <= 18))
            {
                sWelcomeMessageBeginning = "Good afternoon";
            }
            else if(iHours < 6 || iHours >= 19)
            {
                sWelcomeMessageBeginning = "Good night";
            }
            clarySpeakAsync($"{sWelcomeMessageBeginning} {sWelcomeMessage}");
        }

        protected void clarySpeakAsync(string message)
        {
            _clary.SpeakAsync(message);
        }

        protected void clarySpeak(string message)
        {
            _clary.Speak(message);
        }

        private void loadGrammars()
        {
            _recognizer.LoadGrammar(claryGrammar);
            _recognizerSleep.LoadGrammar(clarySleepGrammar);
        }

        private void recognitionSetup() //Load the grammars, set the InputAudioDevice and turn on recognition
        {
            loadGrammars();
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizerSleep.SetInputToDefaultAudioDevice();
        }
    }
}
