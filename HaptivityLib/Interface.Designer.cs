namespace StatusBar
{
    partial class Interface
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.dResp = new System.Windows.Forms.Timer(this.components);
            this.StopModeChangeTimer = new System.Windows.Forms.Timer(this.components);
            this.TracingVibrationTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DtrEnable = true;
            this.serialPort1.PortName = "COM4";
            this.serialPort1.RtsEnable = true;
            this.serialPort1.WriteBufferSize = 8;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPortDataReceived);
            // 
            // dResp
            // 
            this.dResp.Interval = 1;
            this.dResp.Tick += new System.EventHandler(this.dResp_Tick);
            // 
            // StopModeChangeTimer
            // 
            this.StopModeChangeTimer.Interval = 1000;
            this.StopModeChangeTimer.Tick += new System.EventHandler(this.Closing_Timer_Tick);
            // 
            // TracingVibrationTimer
            // 
            this.TracingVibrationTimer.Interval = 10;
            this.TracingVibrationTimer.Tick += new System.EventHandler(this.TracingVibrationTimer_Tick);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::StatusBar.Properties.Resources.HAPTIVITY;
            this.Enabled = false;
            this.Name = "Interface";
            this.Size = new System.Drawing.Size(32, 32);
            this.Load += new System.EventHandler(this.Interface_Load);
            this.ParentChanged += new System.EventHandler(this.Interface_ParentChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer dResp;
        private System.Windows.Forms.Timer StopModeChangeTimer;
        private System.Windows.Forms.Timer TracingVibrationTimer;
        private System.IO.Ports.SerialPort serialPort1;
    }
}
