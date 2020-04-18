using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentMangement
{
    public partial class CostEstmation : Form
    {
        public CostEstmation()
        {
            InitializeComponent();
            button1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = Int32.Parse(textBox1.Text);
            int cost = Int32.Parse(textBox2.Text);

            label3.Text = (cost * count).ToString();

            if (cost * count < 10000)
            {
                label4.Text = "You can use our free plan";
            }
            else if (cost * count < 100000)
            {
                label4.Text = "We recommend you to use our gold plan";

            }
            else
            {
                label4.Text = "We recommend you to use our platinum plan";
            }
            button1.Show();
        }
    }
}
