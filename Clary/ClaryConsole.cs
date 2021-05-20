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
                RTB.AppendText("\n<User> ");
                RTB.Select(0, RTB.Text.Length);
                RTB.SelectionProtected = true;
                RTB.Focus();
                RTB.Select(0, 0);
            }
        }
    }
}
