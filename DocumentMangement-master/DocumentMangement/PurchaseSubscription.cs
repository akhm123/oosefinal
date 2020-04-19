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
    public partial class PurchaseSubscription : Form
    {
        public PurchaseSubscription()
        {
            DbContextclass db = new DbContextclass();

            InitializeComponent();
            var d = from p in db.subscription
                   
                    select p;
            dataGridView1.DataSource = d.ToList();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string s;
            int r = senderGrid.CurrentCell.RowIndex;
            int c = senderGrid.CurrentCell.ColumnIndex;

            if (c == 0)
            {
                DbContextclass db = new DbContextclass();
                string l = senderGrid.Rows[r].Cells[1].Value.ToString();
                //label1.Text = l;
                // var employer = new Document{ UserName=Global.username,Url=l};
                // var record = db.users.Where(x => x.UserName == l).FirstOrDefault();
                UserSubscription u = new UserSubscription();
                u.UserName = Global.username;
                u.SubscriptionId = Int32.Parse(l);
                db.UserSubscription.Add(u);
                db.SaveChanges();

                DocumentUpload v = new DocumentUpload();
                v.Show();
                this.Hide();
            }
        }
    }
}
