namespace ToggleButton
{
    partial class ToggleButton
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.mOffSimpleButton = new SimpleButtonLib.SimpleButton();
            this.mOnSimpleButton = new SimpleButtonLib.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.mOffSimpleButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mOnSimpleButton)).BeginInit();
            this.SuspendLayout();
            // 
            // mOffSimpleButton
            // 
            this.mOffSimpleButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mOffSimpleButton.ConfigNo = 0;
            this.mOffSimpleButton.EnterConfigNo = 0;
            this.mOffSimpleButton.EnterVibrationTime = 10;
            this.mOffSimpleButton.Haptivity = null;
            this.mOffSimpleButton.Image = global::HAPTIVITYLib.Properties.Resources.BtNormal;
            this.mOffSimpleButton.Location = new System.Drawing.Point(0, 0);
            this.mOffSimpleButton.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.mOffSimpleButton.Name = "mOffSimpleButton";
            this.mOffSimpleButton.NormalImage = global::HAPTIVITYLib.Properties.Resources.BtNormal;
            this.mOffSimpleButton.PushedImage = global::HAPTIVITYLib.Properties.Resources.BtPushed;
            this.mOffSimpleButton.SelectImage = global::HAPTIVITYLib.Properties.Resources.BtSelect;
            this.mOffSimpleButton.Size = new System.Drawing.Size(100, 50);
            this.mOffSimpleButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mOffSimpleButton.TabIndex = 0;
            this.mOffSimpleButton.TabStop = false;
            this.mOffSimpleButton.Text = "toggleButtonOff";
            this.mOffSimpleButton.OnReleaseButton += new System.EventHandler(this.mOffSimpleButton_OnReleaseButton);
            // 
            // mOnSimpleButton
            // 
            this.mOnSimpleButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mOnSimpleButton.ConfigNo = 0;
            this.mOnSimpleButton.EnterConfigNo = 0;
            this.mOnSimpleButton.EnterVibrationTime = 10;
            this.mOnSimpleButton.ForeColor = System.Drawing.Color.Aquamarine;
            this.mOnSimpleButton.Haptivity = null;
            this.mOnSimpleButton.Image = global::HAPTIVITYLib.Properties.Resources.BtNormalOn;
            this.mOnSimpleButton.Location = new System.Drawing.Point(0, 0);
            this.mOnSimpleButton.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.mOnSimpleButton.Name = "mOnSimpleButton";
            this.mOnSimpleButton.NormalImage = global::HAPTIVITYLib.Properties.Resources.BtNormalOn;
            this.mOnSimpleButton.PushedImage = global::HAPTIVITYLib.Properties.Resources.BtPushedOn;
            this.mOnSimpleButton.SelectImage = global::HAPTIVITYLib.Properties.Resources.BtSelectOn;
            this.mOnSimpleButton.Size = new System.Drawing.Size(100, 50);
            this.mOnSimpleButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mOnSimpleButton.TabIndex = 1;
            this.mOnSimpleButton.TabStop = false;
            this.mOnSimpleButton.Text = "toggleButtonOn";
            this.mOnSimpleButton.OnReleaseButton += new System.EventHandler(this.mOnSimpleButton_OnReleaseButton);
            // 
            // ToggleButton
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::HAPTIVITYLib.Properties.Resources.ToggleButton;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.mOffSimpleButton);
            this.Controls.Add(this.mOnSimpleButton);
            this.DoubleBuffered = true;
            this.Name = "ToggleButton";
            this.Size = new System.Drawing.Size(100, 50);
            this.Load += new System.EventHandler(this.ToggleButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mOffSimpleButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mOnSimpleButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButtonLib.SimpleButton mOffSimpleButton;
        private SimpleButtonLib.SimpleButton mOnSimpleButton;
    }
}
