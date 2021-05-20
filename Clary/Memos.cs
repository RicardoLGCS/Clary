using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clary
{
    class Memos : Commands
    {
        public Memos()
        {
            sSemanticKey = "claryMemos";
        }

        public override string SemanticKey
        {
            get
            {
                return sSemanticKey;
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
            if(sSemanticValue == "addMemo")
            {
                DefaultCommandSettings("Opening window", targetForm);
                sLabelMessage = "Opening window";
                messageTimer.Start();
                ClaryConsole cc = new ClaryConsole(targetForm);
            }
            else
            {
                DefaultCommandSettings("Displaying memos", targetForm);
                sLabelMessage = "Displaying memos";
                messageTimer.Start();
            }
            return MessageDisplayObj;
        }
    }
}
