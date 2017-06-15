namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageButton1 = new ImageButtonLib.ImageButton();
            this.interface1 = new HAPTIVITYLib.Interface();
            this.toggleButton2 = new ToggleButton.ToggleButton();
            this.formSupportUtils1 = new FormSupportLib.FormSupportUtils();
            this.imageButton2 = new ImageButtonLib.ImageButton();
            this.toggleButton1 = new ToggleButton.ToggleButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageButton1
            // 
            this.imageButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.imageButton1.ConfigNo = 0;
            this.imageButton1.EnterConfigNo = 0;
            this.imageButton1.EnterVibrationTime = 15;
            this.imageButton1.Haptivity = this.interface1;
            this.imageButton1.Image = global::WindowsFormsApplication1.Properties.Resources.Home_0;
            this.imageButton1.Location = new System.Drawing.Point(12, 12);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.NormalImage = global::WindowsFormsApplication1.Properties.Resources.Home_0;
            this.imageButton1.PushedImage = global::WindowsFormsApplication1.Properties.Resources.Home_2;
            this.imageButton1.SelectImage = global::WindowsFormsApplication1.Properties.Resources.Home_1;
            this.imageButton1.Size = new System.Drawing.Size(120, 48);
            this.imageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton1.TabIndex = 3;
            this.imageButton1.TabStop = false;
            this.imageButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // interface1
            // 
            this.interface1.BackColor = System.Drawing.Color.Transparent;
            this.interface1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("interface1.BackgroundImage")));
            this.interface1.Enabled = false;
            this.interface1.Location = new System.Drawing.Point(211, 28);
            this.interface1.Name = "interface1";
            this.interface1.Size = new System.Drawing.Size(32, 32);
            this.interface1.TabIndex = 5;
            // 
            // toggleButton2
            // 
            this.toggleButton2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toggleButton2.ConfigNo = 0;
            this.toggleButton2.ConfigOnNo = 0;
            this.toggleButton2.EnterConfigNo = 0;
            this.toggleButton2.EnterVibrationTime = 15;
            this.toggleButton2.Haptivity = this.interface1;
            this.toggleButton2.Image = global::WindowsFormsApplication1.Properties.Resources.Button_Hum1B;
            this.toggleButton2.Location = new System.Drawing.Point(12, 207);
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.NormalImage = global::WindowsFormsApplication1.Properties.Resources.Button_Hum1B;
            this.toggleButton2.NormalOnImage = global::WindowsFormsApplication1.Properties.Resources.Button_Hum1F;
            this.toggleButton2.PushedImage = global::WindowsFormsApplication1.Properties.Resources.Button_Hum1D;
            this.toggleButton2.PushedOnImage = global::WindowsFormsApplication1.Properties.Resources.Button_Hum1D;
            this.toggleButton2.SelectImage = global::WindowsFormsApplication1.Properties.Resources.Button_Hum1TB;
            this.toggleButton2.SelectOnImage = global::WindowsFormsApplication1.Properties.Resources.Button_Hum1TF;
            this.toggleButton2.Size = new System.Drawing.Size(102, 54);
            this.toggleButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toggleButton2.TabIndex = 2;
            this.toggleButton2.TabStop = false;
            // 
            // formSupportUtils1
            // 
            this.formSupportUtils1.BackColor = System.Drawing.Color.Transparent;
            this.formSupportUtils1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("formSupportUtils1.BackgroundImage")));
            this.formSupportUtils1.Location = new System.Drawing.Point(153, 28);
            this.formSupportUtils1.Name = "formSupportUtils1";
            this.formSupportUtils1.Size = new System.Drawing.Size(32, 32);
            this.formSupportUtils1.TabIndex = 6;
            // 
            // imageButton2
            // 
            this.imageButton2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.imageButton2.ConfigNo = 0;
            this.imageButton2.EnterConfigNo = 0;
            this.imageButton2.EnterVibrationTime = 5000;
            this.imageButton2.Haptivity = this.interface1;
            this.imageButton2.Image = ((System.Drawing.Image)(resources.GetObject("imageButton2.Image")));
            this.imageButton2.Location = new System.Drawing.Point(32, 113);
            this.imageButton2.Name = "imageButton2";
            this.imageButton2.NormalImage = ((System.Drawing.Image)(resources.GetObject("imageButton2.NormalImage")));
            this.imageButton2.PushedImage = ((System.Drawing.Image)(resources.GetObject("imageButton2.PushedImage")));
            this.imageButton2.SelectImage = ((System.Drawing.Image)(resources.GetObject("imageButton2.SelectImage")));
            this.imageButton2.Size = new System.Drawing.Size(100, 50);
            this.imageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton2.TabIndex = 7;
            this.imageButton2.TabStop = false;
            this.imageButton2.OnReleaseButton += new System.EventHandler(this.imageButton2_OnReleaseButton);
            // 
            // toggleButton1
            // 
            this.toggleButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toggleButton1.ConfigNo = 0;
            this.toggleButton1.ConfigOnNo = 0;
            this.toggleButton1.EnterConfigNo = 0;
            this.toggleButton1.EnterVibrationTime = 15;
            this.toggleButton1.Haptivity = this.interface1;
            this.toggleButton1.Image = ((System.Drawing.Image)(resources.GetObject("toggleButton1.Image")));
            this.toggleButton1.Location = new System.Drawing.Point(169, 148);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.NormalImage")));
            this.toggleButton1.NormalOnImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.NormalOnImage")));
            this.toggleButton1.PushedImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.PushedImage")));
            this.toggleButton1.PushedOnImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.PushedOnImage")));
            this.toggleButton1.SelectImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.SelectImage")));
            this.toggleButton1.SelectOnImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.SelectOnImage")));
            this.toggleButton1.Size = new System.Drawing.Size(100, 50);
            this.toggleButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.toggleButton1.TabIndex = 8;
            this.toggleButton1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toggleButton1);
            this.Controls.Add(this.imageButton2);
            this.Controls.Add(this.imageButton1);
            this.Controls.Add(this.toggleButton2);
            this.Controls.Add(this.interface1);
            this.Controls.Add(this.formSupportUtils1);
            this.MinimumSize = new System.Drawing.Size(308, 312);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToggleButton.ToggleButton toggleButton2;
        private ImageButtonLib.ImageButton imageButton1;
        private HAPTIVITYLib.Interface interface1;
        private FormSupportLib.FormSupportUtils formSupportUtils1;
        private ImageButtonLib.ImageButton imageButton2;
        private ToggleButton.ToggleButton toggleButton1;
        private System.Windows.Forms.Label label1;
    }
}

