using System;
using System.ComponentModel;
using System.Windows.Forms;
using CustomProperty;

namespace State3Button
{
    [DefaultProperty("CustomButton")]
    public partial class State3Button : StateButton
    {
        #region 変数定義
        //設定データを記録するために変数作る（クラスの配列は記録できない？）
        CustomButtonProperty mCustomButton1 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button1
        {
            get {return mCustomButton1; }
            set { mCustomButton1 = value; State = SBtState.Button1; }
        }

        CustomButtonProperty mCustomButton2 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button2
        {
            get { return mCustomButton2; }
            set { mCustomButton2 = value; State = SBtState.Button2; }
        }

        CustomButtonProperty mCustomButton3 = new CustomButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CustomButtonProperty Button3
        {
            get { return mCustomButton3; }
            set { mCustomButton3 = value; State = SBtState.Button3; }
        }

        [DefaultValue(typeof(BtState), "None")]
        [Category("カスタム：ボタン"), Description("ボタンの初期状態（編集時にも変更すると確認できる）")]
        public new BtState InitState
        {
            get { return mState; }
            set { mState = value; GetNowCustomButton().ChangeButton(mState); }
        }

        public new enum SBtState
        {
            Button1,
            Button2,
            Button3,
        }

        [Category("カスタム：ステート"), Description("ステートボタンの現在のパターン")]
        [DefaultValue(0)]
        public new SBtState State
        {
            get
            {
                return (SBtState)mCustomButtonState;
            }
            set
            {
                mCustomButtonState = (int)value;
                if (mStateMax != (int)SBtState.Button3 && mCustomButtonState == (int)SBtState.Button3)
                    mCustomButtonState = mStateMax - 1;
                else if(mCustomButtonState >= mStateMax)
                    mCustomButtonState = 0;
                GetNowCustomButton().ChangeButton(mState);
            }
        }

        [Category("カスタム：ステート"), Description("ステートボタンのパターン数(max:3)")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(0)]
        public new int StateMax
        {
            get { return mStateMax; }
            set
            {
                mStateMax = Math.Min(3, value); ResizeStatePattern(mStateMax);
                State = State;//Maxを更新したため、範囲内にシュリンク
            }
        }
        #endregion

        public State3Button()
        {
            InitializeComponent();
            InitCustomButton();
            ResizeStatePattern(mStateMax);
            GetNowCustomButton().ChangeButton(mState);
        }

        //CustomButtonにBtStateを渡すためにStateButtonを渡す
        void InitCustomButton()
        {
            Button1.SetStateButton(this);
            Button2.SetStateButton(this);
            Button3.SetStateButton(this);
        }

        //ステートボタンの状態パターンを変更する
        void ResizeStatePattern(int stateMax)
        {
            Button1.Button = stateMax >= 1 ? this : null;
            Button2.Button = stateMax >= 2 ? this : null;
            Button3.Button = stateMax >= 3 ? this : null;
        }

        //現在のカスタムボタンを取得（ステートボタンはカスタムボタンの集まり）
        CustomButtonProperty GetNowCustomButton()
        {
            CustomButtonProperty cbp = Button1;
            switch (State)
            {
                case SBtState.Button1: cbp = Button1; break;
                case SBtState.Button2: cbp = Button2; break;
                case SBtState.Button3: cbp = Button3; break;
            }
            return cbp;
        }

        #region ボタンイベント処理
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            GetNowCustomButton().OnPushButton();
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            GetNowCustomButton().OnReleaseButton();
            base.OnMouseUp(mevent);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            GetNowCustomButton().OnEnterButton();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            GetNowCustomButton().OnLeaveButton();
            base.OnMouseLeave(e);
        }
        #endregion


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            GetNowCustomButton().OnPaint(pe);
        }

        //イメージ画像リサイズ
        private void StateButton_SizeChanged(object sender, EventArgs e)
        {
            CustomButtonProperty cbp = null;
            for (int state = 1; state <= 3; state++)
            {
                switch (state)
                {
                    case 1: cbp = Button1; break; 
                    case 2: cbp = Button2; break; 
                    case 3: cbp = Button3; break; 
                }
                cbp.ResizeImage(((PictureBox)sender).Size);
            }
            GetNowCustomButton().ChangeButton(mState);
        }
    }
}
