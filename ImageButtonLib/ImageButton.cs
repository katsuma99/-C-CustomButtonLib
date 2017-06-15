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
    public partial class ImageButton : PictureBox
    {
        public enum State
        {
            None,
            Select,
            Push
        }

        public State mState = State.None;
        private Image mSelectImage = global::ImageButtonLib.Properties.Resources.Select;
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

        private Image mNormalImage = global::ImageButtonLib.Properties.Resources.Normal;
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

        private Image mPushedImage = global::ImageButtonLib.Properties.Resources.Pushed;
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

        HAPTIVITYLib.Interface mHaptivity = null;
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

        int mConfigNo = 0;
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

        int mEnterConfigNo = 0;
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

        int mEnterVibrationTime = 500;
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


        public ImageButton()
        {
            InitializeComponent();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mState = State.Select;
            Image = mSelectImage;
            if (mHaptivity != null) mHaptivity.EnterVibration(mConfigNo,mEnterConfigNo,mEnterVibrationTime);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mState = State.None;
            Image = mNormalImage;
            if (mHaptivity != null) mHaptivity.LeaveVibration();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            mState = State.Push;
            Image = mPushedImage;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            mState = State.Select;
            Image = mSelectImage;
            base.OnMouseUp(mevent);
        }
    }
}
