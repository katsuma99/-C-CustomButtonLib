using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToggleButton
{
    public partial class ToggleButton : SimpleButtonLib.SimpleButton
    {
        public bool isToggleState = false;

        private Image mSelectOffImage = global::HAPTIVITYLib.Properties.Resources.BtSelect;
        private Image mSelectOnImage = global::HAPTIVITYLib.Properties.Resources.BtSelectOn;
        [Category("ボタンイメージ")]
        public Image SelectOnImage
        {
            get
            {
                return mSelectOnImage;
            }
            set
            {
                mSelectOnImage = value;
                mSelectOffImage = mSelectImage;
            }
        }

        private Image mNormalOffImage = global::HAPTIVITYLib.Properties.Resources.BtNormal;
        private Image mNormalOnImage = global::HAPTIVITYLib.Properties.Resources.BtNormalOn;
        [Category("ボタンイメージ")]
        public Image NormalOnImage
        {
            get
            {
                return mNormalOnImage;
            }
            set
            {
                mNormalOnImage = value;
                mNormalOffImage = mNormalImage;
            }
        }

        Image mPushedOffImage = global::HAPTIVITYLib.Properties.Resources.BtPushed;
        Image mPushedOnImage = global::HAPTIVITYLib.Properties.Resources.BtPushed;
        [Category("ボタンイメージ")]
        public Image PushedOnImage
        {
            get
            {
                return mPushedOnImage;
            }
            set
            {
                mPushedOnImage = value;
                mPushedOffImage = mPushedImage;
            }
        }

        int mConfigOffNo = 0;
        int mConfigOnNo = 0;
        [Category("HAPTIVITY")]
        public int ConfigOnNo
        {
            get
            {
                return mConfigOnNo;
            }
            set
            {
                mConfigOnNo = value;
                mConfigOffNo = mConfigNo;
            }
        }

        public ToggleButton()
        {
            InitializeComponent();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mConfigNo = isToggleState ? mConfigOnNo : mConfigOffNo;
            mSelectImage = isToggleState ? mSelectOnImage : mSelectOffImage;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mNormalImage = isToggleState ? mNormalOnImage : mNormalOffImage;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            mPushedImage = isToggleState ? mPushedOnImage : mPushedOffImage;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            isToggleState ^= true;
            mSelectImage = isToggleState ? mSelectOnImage : mSelectOffImage;
            base.OnMouseUp(mevent);
        }
    }
}
