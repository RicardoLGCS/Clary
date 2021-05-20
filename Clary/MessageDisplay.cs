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
        public void createMessageLabel(int iFontSize, int iLabelWidth, int iLabelHeight, Form TargetForm)
        {
            lblMessage.Font = new Font("Century Gothic", iFontSize);
            lblMessage.Size = new Size(iLabelWidth, iLabelHeight);
            lblMessage.BorderStyle = BorderStyle.None;
            lblMessage.ForeColor = Color.LightBlue;
            lblMessage.Location = new Point(((Screen.PrimaryScreen.Bounds.Width / 2) - (lblMessage.Width / 2)), ((Screen.PrimaryScreen.Bounds.Height / 5) - (lblMessage.Height / 2)));
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            TargetForm.Controls.Add(lblMessage);
        }

        public void createMessageLabel(int iFontSize, Form TargetForm)
        {
            lblMessage.Font = new Font("Century Gothic", iFontSize);
            lblMessage.Size = new Size(750, 75);
            lblMessage.BorderStyle = BorderStyle.None;
            lblMessage.ForeColor = Color.LightBlue;
            lblMessage.Location = new Point(((Screen.PrimaryScreen.Bounds.Width / 2) - (lblMessage.Width / 2)), ((Screen.PrimaryScreen.Bounds.Height / 5) - (lblMessage.Height / 2)));
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            TargetForm.Controls.Add(lblMessage);
        }

        public void createMessageLabel(Form TargetForm)
        {
            lblMessage.Font = new Font("Century Gothic", 32);
            lblMessage.Size = new Size(750, 75);
            lblMessage.BorderStyle = BorderStyle.None;
            lblMessage.ForeColor = Color.LightBlue;
            lblMessage.Location = new Point(((Screen.PrimaryScreen.Bounds.Width / 2) - (lblMessage.Width / 2)), ((Screen.PrimaryScreen.Bounds.Height / 5) - (lblMessage.Height / 2)));
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
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
            if (iMessageCounter == 80) //80 is equivalent to 4s (1000ms = 1s and 50ms * 20 = 1000ms so 80 / 20 = 4s)
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
