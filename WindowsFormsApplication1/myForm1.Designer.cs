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
            this.stateButton1 = new StateButton.StateButton();
            this.baseButton1 = new SimpleButtonLib.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.baseButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // stateButton1
            // 
            this.stateButton1.BackColor = System.Drawing.Color.Transparent;
            this.stateButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stateButton1.BackgroundImage")));
            this.stateButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stateButton1.ButtonState = 1;
            this.stateButton1.Location = new System.Drawing.Point(62, 173);
            this.stateButton1.Name = "stateButton1";
            this.stateButton1.OnForeColor = System.Drawing.Color.White;
            this.stateButton1.OnMyFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stateButton1.OnNormalImage = ((System.Drawing.Image)(resources.GetObject("stateButton1.OnNormalImage")));
            this.stateButton1.OnPushedImage = ((System.Drawing.Image)(resources.GetObject("stateButton1.OnPushedImage")));
            this.stateButton1.OnText = "StateButton1";
            this.stateButton1.SelectImage = ((System.Drawing.Image)(resources.GetObject("stateButton1.SelectImage")));
            this.stateButton1.Size = new System.Drawing.Size(100, 50);
            this.stateButton1.StateMax = 1;
            this.stateButton1.TabIndex = 1;
            // 
            // baseButton1
            // 
            this.baseButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.baseButton1.Image = ((System.Drawing.Image)(resources.GetObject("baseButton1.Image")));
            this.baseButton1.Location = new System.Drawing.Point(89, 80);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.NormalImage")));
            this.baseButton1.PushedImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.PushedImage")));
            this.baseButton1.SelectImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.SelectImage")));
            this.baseButton1.Size = new System.Drawing.Size(100, 50);
            this.baseButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.baseButton1.TabIndex = 0;
            this.baseButton1.TabStop = false;
            // 
            // myForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.stateButton1);
            this.Controls.Add(this.baseButton1);
            this.Name = "myForm1";
            this.Text = "myForm1";
            ((System.ComponentModel.ISupportInitialize)(this.baseButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButtonLib.BaseButton baseButton1;
        private StateButton.StateButton stateButton1;
    }
}