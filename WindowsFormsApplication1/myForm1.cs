using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class myForm1 : Form
    {
        public myForm1()
        {
            InitializeComponent();
        }

        private void baseButton1_OnReleaseButton(object sender, EventArgs e)
        {
            label1.Text = "push";
        }
    }
}
