using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clary
{
    abstract class Commands : Clary
    {
        protected string sSemanticKey; //Each children will have a different value to match with the grammar file
        protected MessageDisplay MessageDisplay = new MessageDisplay();
        protected ClaryWindowTemplate WindowTemplate = new ClaryWindowTemplate();
        protected string sLabelMessage;

        //Creating a get to return the object itself to the main form
        public MessageDisplay MessageDisplayObj { 
            get
            {
                return MessageDisplay;
            } 
        }

        //Abstract makes all the childrens that inherits this class to have this method
        public abstract MessageDisplay ExecuteCommand(string sSemanticValue, Form targetForm, Timer messageTimer); 
        public abstract string SemanticKey { get; } //Each class that inherits from this one will have a unique SemanticKey declared on them (sort of an identifier for speech recognizer)
        public abstract string LabelMessage { get; } //Each command will have a different message
        public abstract SpeechSynthesizer getClary { get; } //Returning the _clary object from each one of this commands children to activate speech recognition after speech synthesizer is done

        public void DefaultCommandSettings(string sClarySpeakText, Form targetForm)
        {
            MessageDisplay.createMessageLabel(targetForm);
            clarySpeakAsync(sClarySpeakText);
        }
    }
}
