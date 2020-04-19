using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentMangement.Models;

namespace DocumentMangement
{
    public partial class AddSubscription : Form
    {
        public AddSubscription()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbContextclass db = new DbContextclass();
            DocumentMangement.Models.Subscription s = new Models.Subscription();
            {
                s.SubscriptionName = textBox1.Text;
                s.DurationOfSubscripition = textBox3.Text;
                s.details = textBox2.Text;
                s.Price = Int32.Parse(textBox4.Text);
            };

            db.subscription.Add(s);
            db.SaveChanges();

        }
    }
}
