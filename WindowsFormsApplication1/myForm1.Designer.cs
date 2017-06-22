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
            this.label1 = new System.Windows.Forms.Label();
            this.baseButton1 = new SimpleButtonLib.BaseButton();
            this.baseButton2 = new SimpleButtonLib.BaseButton();
            this.baseButton3 = new SimpleButtonLib.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.baseButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseButton3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // baseButton1
            // 
            this.baseButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.baseButton1.BaseButtonProperty.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage")));
            this.baseButton1.BaseButtonProperty.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage")));
            this.baseButton1.BaseButtonProperty.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage")));
            this.baseButton1.BaseButtonProperty.State = SimpleButtonLib.State.Push;
            this.baseButton1.Image = ((System.Drawing.Image)(resources.GetObject("baseButton1.Image")));
            this.baseButton1.Location = new System.Drawing.Point(51, 82);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.Size = new System.Drawing.Size(32, 32);
            this.baseButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.baseButton1.TabIndex = 2;
            this.baseButton1.TabStop = false;
            // 
            // baseButton2
            // 
            this.baseButton2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.baseButton2.BaseButtonProperty.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage1")));
            this.baseButton2.BaseButtonProperty.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage1")));
            this.baseButton2.BaseButtonProperty.State = SimpleButtonLib.State.Push;
            this.baseButton2.Image = ((System.Drawing.Image)(resources.GetObject("baseButton2.Image")));
            this.baseButton2.Location = new System.Drawing.Point(110, 41);
            this.baseButton2.Name = "baseButton2";
            this.baseButton2.Size = new System.Drawing.Size(32, 32);
            this.baseButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.baseButton2.TabIndex = 4;
            this.baseButton2.TabStop = false;
            // 
            // baseButton3
            // 
            this.baseButton3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.baseButton3.BaseButtonProperty.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage2")));
            this.baseButton3.BaseButtonProperty.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage2")));
            this.baseButton3.BaseButtonProperty.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage1")));
            this.baseButton3.BaseButtonProperty.State = SimpleButtonLib.State.Select;
            this.baseButton3.Image = ((System.Drawing.Image)(resources.GetObject("baseButton3.Image")));
            this.baseButton3.Location = new System.Drawing.Point(82, 106);
            this.baseButton3.Name = "baseButton3";
            this.baseButton3.Size = new System.Drawing.Size(32, 32);
            this.baseButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.baseButton3.TabIndex = 6;
            this.baseButton3.TabStop = false;
            // 
            // myForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.baseButton3);
            this.Controls.Add(this.baseButton2);
            this.Controls.Add(this.baseButton1);
            this.Controls.Add(this.label1);
            this.Name = "myForm1";
            this.Text = "myForm1";
            ((System.ComponentModel.ISupportInitialize)(this.baseButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseButton3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private SimpleButtonLib.BaseButton baseButton1;
        private SimpleButtonLib.BaseButton baseButton2;
        private SimpleButtonLib.BaseButton baseButton3;
    }
}