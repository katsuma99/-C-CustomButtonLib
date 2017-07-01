namespace WindowsFormsApplication3
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
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.toggleButton1 = new ToggleButton.ToggleButton();
            this.stateButton1 = new StateButton.StateButton();
            this.textBaseButton1 = new SimpleButtonLib.TextBaseButton();
            this.simpleButton1 = new SimpleButtonLib.SimpleButton();
            this.baseButton1 = new SimpleButtonLib.BaseButton();
            ((System.ComponentModel.ISupportInitialize)(this.stateButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBaseButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // toggleButton1
            // 
            this.toggleButton1.BackColor = System.Drawing.Color.Transparent;
            this.toggleButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.BackgroundImage")));
            this.toggleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toggleButton1.IsToggleOn = false;
            this.toggleButton1.Location = new System.Drawing.Point(32, 132);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffMyFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toggleButton1.OffNormalImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OffNormalImage")));
            this.toggleButton1.OffPushedImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OffPushedImage")));
            this.toggleButton1.OffSelectImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OffSelectImage")));
            this.toggleButton1.OffText = "toggleButtonOff";
            this.toggleButton1.OnMyFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.toggleButton1.OnNormalImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OnNormalImage")));
            this.toggleButton1.OnPushedImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OnPushedImage")));
            this.toggleButton1.OnSelectImage = ((System.Drawing.Image)(resources.GetObject("toggleButton1.OnSelectImage")));
            this.toggleButton1.OnText = "toggleButtonOn";
            this.toggleButton1.Size = new System.Drawing.Size(100, 50);
            this.toggleButton1.TabIndex = 4;
            // 
            // stateButton1
            // 
            this.stateButton1.BackColor = System.Drawing.Color.Transparent;
            this.stateButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("stateButton1.BackgroundImage")));
            this.stateButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stateButton1.Button1.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage")));
            this.stateButton1.Button1.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage")));
            this.stateButton1.Button1.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage")));
            this.stateButton1.Button2.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage1")));
            this.stateButton1.Button2.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage1")));
            this.stateButton1.Button2.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage1")));
            this.stateButton1.Button3.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage2")));
            this.stateButton1.Button3.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage2")));
            this.stateButton1.Button3.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage2")));
            this.stateButton1.Button4.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage3")));
            this.stateButton1.Button4.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage3")));
            this.stateButton1.Button4.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage3")));
            this.stateButton1.Button5.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage4")));
            this.stateButton1.Button5.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage4")));
            this.stateButton1.Button5.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage4")));
            this.stateButton1.Button6.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage5")));
            this.stateButton1.Button6.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage5")));
            this.stateButton1.Button6.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage5")));
            this.stateButton1.Button7.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage6")));
            this.stateButton1.Button7.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage6")));
            this.stateButton1.Button7.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage6")));
            this.stateButton1.Button8.NormalImage = ((System.Drawing.Image)(resources.GetObject("resource.NormalImage7")));
            this.stateButton1.Button8.PushedImage = ((System.Drawing.Image)(resources.GetObject("resource.PushedImage7")));
            this.stateButton1.Button8.SelectImage = ((System.Drawing.Image)(resources.GetObject("resource.SelectImage7")));
            this.stateButton1.Image = ((System.Drawing.Image)(resources.GetObject("stateButton1.Image")));
            this.stateButton1.InitState = StateButton.BtState.Normal;
            this.stateButton1.Location = new System.Drawing.Point(138, 132);
            this.stateButton1.Name = "stateButton1";
            this.stateButton1.Size = new System.Drawing.Size(134, 94);
            this.stateButton1.State = 2;
            this.stateButton1.StateMax = 2;
            this.stateButton1.TabIndex = 3;
            this.stateButton1.TabStop = false;
            // 
            // textBaseButton1
            // 
            this.textBaseButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBaseButton1.Image = ((System.Drawing.Image)(resources.GetObject("textBaseButton1.Image")));
            this.textBaseButton1.InitButtonState = SimpleButtonLib.BaseButton.BtState.Normal;
            this.textBaseButton1.Location = new System.Drawing.Point(138, 12);
            this.textBaseButton1.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.textBaseButton1.Name = "textBaseButton1";
            this.textBaseButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("textBaseButton1.NormalImage")));
            this.textBaseButton1.PushedImage = ((System.Drawing.Image)(resources.GetObject("textBaseButton1.PushedImage")));
            this.textBaseButton1.SelectImage = ((System.Drawing.Image)(resources.GetObject("textBaseButton1.SelectImage")));
            this.textBaseButton1.Size = new System.Drawing.Size(120, 48);
            this.textBaseButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.textBaseButton1.TabIndex = 2;
            this.textBaseButton1.TabStop = false;
            this.textBaseButton1.Text = "textBaseButton1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.InitButtonState = SimpleButtonLib.BaseButton.BtState.Normal;
            this.simpleButton1.Location = new System.Drawing.Point(12, 66);
            this.simpleButton1.MyFont = new System.Drawing.Font("Arial", 8.307693F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("simpleButton1.NormalImage")));
            this.simpleButton1.PushedImage = ((System.Drawing.Image)(resources.GetObject("simpleButton1.PushedImage")));
            this.simpleButton1.SelectImage = ((System.Drawing.Image)(resources.GetObject("simpleButton1.SelectImage")));
            this.simpleButton1.Size = new System.Drawing.Size(120, 48);
            this.simpleButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.TabStop = false;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // baseButton1
            // 
            this.baseButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.baseButton1.Image = ((System.Drawing.Image)(resources.GetObject("baseButton1.Image")));
            this.baseButton1.InitButtonState = SimpleButtonLib.BaseButton.BtState.Select;
            this.baseButton1.Location = new System.Drawing.Point(12, 12);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.NormalImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.NormalImage")));
            this.baseButton1.PushedImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.PushedImage")));
            this.baseButton1.SelectImage = ((System.Drawing.Image)(resources.GetObject("baseButton1.SelectImage")));
            this.baseButton1.Size = new System.Drawing.Size(215, 114);
            this.baseButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.baseButton1.TabIndex = 0;
            this.baseButton1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.toggleButton1);
            this.Controls.Add(this.stateButton1);
            this.Controls.Add(this.textBaseButton1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.baseButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.stateButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBaseButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButtonLib.BaseButton baseButton1;
        private SimpleButtonLib.SimpleButton simpleButton1;
        private SimpleButtonLib.TextBaseButton textBaseButton1;
        private StateButton.StateButton stateButton1;
        private ToggleButton.ToggleButton toggleButton1;
    }
}

