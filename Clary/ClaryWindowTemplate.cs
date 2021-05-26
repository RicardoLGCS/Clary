using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clary
{
    public partial class ClaryWindowTemplate : Form
    {
        bool bMouseDown;
        int ilblWindowNameMouseLocationX, ilblWindowNameMouseLocationY;
        public Control cWindowBody;
        Label lblWindowNameToChange;
        public ClaryWindowTemplate()
        {
            InitializeComponent();
            cWindowBody = windowBody;
        }

        private void ClaryWindowTemplate_Load(object sender, EventArgs e)
        {
            lblWindowNameToChange = lblWindowName;
            this.Opacity = .85;
        }

        private void lblWindowName_MouseUp(object sender, MouseEventArgs e)
        {
            bMouseDown = false;
        }

        private void lblWindowName_MouseMove(object sender, MouseEventArgs e)
        {
            if (bMouseDown)
            {
                int XA = MousePosition.X;
                int YA = MousePosition.Y;
                this.Location = new Point(XA - ilblWindowNameMouseLocationX, YA - ilblWindowNameMouseLocationY);
            }
        }

        private void lblWindowName_MouseDown(object sender, MouseEventArgs e)
        {
            ilblWindowNameMouseLocationX = e.Location.X;
            ilblWindowNameMouseLocationY = e.Location.Y;
            
            bMouseDown = true;
        }

        public void changeLblWindowName(string name)
        {
            lblWindowName.Text = name;
        }
    }
}
