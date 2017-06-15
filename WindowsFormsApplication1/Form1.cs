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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //TextBox textBox = userControl11.GetAllControls<TextBox>()[0];
            //textBox.Text = count.ToString();
            //count++;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            count = 0;
        }

        public void Function()
        {

        }

        int count = 0;
        private void imageButton2_OnReleaseButton(object sender, EventArgs e)
        {
            label1.Text = (++count).ToString();
        }
    }
}
