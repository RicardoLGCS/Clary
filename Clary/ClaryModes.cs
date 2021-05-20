using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;

namespace Clary
{
    class ClaryModes : Commands
    {
        bool bIsRecognitionOn;
        public ClaryModes()
        {
            sSemanticKey = "claryModes"; //When a new instance of this classe is created te value for the semantickey variable will be attributed with the same in the grammar
            bIsRecognitionOn = true;
        }

        public override string SemanticKey {
            get
            {
                return sSemanticKey; //Returning the sSemanticKey to the main form
            }
        }

        public override string LabelMessage
        {
            get
            {
                return this.sLabelMessage;
            }
        }

        public override SpeechSynthesizer getClary
        {
            get
            {
                return _clary;
            }
        }

        public override MessageDisplay ExecuteCommand(string sSemanticValue, Form targetForm, Timer messageTimer)
        {
            if(sSemanticValue == "sleepMode")
            {
                bIsRecognitionOn = false;
                DefaultCommandSettings("Switching to sleep mode, i will be here if you need me", targetForm);
                sLabelMessage = "Switching to sleep mode";
                messageTimer.Start();
            }
            return MessageDisplayObj;
        }

        public MessageDisplay UndoExecuteCommand(string sSemanticValue, Form targetForm, Timer messageTimer)
        {
            if (sSemanticValue == "normalMode")
            {
                bIsRecognitionOn = true;
                _recognizerSleep.RecognizeAsyncStop();
                DefaultCommandSettings("Switching to normal mode, how can i help?", targetForm);
                sLabelMessage = "Switching to normal mode";
                messageTimer.Start();
            }
            return MessageDisplayObj;
        }

        public void OnSpeakCompletion(object sender, SpeakCompletedEventArgs e)
        {
            //This will always repeat after completion of a Speech Synthesizer to prevent the program from listening to itself
            if (bIsRecognitionOn)
            {
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                _recognizerSleep.RecognizeAsync(RecognizeMode.Multiple);
            }
        }

        internal void OnSpeakStart(object sender, SpeakStartedEventArgs e)
        {
            _recognizer.RecognizeAsyncStop();
        }
    }
}
