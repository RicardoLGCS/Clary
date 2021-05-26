using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clary
{
    class Memos : Commands
    {
        DateTimePicker DTP = new DateTimePicker();
        TextBox TB = new TextBox();
        Button BTN = new Button();
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
                WindowTemplate.changeLblWindowName("Add Memo");

                BTN.BackColor = Color.White;
                BTN.Text = "Submit";
                BTN.ForeColor = Color.Black;
                BTN.Size = new Size(100, BTN.Height);
                BTN.Name = "btnSubmit";
                BTN.Click += OnClick;

                TB.BackColor = Color.White;
                TB.Size = new Size(DTP.Width, TB.Height);
                TB.Name = "txtMemoTitle";

                TB.Location = new Point((WindowTemplate.cWindowBody.Width / 2) - (TB.Width + 10), (WindowTemplate.cWindowBody.Height / 2) - TB.Height);
                DTP.Location = new Point((WindowTemplate.cWindowBody.Width / 2) + 10, (WindowTemplate.cWindowBody.Height / 2) - DTP.Height);
                BTN.Location = new Point((WindowTemplate.cWindowBody.Width / 2) - (BTN.Width / 2), (WindowTemplate.cWindowBody.Height - 75));

                WindowTemplate.cWindowBody.Controls.AddRange(new Control[] { DTP, TB, BTN });
                WindowTemplate.Show(targetForm);
            }
            else
            {
                DefaultCommandSettings("Displaying memos", targetForm);
                sLabelMessage = "Displaying memos";
                messageTimer.Start();
            }
            return MessageDisplayObj;
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (TB.Text == "")
            {
                MessageBox.Show("Please insert the memo title");
            }
            MessageBox.Show(TB.Text);
            MessageBox.Show(DTP.Value.ToString().Substring(0,9));
        }
    }
}
