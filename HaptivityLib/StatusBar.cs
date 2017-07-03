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
    public partial class StatusBar : SimpleButton
    {
        protected float mNowValue = 0;
        [Category("カスタム：バー"), Description("現在のバーの値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public float NowValue
        {
            get
            {
                return mNowValue;
            }
            set
            {
                mNowValue = value;
                Invalidate();
            }
        }

        protected float mValueMax = 0;
        [Category("カスタム：バー"), Description("バーのMax値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public float ValueMax
        {
            get
            {
                return mValueMax;
            }
            set
            {
                mValueMax = value;
                Invalidate();
            }
        }

        protected float mValueMin = 0;
        [Category("カスタム：バー"), Description("バーのMin値(%)")]
        [Bindable(true), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public float ValueMin
        {
            get
            {
                return mValueMin;
            }
            set
            {
                mValueMin = value;
                Invalidate();
            }
        }


        public StatusBar()
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush backBrush = new SolidBrush(this.BackColor);
            Brush foreBrush = new SolidBrush(this.ForeColor);

            //背景を描画する
            e.Graphics.FillRectangle(backBrush, this.ClientRectangle);

            //バーの幅を計算する
            int chunksWidth = (int)(
                (double)this.ClientSize.Width *
                (double)(mNowValue - mValueMax) /
                (double)(mValueMax - mValueMin));
            Rectangle chunksRect = new Rectangle(0, 0,
                chunksWidth, this.ClientSize.Height);
            //バーを描画する
            e.Graphics.FillRectangle(foreBrush, chunksRect);

            backBrush.Dispose();
            foreBrush.Dispose();

            base.OnPaint(e);
        }
    }
}
