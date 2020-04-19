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
    public partial class DisplayUser : Form
    {
        public DisplayUser()
        {
            DbContextclass db = new DbContextclass();
            InitializeComponent();


            var customers = from p in db.users
                           select p;
            dataGridView1.DataSource = customers.ToList();
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
                string l = senderGrid.Rows[r].Cells[2].Value.ToString();
                //label1.Text = l;
                // var employer = new Document{ UserName=Global.username,Url=l};
                var record = db.users.Where(x => x.UserName == l).FirstOrDefault();
                db.users.Remove(record);
                db.SaveChanges();
              
                DisplayUser v = new DisplayUser();
                v.Show();
                this.Hide();
            }

        }
    }
}
