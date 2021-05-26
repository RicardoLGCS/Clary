using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clary
{
    class MessageDisplay
    {
        private Label lblMessage;
        private int iMessageChars, iMessageCounter;

        public MessageDisplay()
        {
            lblMessage = new Label();
        }

        //Overloading the method createMessageLabel in case something wanted to be changed
        public void createMessageLabel(Form TargetForm, int iFontSize = 32, int iLabelWidth = 750, int iLabelHeight = 75)
        {
            lblMessage.Font = new Font("Century Gothic", iFontSize);
            lblMessage.Size = new Size(iLabelWidth, iLabelHeight);
            lblMessage.BorderStyle = BorderStyle.None;
            lblMessage.ForeColor = Color.LightBlue;
            lblMessage.Name = "lblMessage";
            lblMessage.Location = new Point(((Screen.PrimaryScreen.Bounds.Width / 2) - (lblMessage.Width / 2)), ((Screen.PrimaryScreen.Bounds.Height / 5) - (lblMessage.Height / 2)));
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            foreach (Control control in TargetForm.Controls)
            {
                if (control.Name == "lblMessage")
                {
                    TargetForm.Controls.Remove(control);
                }
            }
            TargetForm.Controls.Add(lblMessage);

        }

        public void writeMessageByChar(Timer messageTimer, string sMessage, Form TargetForm)
        {
            iMessageCounter++;
            if (iMessageChars < sMessage.Length)
            {
                iMessageChars++;
                lblMessage.Text = sMessage.Substring(0, iMessageChars);
            }
            if (iMessageCounter == 80) //80 is equivalent to 4s (1000ms = 1s and 50ms * 20 = 1000ms so 80 / 20 = 4s) Because 1 sec has 20 ticks
            {
                lblMessage.Text = "";
                TargetForm.Controls.Remove(lblMessage);
                sMessage = "";
                messageTimer.Stop();
                iMessageChars = 0;
                iMessageCounter = 0;
            }
        }
    }
}
