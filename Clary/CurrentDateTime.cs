using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clary
{
    class CurrentDateTime : Commands
    {
        public CurrentDateTime()
        {
            sSemanticKey = "currentDateTime";
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
                return sLabelMessage;
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
            if (sSemanticValue == "currentTime")
            {
                sLabelMessage = DateTime.Now.ToString("hh:m tt");
                DefaultCommandSettings($"It is currently {sLabelMessage}", targetForm);
                messageTimer.Start();
            }
            else
            {
                sLabelMessage = DateTime.UtcNow.ToString("D") + ", " + DateTime.UtcNow.ToString("dddd");
                DefaultCommandSettings($"Today is {sLabelMessage}", targetForm);
                messageTimer.Start();
            }
            return MessageDisplayObj;
        }

        //public override MessageDisplay UndoExecuteCommand(string sSemanticValue, Form1 targetForm, Timer messageTimer)
        //{
        //    MessageBox.Show("Estavas certo");
        //    DefaultCommandSettings("Entrou sim skrtttt", targetForm);
        //    sLabelMessage = "Esperava o q";
        //    messageTimer.Start();
        //    return base.UndoExecuteCommand(sSemanticValue, targetForm, messageTimer);
        //}
    }
}
