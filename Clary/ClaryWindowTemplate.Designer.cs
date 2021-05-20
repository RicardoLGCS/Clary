
namespace Clary
{
    partial class ClaryWindowTemplate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.windowBorder = new System.Windows.Forms.Panel();
            this.lblWindowName = new System.Windows.Forms.Label();
            this.windowBorderBottom = new System.Windows.Forms.Panel();
            this.windowBorderRight = new System.Windows.Forms.Panel();
            this.windowBorderLeft = new System.Windows.Forms.Panel();
            this.windowBody = new System.Windows.Forms.Panel();
            this.windowBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowBorder
            // 
            this.windowBorder.BackColor = System.Drawing.Color.LightBlue;
            this.windowBorder.Controls.Add(this.lblWindowName);
            this.windowBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.windowBorder.Location = new System.Drawing.Point(0, 0);
            this.windowBorder.Name = "windowBorder";
            this.windowBorder.Size = new System.Drawing.Size(754, 28);
            this.windowBorder.TabIndex = 1;
            // 
            // lblWindowName
            // 
            this.lblWindowName.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowName.ForeColor = System.Drawing.Color.Black;
            this.lblWindowName.Location = new System.Drawing.Point(0, 0);
            this.lblWindowName.Name = "lblWindowName";
            this.lblWindowName.Size = new System.Drawing.Size(754, 28);
            this.lblWindowName.TabIndex = 2;
            this.lblWindowName.Text = "Window Name";
            this.lblWindowName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWindowName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblWindowName_MouseDown);
            this.lblWindowName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblWindowName_MouseMove);
            this.lblWindowName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblWindowName_MouseUp);
            // 
            // windowBorderBottom
            // 
            this.windowBorderBottom.BackColor = System.Drawing.Color.LightBlue;
            this.windowBorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.windowBorderBottom.Location = new System.Drawing.Point(0, 313);
            this.windowBorderBottom.Name = "windowBorderBottom";
            this.windowBorderBottom.Size = new System.Drawing.Size(754, 10);
            this.windowBorderBottom.TabIndex = 2;
            // 
            // windowBorderRight
            // 
            this.windowBorderRight.BackColor = System.Drawing.Color.LightBlue;
            this.windowBorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.windowBorderRight.Location = new System.Drawing.Point(744, 28);
            this.windowBorderRight.Name = "windowBorderRight";
            this.windowBorderRight.Size = new System.Drawing.Size(10, 285);
            this.windowBorderRight.TabIndex = 3;
            // 
            // windowBorderLeft
            // 
            this.windowBorderLeft.BackColor = System.Drawing.Color.LightBlue;
            this.windowBorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.windowBorderLeft.Location = new System.Drawing.Point(0, 28);
            this.windowBorderLeft.Name = "windowBorderLeft";
            this.windowBorderLeft.Size = new System.Drawing.Size(10, 285);
            this.windowBorderLeft.TabIndex = 4;
            // 
            // windowBody
            // 
            this.windowBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowBody.Location = new System.Drawing.Point(10, 28);
            this.windowBody.Name = "windowBody";
            this.windowBody.Size = new System.Drawing.Size(734, 285);
            this.windowBody.TabIndex = 5;
            // 
            // ClaryWindowTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(754, 323);
            this.Controls.Add(this.windowBody);
            this.Controls.Add(this.windowBorderLeft);
            this.Controls.Add(this.windowBorderRight);
            this.Controls.Add(this.windowBorderBottom);
            this.Controls.Add(this.windowBorder);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClaryWindowTemplate";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.ClaryWindowTemplate_Load);
            this.windowBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel windowBorder;
        private System.Windows.Forms.Label lblWindowName;
        private System.Windows.Forms.Panel windowBorderBottom;
        private System.Windows.Forms.Panel windowBorderRight;
        private System.Windows.Forms.Panel windowBorderLeft;
        private System.Windows.Forms.Panel windowBody;
    }
}