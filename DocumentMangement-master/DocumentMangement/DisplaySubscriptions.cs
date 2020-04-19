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
    public partial class DisplaySubscriptions : Form
    {
        public DisplaySubscriptions()
        {
            InitializeComponent();
            DbContextclass db = new DbContextclass();


            var customers = from p in db.subscription
                            select p;
            dataGridView1.DataSource = customers.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string s;
            int r = senderGrid.CurrentCell.RowIndex;
            int c = senderGrid.CurrentCell.ColumnIndex;
            DbContextclass db = new DbContextclass();
            if (c == 1)
            {

                int l = int.Parse(senderGrid.Rows[r].Cells[2].Value.ToString());
                //label1.Text = l;
                // var employer = new Document{ UserName=Global.username,Url=l};
                var record = db.subscription.Where(x => x.SubscriptionId == l).FirstOrDefault();
                db.subscription.Remove(record);
                db.SaveChanges();

                DisplayUser v = new DisplayUser();
                v.Show();
                this.Hide();
            }
            else if (c == 0)
            {
                //int id= senderGrid.Rows[r].Cells[].Value.ToString()
                string p = senderGrid.Rows[r].Cells[2].Value.ToString();
                string p2 = senderGrid.Rows[r].Cells[3].Value.ToString();
                string p3 = (senderGrid.Rows[r].Cells[4].Value.ToString());
                string p4 = senderGrid.Rows[r].Cells[5].Value.ToString();
                string p5=senderGrid.Rows[r].Cells[6].Value.ToString();
                int intp = Int32.Parse(p);
                var d = db.subscription.Where(x => x.SubscriptionId == intp).FirstOrDefault();
                d.SubscriptionName = p2;
                d.DurationOfSubscripition = p3;
                d.Price = Int32.Parse(p4);
                d.details = p5;
                db.SaveChanges();
                DisplaySubscriptions d1 = new DisplaySubscriptions();
                d1.Show();
                this.Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSubscription obj = new AddSubscription();
            obj.Show();
            this.Hide();
        }
    }
}
