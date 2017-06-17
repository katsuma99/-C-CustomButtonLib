namespace WindowsFormsApplication1
{
    partial class myForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myForm1));
            this.toggleButton2 = new ToggleButton.ToggleButton();
            this.simpleButton4 = new SimpleButtonLib.SimpleButton();
            this.simpleButton5 = new SimpleButtonLib.SimpleButton();
            this.toggleButton3 = new ToggleButton.ToggleButton();
            ((System.ComponentModel.ISupportInitialize)(this.simpleButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleButton5)).BeginInit();
            this.SuspendLayout();
            // 
            // toggleButton2
            // 
            this.toggleButton2.BackColor = System.Drawing.Color.Transparent;
            this.toggleButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toggleButton2.BackgroundImage")));
            this.toggleButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toggleButton2.Location = new System.Drawing.Point(31, 26);
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.OffSimpleButton = this.simpleButton4;
            this.toggleButton2.OnSimpleButton = this.simpleButton5;
            this.toggleButton2.Size = new System.Drawing.Size(100, 50);
            this.toggleButton2.TabIndex = 3;
            // 
            // simpleButton4
            // 
            this.simpleButton4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.simpleButton4.ConfigNo = 0;
            this.simpleButton4.EnterConfigNo = 0;
            this.simpleButton4.EnterVibrationTime = 10;
            this.simpleButton4.Haptivity = null;
            this.simpleButton4.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton4.Image")));
            this.simpleButton4.Location = new System.Drawing.Point(164, 62);
            this.simpleButton4.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.NormalImage = ((System.Drawing.Image)(resources.GetObject("simpleButton4.NormalImage")));
            this.simpleButton4.PushedImage = ((System.Drawing.Image)(resources.GetObject("simpleButton4.PushedImage")));
            this.simpleButton4.SelectImage = ((System.Drawing.Image)(resources.GetObject("simpleButton4.SelectImage")));
            this.simpleButton4.Size = new System.Drawing.Size(100, 50);
            this.simpleButton4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.simpleButton4.TabIndex = 1;
            this.simpleButton4.TabStop = false;
            this.simpleButton4.Text = "simpleButton4";
            // 
            // simpleButton5
            // 
            this.simpleButton5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.simpleButton5.ConfigNo = 0;
            this.simpleButton5.EnterConfigNo = 0;
            this.simpleButton5.EnterVibrationTime = 10;
            this.simpleButton5.Haptivity = null;
            this.simpleButton5.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.Image")));
            this.simpleButton5.Location = new System.Drawing.Point(58, 102);
            this.simpleButton5.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.NormalImage = ((System.Drawing.Image)(resources.GetObject("simpleButton5.NormalImage")));
            this.simpleButton5.PushedImage = ((System.Drawing.Image)(resources.GetObject("simpleButton5.PushedImage")));
            this.simpleButton5.SelectImage = ((System.Drawing.Image)(resources.GetObject("simpleButton5.SelectImage")));
            this.simpleButton5.Size = new System.Drawing.Size(100, 50);
            this.simpleButton5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.simpleButton5.TabIndex = 2;
            this.simpleButton5.TabStop = false;
            this.simpleButton5.Text = "simpleButton5";
            // 
            // toggleButton3
            // 
            this.toggleButton3.BackColor = System.Drawing.Color.Transparent;
            this.toggleButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toggleButton3.BackgroundImage")));
            this.toggleButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toggleButton3.Location = new System.Drawing.Point(96, 182);
            this.toggleButton3.Name = "toggleButton3";
            this.toggleButton3.Size = new System.Drawing.Size(100, 50);
            this.toggleButton3.TabIndex = 4;
            // 
            // myForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.toggleButton3);
            this.Controls.Add(this.toggleButton2);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.simpleButton4);
            this.Name = "myForm1";
            this.Text = "myForm1";
            ((System.ComponentModel.ISupportInitialize)(this.simpleButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleButton5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButtonLib.SimpleButton simpleButton1;
        private ToggleButton.ToggleButton toggleButton1;
        private SimpleButtonLib.SimpleButton simpleButton2;
        private SimpleButtonLib.SimpleButton simpleButton3;
        private SimpleButtonLib.SimpleButton simpleButton4;
        private SimpleButtonLib.SimpleButton simpleButton5;
        private ToggleButton.ToggleButton toggleButton2;
        private ToggleButton.ToggleButton toggleButton3;
    }
}