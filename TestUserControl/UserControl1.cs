using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestUserControl
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        static int i = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = i++.ToString();
            this.ChangeParent(this.Parent);
        }
    }
}
