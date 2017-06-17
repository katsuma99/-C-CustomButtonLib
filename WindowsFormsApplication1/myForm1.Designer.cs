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
            this.toggleButton1 = new ToggleButton.ToggleButton();
            this.SuspendLayout();
            // 
            // toggleButton1
            // 
            this.toggleButton1.BackColor = System.Drawing.Color.Transparent;
            this.toggleButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.BackgroundImage")));
            this.toggleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toggleButton1.ConfigNo = 0;
            this.toggleButton1.EnterConfigNo = 0;
            this.toggleButton1.EnterVibrationTime = 10;
            this.toggleButton1.Haptivity = null;
            this.toggleButton1.IsToggleOn = true;
            this.toggleButton1.Location = new System.Drawing.Point(90, 104);
            this.toggleButton1.MyFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OnNormalImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OnNormalImage")));
            this.toggleButton1.OnPushedImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OnPushedImage")));
            this.toggleButton1.OnSelectImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OnSelectImage")));
            this.toggleButton1.Size = new System.Drawing.Size(103, 54);
            this.toggleButton1.TabIndex = 0;
            // 
            // myForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.toggleButton1);
            this.Name = "myForm1";
            this.Text = "myForm1";
            this.ResumeLayout(false);

        }

        #endregion

        private ToggleButton.ToggleButton toggleButton1;
    }
}