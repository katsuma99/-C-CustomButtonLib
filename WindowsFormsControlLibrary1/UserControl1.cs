using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsControlLibrary1
{
    [DefaultProperty("BaseButtonProperty")]
    public partial class UserControl1 : PictureBox
    {
        protected BaseButtonProperty mBaseButtonProperty = new BaseButtonProperty();
        [Category("ボタンイメージ"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public BaseButtonProperty BaseButtonProperty { get; set; }

        public UserControl1()
        {
            Debug.WriteLine("デバッグ・メッセージを出力");

            InitializeComponent();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mBaseButtonProperty.OnEnterButton(Image);
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mBaseButtonProperty.OnLeaveButton(Image);
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            mBaseButtonProperty.OnPushButton(Image);
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            mBaseButtonProperty.OnReleaseButton(Image);
            base.OnMouseUp(mevent);
        }
    }

    public enum State
    {
        None,
        Select,
        Push
    }

    [DefaultEvent("OnReleaseButtonEvent")]
    [DefaultProperty("NormalImage")]
    [TypeConverter(typeof(BaseButtonPropertyConverter))]
    public class BaseButtonProperty
    {
        public BaseButtonProperty()
        {
            mSelectImage = global::WindowsFormsControlLibrary1.Properties.Resources.Select;
            mNormalImage = global::WindowsFormsControlLibrary1.Properties.Resources.Normal;
            mPushedImage = global::WindowsFormsControlLibrary1.Properties.Resources.Pushed;
        }

        public State mState = State.None;
        protected Image mSelectImage;
        [Category("ボタンイメージ"), Description("ボタンを選択した時のイメージ画像")]
        [DefaultValue(null)]
        public Image SelectImage
        {
            get { return mSelectImage; }
            set { mSelectImage = value; }
        }

        protected Image mNormalImage;
        [Category("ボタンイメージ"), Description("通常のボタンのイメージ画像")]
        [DefaultValue(null)]
        public Image NormalImage
        {
            get
            {
                return mNormalImage;
            }
            set
            {
                mNormalImage = value;
                //base.Image = value;
                //base.Size = value.Size;
            }
        }

        protected Image mPushedImage;
        [Category("ボタンイメージ"), Description("ボタンを押下した時のイメージ画像")]
        [DefaultValue(null)]
        public Image PushedImage
        {
            get { return mPushedImage; }
            set { mPushedImage = value; }
        }

        [Category("カスタムボタンイベント"), Description("ボタンを押下した時に入る処理")]
        public event EventHandler OnPushButtonEvent = (sender, e) =>
        {
        };


        [Category("カスタムボタンイベント"), Description("ボタンをリリースした時に入る処理")]
        public event EventHandler OnReleaseButtonEvent = (sender, e) =>
        {
        };

        public void OnPushButton(Image btImage)
        {
            OnPushButtonEvent(this, EventArgs.Empty);
            mState = State.Push;
            btImage = PushedImage;
        }

        public void OnReleaseButton(Image btImage)
        {
            OnReleaseButtonEvent(this, EventArgs.Empty);
            mState = State.Select;
            btImage = SelectImage;
        }

        public void OnEnterButton(Image btImage)
        {
            mState = State.Select;
            btImage = SelectImage;
        }

        public void OnLeaveButton(Image btImage)
        {
            mState = State.None;
            btImage = NormalImage;
        }
    }

    public class BaseButtonPropertyConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
                return true;
            else
                return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;
            else
                return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            new ArgumentException("プロパティの値が無効です");
            string strValue = value as string;
            if (strValue == null)
                return base.ConvertFrom(context, culture, value);
            string[] values = strValue.Split(',');
            int count = values.Length;
            try
            {
                BaseButtonProperty baseButtonProp = new BaseButtonProperty();
                ImageConverter imageConverter = new ImageConverter();
                if (count < 1 || values[0].Trim().Length == 0)
                {
                    baseButtonProp.SelectImage = global::WindowsFormsControlLibrary1.Properties.Resources.Select;
                }
                else
                {
                    baseButtonProp.SelectImage = (Image)imageConverter.ConvertFromString(values[0]);
                }

                if (count < 2 || values[1].Trim().Length == 0)
                {
                    baseButtonProp.NormalImage = global::WindowsFormsControlLibrary1.Properties.Resources.Normal;
                }
                else
                {
                    baseButtonProp.NormalImage = (Image)imageConverter.ConvertFromString(values[1]);
                }

                if (count < 3 || values[2].Trim().Length == 0)
                {
                    baseButtonProp.PushedImage = global::WindowsFormsControlLibrary1.Properties.Resources.Pushed;
                }
                else
                {
                    baseButtonProp.PushedImage = (Image)imageConverter.ConvertFromString(values[2]);
                }

                return baseButtonProp;
            }
            catch
            {
                throw new ArgumentException("プロパティの値が無効です");
            }
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {

            BaseButtonProperty baseButtonProp = value as BaseButtonProperty;
            if (baseButtonProp == null || destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);
            ImageConverter imageConverter = new ImageConverter();
            return string.Format("{0}, {1}, {2}",
                                 imageConverter.ConvertToString(baseButtonProp.SelectImage),
                                 imageConverter.ConvertToString(baseButtonProp.NormalImage),
                                 imageConverter.ConvertToString(baseButtonProp.PushedImage)
                                 );
        }
    }
}
