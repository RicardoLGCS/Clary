using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clary
{
    class TerminateClary : Commands
    {
        public TerminateClary()
        {
            sSemanticKey = "exitProgram";
        }
        public override string SemanticKey
        {
            get
            {
                return sSemanticKey; //Returning the sSemanticKey to the main form
            }
        }
        public override string LabelMessage 
        {
            get
            {
                return null;
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
            clarySpeak("Shutting down internal system, good");
            clarySpeak("bye");
            Environment.Exit(0);
            throw new NotImplementedException();
        }
    }
}
