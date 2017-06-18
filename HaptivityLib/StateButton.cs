using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SimpleButtonLib;

namespace StateButton
{
    [DefaultProperty("ButtonState")]
    public partial class StateButton : BaseButton
    {
        List<BaseButtonProperty> mBaseBtPropList = new List<BaseButtonProperty>();
        int mButtonState = 0;
        [Category("StateButtonの状態"), Description("ステートボタンの状態（現在の状態のボタンが編集できる）")]
        [DefaultValue(0)]
        public int ButtonState
        {
            get
            {
                return mButtonState + 1;
            }
            set
            {
                mButtonState = Math.Min(mBaseBtPropList.Count, value) - 1;
                BaseButtonProperty = mBaseBtPropList[mButtonState];
                Invalidate();
            }
        }

        [Category("StateButtonの状態"), Description("ステートボタンのパターン数")]
        [DefaultValue(0)]
        public int StateMax
        {
            get
            {
                return mBaseBtPropList.Count;
            }
            set
            {
                InitSimpleButtonList( Math.Max(value,1) );
            }
        }

        [Category("ボタンイメージ"), Description("現在の状態でのボタンを選択した時のイメージ画像")]
        public Image SelectImage
        {
            get { return mBaseBtPropList[mButtonState].SelectImage; }
            set
            {
                mBaseBtPropList[mButtonState].SelectImage = value;
                ResizeStateButton();
            }
        }

        [Category("ボタンイメージ"), Description("現在の状態でのボタンのイメージ画像")]
        public Image NormalImage
        {
            get { return mBaseBtPropList[mButtonState].NormalImage; }
            set
            {
                mBaseBtPropList[mButtonState].NormalImage = value;
                ResizeStateButton();
            }
        }

        [Category("ボタンイメージ"), Description("現在の状態でのボタンを押下した時のイメージ画像")]
        public Image PushedImage
        {
            get { return mBaseBtPropList[mButtonState].PushedImage; }
            set
            {
                mBaseBtPropList[mButtonState].PushedImage = value;
                ResizeStateButton();
            }
        }

        //[Category("ボタンイメージ"), Description("現在の状態でのボタンに表示させる文字")]
        //[DefaultValue("")]
        //public override string Text
        //{
        //    get { return mBaseBtPropList[mButtonState].Text; }
        //    set { mBaseBtPropList[mButtonState].Text = value; }
        //}

        //[Category("ボタンイメージ"), Description("現在の状態でのボタンに表示させる文字の色")]
        //[DefaultValue(typeof(Color), "Aquamarine")]
        //public override Color ForeColor
        //{
        //    get { return mBaseBtPropList[mButtonState].ForeColor; }
        //    set { mBaseBtPropList[mButtonState].ForeColor = value; }
        //}

        //[Category("ボタンイメージ"), Description("現在の状態でのボタンに表示させる文字フォント")]
        //[DefaultValue(typeof(Font), "Arial, 8, style=Bold")]
        //public Font MyFont
        //{
        //    get { return mBaseBtPropList[mButtonState].Font; }
        //    set { mBaseBtPropList[mButtonState].Font = value; }
        //}

        //[Category("HAPTIVITY"), Description("現在の状態でのHAPTIVITYを使うためには、Interfaceをアタッチする")]
        //[DefaultValue(null)]
        //public HAPTIVITYLib.Interface Haptivity
        //{
        //    get { return mBaseBtPropList[mButtonState].Haptivity; }
        //    set { mBaseBtPropList[mButtonState].Haptivity = value; }
        //}

        //[Category("HAPTIVITY"), Description("現在の状態での押下時振動のコンフィグ（ボタンを押したときの触感と閾値などの設定番号）")]
        //[DefaultValue(0)]
        //public int ConfigNo
        //{
        //    get { return mBaseBtPropList[mButtonState].ConfigNo; }
        //    set { mBaseBtPropList[mButtonState].ConfigNo = value; }
        //}

        //[Category("HAPTIVITY"), Description("現在の状態での進入時強制振動のコンフィグ")]
        //[DefaultValue(0)]
        //public int EnterConfigNo
        //{
        //    get { return mBaseBtPropList[mButtonState].EnterConfigNo; }
        //    set { mBaseBtPropList[mButtonState].EnterConfigNo = value; }
        //}

