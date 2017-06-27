namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.baseButton2 = new SimpleButtonLib.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.baseButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // baseButton2
            // 
            this.baseButton2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.baseButton2.BaseButtonProperty.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage")));
            this.baseButton2.BaseButtonProperty.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage")));
            this.baseButton2.BaseButtonProperty.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage")));
            this.baseButton2.Image = ((System.Drawing.Image)(resources.GetObject("baseButton2.Image")));
            this.baseButton2.Location = new System.Drawing.Point(95, 146);
            this.baseButton2.Name = "baseButton2";
            this.baseButton2.Size = new System.Drawing.Size(120, 48);
            this.baseButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.baseButton2.TabIndex = 1;
            this.baseButton2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.baseButton2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.baseButton2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButtonLib.BaseButton baseButton2;
    }
}