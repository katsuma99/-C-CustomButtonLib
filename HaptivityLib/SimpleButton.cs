using System;
using System.ComponentModel;

namespace SimpleButtonLib
{
    using aRecive = HAPTIVITYLib.Interface.RECEIVE_HAPTIVITY_STATE;

    public partial class SimpleButton : TextBaseButton
    {
        protected HAPTIVITYLib.Interface mHaptivity = null;
        [Category("HAPTIVITY"), Description("HAPTIVITYを使うためには、Interfaceをアタッチする")]
        public HAPTIVITYLib.Interface Haptivity
        {
            get { return mHaptivity; }
            set { mHaptivity = value; }
        }

        protected int mConfigNo = 0;
        [Category("HAPTIVITY"), Description("押下時振動のコンフィグ（ボタンを押したときの触感と閾値などの設定番号）")]
        public int ConfigNo
        {
            get { return mConfigNo; }
            set { mConfigNo = value; }
        }

        protected int mEnterConfigNo = 0;
        [Category("HAPTIVITY"), Description("進入時強制振動のコンフィグ")]
        public int EnterConfigNo
        {
            get { return mEnterConfigNo; }
            set { mEnterConfigNo = value; }
        }

        protected int mEnterVibrationTime = 10;
        [Category("HAPTIVITY"), Description("進入時強制振動の連続振動時間")]
        public int EnterVibrationTime
        {
            get { return mEnterVibrationTime; }
            set { mEnterVibrationTime = value; }
        }

        public SimpleButton()
        {
            InitializeComponent();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (mHaptivity != null)
            {
                mHaptivity.EnterVibration(mConfigNo, mEnterConfigNo, mEnterVibrationTime);
                receiveDataTime.Enabled = true;
            }
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (mHaptivity != null)
            {
                mHaptivity.LeaveVibration();
                receiveDataTime.Enabled = false;
            }
            base.OnMouseLeave(e);
        }

        private void receiveDataTime_Tick(object sender, EventArgs e)
        {
            switch (mHaptivity.DataReceived())
            {
                case aRecive.PUSH:
                    OnEventPushButton();
                    break;
                case aRecive.RELEASE:
                    OnEventReleaseButton();
                    break;
            }
        }
    }
}
