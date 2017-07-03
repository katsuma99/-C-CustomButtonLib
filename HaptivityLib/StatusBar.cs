using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleButtonLib;

namespace StatusBar
{
    using aRecive = HAPTIVITYLib.Interface.RECEIVE_HAPTIVITY_STATE;
    public partial class StatusBar : SimpleButton
    {
        #region 変数
        protected float mValue = 0;
        [Category("カスタム：バー"), Description("現在のバーの値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public float ValueRatio
        {
            get
            {
                return mValue;
            }
            set
            {
                mValue = Math.Max(0, Math.Min(100, value));
                Invalidate();
            }
        }

        protected float mValueMax = 100;
        [Category("カスタム：バー"), Description("バーのMax値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public float MaxSizeRatio
        {
            get
            {
                return mValueMax;
            }
            set
            {
                mValueMax = Math.Min(100, Math.Max(mValueMin, value));
                Invalidate();
            }
        }

        protected float mValueMin = 0;
        [Category("カスタム：バー"), Description("バーのMin値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public float MinSizeRatio
        {
            get
            {
                return mValueMin;
            }
            set
            {
                mValueMin = Math.Max(0, Math.Min(mValueMax, value));
                Invalidate();
            }
        }
        #endregion


        public StatusBar()
        {

        }

        public override void OnPushButton()
        {
            //AdjustBar();
            base.OnPushButton();
        }

        public override void OnReleaseButton()
        {

            base.OnReleaseButton();
        }

        #region Move処理
        private void Touch_Move(object sender, MouseEventArgs e)
        {
            //AdjustBar();
        }

        int vibCount = 0;
        Point mPos = new Point();
        //        protected void AdjustBar()
        //        {
        //            if (State != BtState.Pushed)   //ボタンが押されている時編集できる
        //                return;

        //            PointmPos.X = System.Windows.Forms.Cursor.Position.X; 　//Mouse位置の記憶
        //            mPos.Y = System.Windows.Forms.Cursor.Position.Y; 　//Mouse位置の記憶


        //            //X座標で一定範囲以上動いたか
        //            int k = Pre_Pos.X - Pos.X;
        //            if (F1Udp.mUdp.CheckTouchLeave(Pre_Pos.X))
        //            {
        //                k = 0;
        //                Pre_Pos.X = Pos.X;
        //            }
        //            int one = (int)(Temp_Frame.Size.Width / AIRCON_KC_Resource.TempImage.Count);
        //            Current_Temp = (int)(-k / one + Current_Temp_base);


        //            //両端処理
        //            if (Current_Temp_save != Current_Temp)
        //            {
        //                TempVibration(F1Udp.mCidHaptic);
        //            }

        //            // FLOW 表示
        //            DrawCurrentTemp();
        //        }

        //        protected void TempVibration(Haptic hap)
        //        {
        //            if (Current_Temp >= AIRCON_KC_Resource.TempImage.Count)
        //            {
        //                Current_Temp = AIRCON_KC_Resource.TempImage.Count - 1;
        //                Current_Temp_base -= 0.4f;
        //                if (vibCount < 2)
        //                    hap.ForcedVibration(NO_8);  //シリアル送信（強制）イリーガル振動
        //                vibCount++;
        //#if DEBUGOUT
        //                        Console.Write(outNum.ToString()+"  ForcedVibration\n"); //debug<OUT>                      
        //                        outNum++;
        //#endif
        //            }
        //            else if (Current_Temp < 0)
        //            {
        //                Current_Temp = 0;
        //                Current_Temp_base += 0.4f;
        //                if (vibCount < 2)
        //                    hap.ForcedVibration(NO_8);  //シリアル送信（強制）イリーガル振動
        //                vibCount++;
        //            }
        //            else if (Current_Temp == 0) hap.ForcedVibration(NO_8);
        //            else if (Current_Temp == 1) hap.ForcedVibration(NO_9);
        //            else if (Current_Temp == 2) hap.ForcedVibration(NO_10);
        //            else if (Current_Temp == 7) hap.ForcedVibration(NO_11);
        //            else if (Current_Temp == 8) hap.ForcedVibration(NO_12);
        //            else if (Current_Temp == 17) hap.ForcedVibration(NO_25);
        //            else if (Current_Temp == 18) hap.ForcedVibration(NO_26);
        //            else if (Current_Temp == 23) hap.ForcedVibration(NO_27);
        //            else if (Current_Temp == 24) hap.ForcedVibration(NO_28);
        //            else
        //            {
        //                int Temp_data = NO_9 + Current_Temp - 3;
        //                hap.ForcedVibration(Temp_data);  //シリアル送信（強制）key位置知らせる
        //                vibCount = 0;
        //            }
        //            Current_Temp_save = Current_Temp;
        //        }


        //        protected void DrawCurrentTemp()
        //        {
        //            Current_Temp = Math.Max(Current_Temp, 0);
        //            Current_Temp = Math.Min(Current_Temp, AIRCON_KC_Resource.TempImage.Count - 1);
        //            Temp_Bar.Image = (Image)AIRCON_KC_Resource.TempImage[Current_Temp];
        //            Temp_Bar.Refresh();

        //            int x = Current_Temp + 63;
        //            Temp_Disp.Image = Horizontal_Label(x + " ℉", Temp_Disp.Width, Temp_Disp.Height, "Meiryo UI", 32, Brushes.White);

        //        }
        #endregion

        //定期的にHAPTIVITYICからコマンドが受信されていないか確認する
        private void receiveDataTime_Tick(object sender, EventArgs e)
        {
            switch (mHaptivity.DataReceived())
            {
                case aRecive.PUSH:
                    OnPushButton();
                    break;
                case aRecive.RELEASE:
                    OnReleaseButton();
                    break;
            }

            //int ev = 0;
            //if (!F1Udp.isMouseMode && !F1Udp.mUdp.GetTouchEvent(ref ev))
            //{
            //    if (ev == 2)
            //    {
            //        Up_Operation(bpos);
            //        return;
            //    }
            //}
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush backBrush = new SolidBrush(this.BackColor);
            Brush foreBrush = new SolidBrush(this.ForeColor);

            //背景を描画する
            e.Graphics.FillRectangle(backBrush, this.ClientRectangle);

            //バーの幅を計算する
            float ratio = (mValueMax - mValueMin) * 0.01f;  //バー画像全体とバーとのサイズ割合
            int barWidth = (int)Math.Ceiling(this.ClientSize.Width * ratio);        //バーのサイズ
            ratio = mValue * 0.01f;     //バーと値とのサイズ割合
            int chunksWidth = (int)Math.Ceiling(barWidth * ratio);     //値のサイズ
            int start = (int)Math.Ceiling(ClientSize.Width * mValueMin * 0.01f); //バー開始の値
            Rectangle chunksRect = new Rectangle(start, 0, chunksWidth, this.ClientSize.Height);
            //バーを描画する
            e.Graphics.FillRectangle(foreBrush, chunksRect);

            backBrush.Dispose();
            foreBrush.Dispose();

            //base.OnPaint(e);//画像テキストを上書き

        }
    }
}
