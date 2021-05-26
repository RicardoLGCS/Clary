using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clary
{
    class ClaryConsole
    {
        ClaryWindowTemplate AppTemplate = new ClaryWindowTemplate();
        RichTextBox RTB = new RichTextBox();
        public ClaryConsole() { }

        public ClaryConsole(Form targetForm)
        {
            RTB.ForeColor = Color.LimeGreen;
            RTB.BackColor = Color.Black;
            RTB.Font = new Font("Century Gothic", 10);
            RTB.Multiline = true;
            RTB.BorderStyle = BorderStyle.None;
            RTB.Size = new Size(AppTemplate.cWindowBody.Width, AppTemplate.cWindowBody.Height);
            RTB.Text = "<User> ";
            RTB.Select(0, RTB.Text.Length);
            RTB.SelectionProtected = true;
            RTB.Select(0,0);
            AppTemplate.changeLblWindowName("Clary Console");
            AppTemplate.cWindowBody.Controls.Add(RTB);
            AppTemplate.Show(targetForm);
            RTB.KeyDown += OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == 13) //If key pressed is equal to ENTER
            {
                for (int i = 0; i < RTB.Lines.Length; i++)
                {
                    if (i == (RTB.Lines.Length - 1) && RTB.Lines[(RTB.Lines.Length - 1)] != " ")
                    {
                        AppendTextToClaryConsole(RTB.Lines[i].Substring(7));
                        e.Handled = true; //Prevent the RichTextBox from making a new line
                    }
                }
                RTB.AppendText("\n<User> ");
                RTB.Select(0, RTB.Text.Length);
                RTB.SelectionProtected = true;
                RTB.Select(0, 0);
                RTB.SelectionStart = RTB.Text.Length;
                RTB.ScrollToCaret();
            }
        }

        public void AppendTextToClaryConsole(string sTextToAppend)
        {
            switch (sTextToAppend)
            {
                case "crt":
                    RTB.AppendText("\n Este é o teste");
                    break;
            }
        }
    }
}
