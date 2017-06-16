using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleButtonLib
{
    public partial class TextBaseButton : BaseButton
    {
        [Category("ボタンイメージ")]
        [Bindable(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text { get; set; }

        [Category("ボタンイメージ")]
        [Bindable(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Font Font { get; set; }

        [Category("ボタンイメージ")]
        [Bindable(true)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override Color ForeColor { get; set; }

        public TextBaseButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            using (Brush brush = new SolidBrush(ForeColor))
            {
                pe.Graphics.DrawString(Text, Font, brush, 0, 0);
            }
        }
    }
}
