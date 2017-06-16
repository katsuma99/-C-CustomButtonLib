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
            this.simpleButton1 = new SimpleButtonLib.SimpleButton();
            this.textBaseButton1 = new SimpleButtonLib.TextBaseButton();
            this.toggleButton1 = new ToggleButton.ToggleButton();
            ((System.ComponentModel.ISupportInitialize)(this.simpleButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBaseButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.simpleButton1.ConfigNo = 0;
            this.simpleButton1.EnterConfigNo = 0;
            this.simpleButton1.EnterVibrationTime = 10;
            this.simpleButton1.Haptivity = null;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(73, 136);
            this.simpleButton1.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("simpleButton1.NormalImage")));
            this.simpleButton1.PushedImage = ((System.Drawing.Image)(resources.GetObject("simpleButton1.PushedImage")));
            this.simpleButton1.SelectImage = ((System.Drawing.Image)(resources.GetObject("simpleButton1.SelectImage")));
            this.simpleButton1.Size = new System.Drawing.Size(100, 50);
            this.simpleButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.TabStop = false;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // textBaseButton1
            // 
            this.textBaseButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBaseButton1.Image = ((System.Drawing.Image)(resources.GetObject("textBaseButton1.Image")));
            this.textBaseButton1.Location = new System.Drawing.Point(73, 68);
            this.textBaseButton1.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.textBaseButton1.Name = "textBaseButton1";
            this.textBaseButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("textBaseButton1.NormalImage")));
            this.textBaseButton1.PushedImage = ((System.Drawing.Image)(resources.GetObject("textBaseButton1.PushedImage")));
            this.textBaseButton1.SelectImage = ((System.Drawing.Image)(resources.GetObject("textBaseButton1.SelectImage")));
            this.textBaseButton1.Size = new System.Drawing.Size(100, 50);
            this.textBaseButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.textBaseButton1.TabIndex = 0;
            this.textBaseButton1.TabStop = false;
            this.textBaseButton1.Text = "textBaseButton1";
            // 
            // toggleButton1
            // 
            this.toggleButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toggleButton1.Location = new System.Drawing.Point(73, 203);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.Size = new System.Drawing.Size(100, 50);
            this.toggleButton1.TabIndex = 2;
            // 
            // myForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.toggleButton1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.textBaseButton1);
            this.Name = "myForm1";
            this.Text = "myForm1";
            ((System.ComponentModel.ISupportInitialize)(this.simpleButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBaseButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButtonLib.TextBaseButton textBaseButton1;
        private SimpleButtonLib.SimpleButton simpleButton1;
        private ToggleButton.ToggleButton toggleButton1;
    }
}