        //[Category("HAPTIVITY"), Description("現在の状態での進入時強制振動の連続振動時間")]
        //[DefaultValue(10)]
        //public int EnterVibrationTime
        //{
        //    get { return mBaseBtPropList[mButtonState].EnterVibrationTime; }
        //    set { mBaseBtPropList[mButtonState].EnterVibrationTime = value; }
        //}
      

        //表示されないと呼ばれない（Visible = falseの場合は呼ばれない）コンストラクタで非表示にしたら使えない
        private void StateButton_Load(object sender, EventArgs e)
        {
        }

        public StateButton()
        {
            InitializeComponent();
            InitSimpleButtonList(1);
        }

        void InitSimpleButtonList(int countMax)
        {
            mBaseBtPropList.Clear();

            for (int no = 1; no <= countMax; no++)
            {
                BaseButtonProperty simpleButton = new BaseButtonProperty();

                //simpleButton.Haptivity = null;
                //simpleButton.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
                simpleButton.NormalImage = global::HAPTIVITYLib.Properties.Resources.BtNormal;
                simpleButton.PushedImage = global::HAPTIVITYLib.Properties.Resources.BtPushed;
                simpleButton.SelectImage = global::HAPTIVITYLib.Properties.Resources.BtSelect;
                //simpleButton.Text = "StateButton" + no.ToString();

                mBaseBtPropList.Add(simpleButton);
            }
            ButtonState = 1;
            BaseButtonProperty = mBaseBtPropList[mButtonState];
            Invalidate();
        }

        private void mSimpleButton_OnReleaseButton(object sender, EventArgs e)
        {
            if(++mButtonState >= mBaseBtPropList.Count) mButtonState = 0;
            BaseButtonProperty = mBaseBtPropList[mButtonState];
        }

        private void StateButton_Resize(object sender, EventArgs e)
        {
            ResizeStateButton();
        }

        void ResizeStateButton()
        {
            //for (int i = 0; i < mBaseBtPropList.Count; i++)
            //    mBaseBtPropList[i].Size = this.Size;
        }
    }

    //public class StateButtonConverter : TypeConverter
    //{
    //    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    //    {
    //        if (sourceType == typeof(string))
    //            return true;
    //        else
    //            return base.CanConvertFrom(context, sourceType);
    //    }

    //    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    //    {
    //        if (destinationType == typeof(string))
    //            return true;
    //        else
    //            return base.CanConvertTo(context, destinationType);
    //    }

    //    public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    //    {
    //        string strValue = value as string;
    //        if (strValue == null)
    //            return base.ConvertFrom(context, culture, value);
    //        string[] values = strValue.Split(',');
    //        int count = values.Length;
    //        try
    //        {
    //            Shadow shadow = new Shadow();
    //            if (count < 1 || values[0].Trim().Length == 0)
    //            {
    //                shadow.Color = SystemColors.GrayText;
    //            }
    //            else
    //            {
    //                ColorConverter colorConverter = new ColorConverter();
    //                shadow.Color = (Color)colorConverter.ConvertFromString(values[0]);
    //            }
    //            if (count < 2)
    //                shadow.Depth = 1;
    //            else
    //                shadow.Depth = int.Parse(values[1]);
    //            if (count < 3)
    //                shadow.Direction = ShadowDirection.ToBottomRight;
    //            else
    //                shadow.Direction = (ShadowDirection)Enum.Parse(typeof(ShadowDirection), values[2], true);
    //            return shadow;
    //        }
    //        catch
    //        {
    //            throw new ArgumentException("プロパティの値が無効です");
    //        }
    //    }

    //    public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
    //    {

    //        SimpleButton simpleButton = value as SimpleButton;
    //        if (simpleButton == null || destinationType != typeof(string))
    //            return base.ConvertTo(context, culture, value, destinationType);
    //        ImageConverter imageConverter = new ImageConverter();
    //        ColorConverter colorConverter = new ColorConverter();
    //        FontConverter fontConverter = new FontConverter();
    //        return string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
    //                             imageConverter.ConvertToString(simpleButton.SelectImage),
    //                             imageConverter.ConvertToString(simpleButton.NormalImage),
    //                             imageConverter.ConvertToString(simpleButton.PushedImage),
    //                             simpleButton.Text,
    //                             colorConverter.ConvertToString(simpleButton.ForeColor),
    //                             fontConverter.ConvertToString(simpleButton.MyFont)
    //                             );
    //    }
    //}
}
