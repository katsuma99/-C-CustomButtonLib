using System;
using System.ComponentModel;

namespace SimpleButtonLib
{
    using aRecive = HAPTIVITYLib.Interface.RECEIVE_HAPTIVITY_STATE;

    public partial class SimpleButton : BaseButton
    {
        protected HAPTIVITYLib.Interface mHaptivity = null;
        [Category("HAPTIVITY")]
        public HAPTIVITYLib.Interface Haptivity
        {
            get
            {
                return mHaptivity;
            }
            set
            {
                mHaptivity = value;
            }
        }

        protected int mConfigNo = 0;
        [Category("HAPTIVITY")]
        public int ConfigNo
        {
            get
            {
                return mConfigNo;
            }
            set
            {
                mConfigNo = value;
            }
        }

        protected int mEnterConfigNo = 0;
        [Category("HAPTIVITY")]
        public int EnterConfigNo
        {
            get
            {
                return mEnterConfigNo;
            }
            set
            {
                mEnterConfigNo = value;
            }
        }

        protected int mEnterVibrationTime = 10;
        [Category("HAPTIVITY")]
        public int EnterVibrationTime
        {
            get
            {
                return mEnterVibrationTime;
            }
            set
            {
                mEnterVibrationTime = value;
            }
        }

        public SimpleButton()
        {
            InitializeComponent();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (mHaptivity == null) return;

            mHaptivity.EnterVibration(mConfigNo, mEnterConfigNo, mEnterVibrationTime);
            receiveDataTime.Enabled = true;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (mHaptivity == null) return;

            mHaptivity.LeaveVibration();
            receiveDataTime.Enabled = false;
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
