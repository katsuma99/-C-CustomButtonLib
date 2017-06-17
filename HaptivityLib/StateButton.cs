using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SimpleButtonLib;

namespace StateButton
{
    [DefaultProperty("ButtonState")]
    [TypeConverter(typeof(StateButtonConverter))]
    public partial class StateButton : UserControl
    {
        List<SimpleButton> mSimpleButtonList = new List<SimpleButton>();
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
                mButtonState = Math.Min(mSimpleButtonList.Count, value) - 1;
                Invalidate();
            }
        }

        [Category("StateButtonの状態"), Description("ステートボタンのパターン数")]
        [DefaultValue(0)]
        public int StateMax
        {
            get
            {
                return mSimpleButtonList.Count;
            }
            set
            {
                InitSimpleButtonList( Math.Max(value,1) );
            }
        }

        [Category("ボタンイメージ"), Description("ON時のボタンを選択した時のイメージ画像")]
        public Image SelectImage
        {
            get { return mSimpleButtonList[mButtonState].SelectImage; }
            set
            {
                mSimpleButtonList[mButtonState].SelectImage = value;
                ResizeStateButton();
            }
        }

        [Category("ボタンイメージ"), Description("現在の状態でのボタンのイメージ画像")]
        public Image OnNormalImage
        {
            get { return mSimpleButtonList[mButtonState].NormalImage; }
            set
            {
                mSimpleButtonList[mButtonState].NormalImage = value;
                ResizeStateButton();
            }
        }

        [Category("ボタンイメージ"), Description("現在の状態でのボタンを押下した時のイメージ画像")]
        public Image OnPushedImage
        {
            get { return mSimpleButtonList[mButtonState].PushedImage; }
            set
            {
                mSimpleButtonList[mButtonState].PushedImage = value;
                ResizeStateButton();
            }
        }

        [Category("ボタンイメージ"), Description("現在の状態でのボタンに表示させる文字")]
        [DefaultValue("")]
        public string OnText
        {
            get { return mSimpleButtonList[mButtonState].Text; }
            set { mSimpleButtonList[mButtonState].Text = value; }
        }

        [Category("ボタンイメージ"), Description("現在の状態でのボタンに表示させる文字の色")]
        [DefaultValue(typeof(Color), "Aquamarine")]
        public Color OnForeColor
        {
            get { return mSimpleButtonList[mButtonState].ForeColor; }
            set { mSimpleButtonList[mButtonState].ForeColor = value; }
        }

        [Category("ボタンイメージ"), Description("現在の状態でのボタンに表示させる文字フォント")]
        [DefaultValue(typeof(Font), "Arial, 8, style=Bold")]
        public Font OnMyFont
        {
            get { return mSimpleButtonList[mButtonState].Font; }
            set { mSimpleButtonList[mButtonState].Font = value; }
        }

        [Category("HAPTIVITY"), Description("現在の状態でのHAPTIVITYを使うためには、Interfaceをアタッチする")]
        [DefaultValue(null)]
        public HAPTIVITYLib.Interface OnHaptivity
        {
            get { return mSimpleButtonList[mButtonState].Haptivity; }
            set { mSimpleButtonList[mButtonState].Haptivity = value; }
        }

        [Category("HAPTIVITY"), Description("現在の状態での押下時振動のコンフィグ（ボタンを押したときの触感と閾値などの設定番号）")]
        [DefaultValue(0)]
        public int OnConfigNo
        {
            get { return mSimpleButtonList[mButtonState].ConfigNo; }
            set { mSimpleButtonList[mButtonState].ConfigNo = value; }
        }

        [Category("HAPTIVITY"), Description("現在の状態での進入時強制振動のコンフィグ")]
        [DefaultValue(0)]
        public int OnEnterConfigNo
        {
            get { return mSimpleButtonList[mButtonState].EnterConfigNo; }
            set { mSimpleButtonList[mButtonState].EnterConfigNo = value; }
        }

        [Category("HAPTIVITY"), Description("現在の状態での進入時強制振動の連続振動時間")]
        [DefaultValue(10)]
        public int OnEnterVibrationTime
        {
            get { return mSimpleButtonList[mButtonState].EnterVibrationTime; }
            set { mSimpleButtonList[mButtonState].EnterVibrationTime = value; }
        }
      

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
            mSimpleButtonList.Clear();
            this.Controls.Clear();

            for (int no = 1; no <= countMax; no++)
            {
                SimpleButton simpleButton = new SimpleButton();

                ((System.ComponentModel.ISupportInitialize)(simpleButton)).BeginInit();
                simpleButton.BackColor = System.Drawing.SystemColors.ControlDark;
                simpleButton.Haptivity = null;
                simpleButton.Image = global::HAPTIVITYLib.Properties.Resources.BtNormal;
                simpleButton.Location = new System.Drawing.Point(0, 0);
                simpleButton.MyFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
                simpleButton.Name = "mStateButton" + no.ToString();
                simpleButton.NormalImage = global::HAPTIVITYLib.Properties.Resources.BtNormal;
                simpleButton.PushedImage = global::HAPTIVITYLib.Properties.Resources.BtPushed;
                simpleButton.SelectImage = global::HAPTIVITYLib.Properties.Resources.BtSelect;
                simpleButton.Size = new System.Drawing.Size(100, 50);
                simpleButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                simpleButton.TabIndex = 0;
                simpleButton.TabStop = false;
                simpleButton.Text = "StateButton" + no.ToString();
                simpleButton.OnReleaseButton += new System.EventHandler(mSimpleButton_OnReleaseButton);
                ((System.ComponentModel.ISupportInitialize)(simpleButton)).EndInit();
                simpleButton.Visible = false;
                this.Controls.Add(simpleButton);
                mSimpleButtonList.Add(simpleButton);
            }
            mSimpleButtonList[0].Show();
            ButtonState = 1;
            Invalidate();
        }

        private void mSimpleButton_OnReleaseButton(object sender, EventArgs e)
        {
            mSimpleButtonList[mButtonState].Hide();
            if(++mButtonState >= mSimpleButtonList.Count) mButtonState = 0;
            mSimpleButtonList[mButtonState].Show();
        }

        private void StateButton_Resize(object sender, EventArgs e)
        {
            ResizeStateButton();
        }

        void ResizeStateButton()
        {
            for (int i = 0; i < mSimpleButtonList.Count; i++)
                mSimpleButtonList[i].Size = this.Size;
        }
    }

    public class StateButtonConverter : TypeConverter
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
            string strValue = value as string;
            if (strValue == null)
                return base.ConvertFrom(context, culture, value);
            string[] values = strValue.Split(',');
            int count = values.Length;
            try
            {
                Shadow shadow = new Shadow();
                if (count < 1 || values[0].Trim().Length == 0)
                {
                    shadow.Color = SystemColors.GrayText;
                }
                else
                {
                    ColorConverter colorConverter = new ColorConverter();
                    shadow.Color = (Color)colorConverter.ConvertFromString(values[0]);
                }
                if (count < 2)
                    shadow.Depth = 1;
                else
                    shadow.Depth = int.Parse(values[1]);
                if (count < 3)
                    shadow.Direction = ShadowDirection.ToBottomRight;
                else
                    shadow.Direction = (ShadowDirection)Enum.Parse(typeof(ShadowDirection), values[2], true);
                return shadow;
            }
            catch
            {
                throw new ArgumentException("プロパティの値が無効です");
            }
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            SimpleButton simpleButton = value as Shadow;
            if (shadow == null || destinationType != typeof(string))
                return base.ConvertTo(context, culture, value, destinationType);
            ColorConverter colorConverter = new ColorConverter();
            return string.Format("{0}, {1}, {2}",
                                 colorConverter.ConvertToString(shadow.Color),
                                 shadow.Depth, shadow.Direction);
        }
    }
}
