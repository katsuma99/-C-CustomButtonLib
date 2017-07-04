using System;
using System.ComponentModel;
using System.Windows.Forms;
using StateButtonLib;

namespace StateButtonLib
{
    [DefaultProperty("CustomButton")]
    public partial class State8Button : StateButtonLib.StateButton
    {
        #region 変数定義
        //設定データを記録するために変数作る（クラスの配列は記録できない？）
        StateButtonProperty mCustomButton1 = new StateButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StateButtonProperty Button1
        {
            get {return mCustomButton1; }
            set { mCustomButton1 = value; State = SBtState.Button1; }
        }

        StateButtonProperty mCustomButton2 = new StateButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StateButtonProperty Button2
        {
            get { return mCustomButton2; }
            set { mCustomButton2 = value; State = SBtState.Button2; }
        }

        StateButtonProperty mCustomButton3 = new StateButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StateButtonProperty Button3
        {
            get { return mCustomButton3; }
            set { mCustomButton3 = value; State = SBtState.Button3; }
        }

        StateButtonProperty mCustomButton4 = new StateButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StateButtonProperty Button4
        {
            get { return mCustomButton4; }
            set { mCustomButton4 = value; State = SBtState.Button4; }
        }

        StateButtonProperty mCustomButton5 = new StateButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StateButtonProperty Button5
        {
            get { return mCustomButton5; }
            set { mCustomButton5 = value; State = SBtState.Button5; }
        }

        StateButtonProperty mCustomButton6 = new StateButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StateButtonProperty Button6
        {
            get { return mCustomButton6; }
            set { mCustomButton6 = value; State = SBtState.Button6; }
        }

        StateButtonProperty mCustomButton7 = new StateButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StateButtonProperty Button7
        {
            get { return mCustomButton7; }
            set { mCustomButton7 = value; State = SBtState.Button7; }
        }

        StateButtonProperty mCustomButton8 = new StateButtonProperty();
        [Category("カスタム：ボタン"), Description("通常・選択・押下のボタンのイメージ画像")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public StateButtonProperty Button8
        {
            get { return mCustomButton8; }
            set { mCustomButton8 = value; State = SBtState.Button8; }
        }
        #endregion

        #region 関数
        public State8Button()
        {
            mMaxSBtState = SBtState.Button8;
            InitializeComponent();
            InitCustomButton();
            ResizeStatePattern(mStateMax);
            GetNowCustomButton().ChangeButton(mState);
        }

        //CustomButtonにBtStateを渡すためにStateButtonを渡す
        protected override void InitCustomButton()
        {
            Button1.SetStateButton(this);
            Button2.SetStateButton(this);
            Button3.SetStateButton(this);
            Button4.SetStateButton(this);
            Button5.SetStateButton(this);
            Button6.SetStateButton(this);
            Button7.SetStateButton(this);
            Button8.SetStateButton(this);
        }

        //ステートボタンの状態パターンを変更する
        protected override void ResizeStatePattern(int stateMax)
        {
            Button1.Button = stateMax >= 1 ? this : null;
            Button2.Button = stateMax >= 2 ? this : null;
            Button3.Button = stateMax >= 3 ? this : null;
            Button4.Button = stateMax >= 4 ? this : null;
            Button5.Button = stateMax >= 5 ? this : null;
            Button6.Button = stateMax >= 6 ? this : null;
            Button7.Button = stateMax >= 7 ? this : null;
            Button8.Button = stateMax >= 8 ? this : null;
        }

        //現在のカスタムボタンを取得（ステートボタンはカスタムボタンの集まり）
        public override StateButtonProperty GetNowCustomButton(int nextNum = 0)
        {
            StateButtonProperty cbp = Button1;
            int getState = ((int)State + nextNum)% mStateMax;
            if (getState < 0)
                getState += mStateMax;
            switch ((SBtState)getState)
            {
                case SBtState.Button1: cbp = Button1; break;
                case SBtState.Button2: cbp = Button2; break;
                case SBtState.Button3: cbp = Button3; break;
                case SBtState.Button4: cbp = Button4; break;
                case SBtState.Button5: cbp = Button5; break;
                case SBtState.Button6: cbp = Button6; break;
                case SBtState.Button7: cbp = Button7; break;
                case SBtState.Button8: cbp = Button8; break;
            }
            return cbp;
        }

        //イメージ画像リサイズ
        private void StateButton_SizeChanged(object sender, EventArgs e)
        {
            StateButtonProperty cbp = null;
            for (int state = 1; state <= 8; state++)
            {
                switch (state)
                {
                    case 1: cbp = Button1; break;
                    case 2: cbp = Button2; break;
                    case 3: cbp = Button3; break;
                    case 4: cbp = Button4; break;
                    case 5: cbp = Button5; break;
                    case 6: cbp = Button6; break;
                    case 7: cbp = Button7; break;
                    case 8: cbp = Button8; break;
                }
                cbp.ResizeImage(((PictureBox)sender).Size);
            }
            GetNowCustomButton().ChangeButton(mState);
        }
        #endregion
    }
}
