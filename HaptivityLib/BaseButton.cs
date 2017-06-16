using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleButtonLib
{
    [DefaultEvent("OnReleaseButton")]
    public partial class BaseButton : PictureBox
    {
        public enum State
        {
            None,
            Select,
            Push
        }

        public State mState = State.None;
        protected Image mSelectImage = global::HAPTIVITYLib.Properties.Resources.BtSelect;
        [Category("ボタンイメージ"), Description("ボタンを選択した時のイメージ画像")]
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
        [Category("ボタンイメージ"), Description("通常のボタンのイメージ画像")]
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
        [Category("ボタンイメージ"), Description("ボタンを押下した時のイメージ画像")]
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

        [Category("カスタムボタンイベント"), Description("ボタンを押下した時に入る処理")]
        public event EventHandler OnPushButton = (sender, e) =>
        {
            BaseButton btn = sender as BaseButton;
            btn.mState = State.Push;
            btn.Image = btn.mPushedImage;
        };
        protected virtual void OnEventPushButton()
        {
            if (OnPushButton != null) { OnPushButton(this, EventArgs.Empty); }
        }

        [Category("カスタムボタンイベント"), Description("ボタンをリリースした時に入る処理")]
        public event EventHandler OnReleaseButton = (sender, e) =>
        {
            BaseButton btn = sender as BaseButton;
            btn.mState = State.Select;
            btn.Image = btn.mSelectImage;
        };
        protected virtual void OnEventReleaseButton()
        {
            if (OnReleaseButton != null) { OnReleaseButton(this, EventArgs.Empty); }
        }

        public BaseButton()
        {
            InitializeComponent();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mState = State.Select;
            Image = mSelectImage;
             base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mState = State.None;
            Image = mNormalImage;
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
    }
}
