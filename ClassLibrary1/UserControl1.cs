using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary1
{
    public partial class UserControl1 : UserControl
    {

        public event EventHandler ShadowColorChanged;
        Color _shadowColor;
        public Color ShadowColor
        {
            get
            {
                return _shadowColor;
            }
            set
            {
                _shadowColor = value;
                Invalidate();
                if (ShadowColorChanged != null)
                    ShadowColorChanged(this, EventArgs.Empty);
            }
        }


        public delegate void ShadowDepthEventHandler(object sender, ShadowDepthEventArgs e);
        public event ShadowDepthEventHandler ShadowDepthChanged;
        public int _shadowDepth;
        public int ShadowDepth
        {
            get
            {
                return _shadowDepth;
            }
            set
            {
                int old = _shadowDepth;
                _shadowDepth = value;
                Invalidate();
                if (ShadowDepthChanged != null)
                    ShadowDepthChanged(this, new ShadowDepthEventArgs(old, _shadowDepth));
            }
        }

        public UserControl1()
        {
            InitializeComponent();
        }
    }

    public class ShadowDepthEventArgs : EventArgs
    {
        public ShadowDepthEventArgs(int _oldDepth, int _newDepth)
        {
            OldDepth = _oldDepth;
            NewDepth = _newDepth;
        }
        public int OldDepth { get; set; }
        public int NewDepth { get; set; }
    }
}
