using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageButtonLib
{
    using aRecive = HAPTIVITYLib.Interface.RECEIVE_HAPTIVITY_STATE;

    public partial class ImageButton : PictureBox
    {
        public enum State
        {
            None,
            Select,
            Push
        }

        public State mState = State.None;
        protected Image mSelectImage = global::HAPTIVITYLib.Properties.Resources.BtSelect;
        [Category("ボタンイメージ")] 
        public Image SelectImage
        {
            get
            {
                return mSelectImage;
            }
            set
            {
                mSelectImage = value;
            }
        }

        protected Image mNormalImage = global::HAPTIVITYLib.Properties.Resources.BtNormal;
        [Category("ボタンイメージ")]
        public Image NormalImage
        {
            get
            {
                return mNormalImage;
            }
            set
            {
                mNormalImage = value;
                base.Image = value;
                base.Size = value.Size;
            }
        }

        protected Image mPushedImage = global::HAPTIVITYLib.Properties.Resources.BtPushed;
        [Category("ボタンイメージ")]
        public Image PushedImage
        {
            get
            {
                return mPushedImage;
            }
            set
            {
                mPushedImage = value;
            }
        }

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

        [Category("カスタムボタンイベント")]
        public event EventHandler OnPushButton = (sender, e) =>
        {
            ImageButton btn = sender as ImageButton;
            btn.mState = State.Push;
            btn.Image = btn.mPushedImage;
        };

        [Category("カスタムボタンイベント")]
        public event EventHandler OnReleaseButton = (sender, e) =>
        {
            ImageButton btn = sender as ImageButton;
            btn.mState = State.Select;
            btn.Image = btn.mSelectImage;
        };


        public ImageButton()
        {
            InitializeComponent();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mState = State.Select;
            Image = mSelectImage;
            if (mHaptivity != null)
            {
                mHaptivity.EnterVibration(mConfigNo, mEnterConfigNo, mEnterVibrationTime);
                receiveDataTime.Enabled = true;
            }
             base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mState = State.None;
            Image = mNormalImage;
            if (mHaptivity != null)
            {
                mHaptivity.LeaveVibration();
                receiveDataTime.Enabled = false;
            }
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            OnPushButton(this, EventArgs.Empty);
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            OnReleaseButton(this, EventArgs.Empty);
            base.OnMouseUp(mevent);
        }

        private void receiveDataTime_Tick(object sender, EventArgs e)
        {
            switch (mHaptivity.DataReceived())
            {
                case aRecive.PUSH:
                    OnPushButton(this, EventArgs.Empty);
                    break;
                case aRecive.RELEASE:
                    OnReleaseButton(this, EventArgs.Empty);
                    break;
            }

        }
    }
}
