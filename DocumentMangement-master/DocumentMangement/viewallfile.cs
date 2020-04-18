using DocumentMangement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentMangement
{
    public partial class viewallfile : Form
    {
        public viewallfile()
        {
            DbContextclass db = new DbContextclass();
            InitializeComponent();


            var customers = from p in db.document
                            where p.UserName == Global.username
                            select p;
            dataGridView1.DataSource = customers.ToList();
                
                
              
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DocumentUpload obj1 = new DocumentUpload();

            obj1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CostEstmation obj = new CostEstmation();
            obj.Show();
            this.Hide();
        }

        private void DownloadFile_Click(object sender, EventArgs e)
        {
            DownloadDoc obj = new DownloadDoc();
            obj.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;
            string s;
            int r = senderGrid.CurrentCell.RowIndex;
            int c = senderGrid.CurrentCell.ColumnIndex;

            if(c==0)
            {
                Global.link = senderGrid.Rows[r].Cells[5].Value.ToString();
                label1.Text = Global.link;
                DownloadDoc obj = new DownloadDoc();
                obj.Show();
                this.Hide();
            }

            if (senderGrid.CurrentCell is DataGridViewCheckBoxCell &&
                e.RowIndex >= 0)
            {
                //DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                r = senderGrid.CurrentCell.RowIndex;
                c = senderGrid.CurrentCell.ColumnIndex;
                s = senderGrid.Rows[r].Cells[1].Value.ToString();
                if ((bool)senderGrid.CurrentCell.Value)
                {
                    //if (senderGrid.Columns[e.ColumnIndex].va)

                    //if(s.Equals("srs.docx"))
                    //{
                    //    Registration o = new Registration();
                    //    o.Show();
                    //    this.Hide();
                    //}
                    using (var db = new DbContextclass())
                    {
                        var k = db.document.FirstOrDefault(u => u.Name == s);
                        if (c == 5)
                            k.IsSharable = false;
                        else if (c == 6)
                            k.IsStarred = false;
                        //  db.document.Attach(user);
                        //db.Entry(user).Property(x => x.Password).IsModified = true;
                        db.SaveChanges();

                        //viewallfile o = new viewallfile();
                        //o.Show();
                        //this.Hide();
                    }

                }
                else
                {
                    using (var db = new DbContextclass())
                    {
                        var k = db.document.FirstOrDefault(u => u.Name == s);
                        if (c == 5)
                            k.IsSharable = true;
                        else if (c == 6)
                            k.IsStarred = true;
                        //  db.document.Attach(user);
                        //db.Entry(user).Property(x => x.Password).IsModified = true;
                        db.SaveChanges();
                    }
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DbContextclass db = new DbContextclass();
            var c = from p in db.document
                    where p.UserName == Global.username
                    select p;
            var final = from p in c
                        where p.Name.Contains(textBox1.Text)
                        select p;
            dataGridView1.DataSource = final.ToList();
        }

        //private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        //{

        //}

        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    //Registration o = new Registration();
        //    //o.Show();
        //    //this.Hide();
        //    var senderGrid = (DataGridView)sender;

        //    if (senderGrid.CurrentCell is DataGridViewCheckBoxCell
        //       )
        //    {
        //        //DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
        //        int r = senderGrid.CurrentCell.RowIndex;
        //        int c = senderGrid.CurrentCell.ColumnIndex;
        //        string s = senderGrid.Rows[r].Cells[1].Value.ToString();
        //        if ((bool)senderGrid.CurrentCell.Value)
        //        {
        //            //if (senderGrid.Columns[e.ColumnIndex].va)

        //            //if(s.Equals("srs.docx"))
        //            //{
        //            //    Registration o = new Registration();
        //            //    o.Show();
        //            //    this.Hide();
        //            //}
        //            using (var db = new DbContextclass())
        //            {
        //                var k = db.document.FirstOrDefault(u => u.Name == s);
        //                k.IsSharable = false;
        //                //  db.document.Attach(user);
        //                //db.Entry(user).Property(x => x.Password).IsModified = true;
        //                db.SaveChanges();

        //                //viewallfile o = new viewallfile();
        //                //o.Show();
        //                //this.Hide();
        //            }

        //        }
        //        else
        //        {
        //            using (var db = new DbContextclass())
        //            {
        //                var k = db.document.FirstOrDefault(u => u.Name == s);
        //                k.IsSharable = true;
        //                //  db.document.Attach(user);
        //                //db.Entry(user).Property(x => x.Password).IsModified = true;
        //                db.SaveChanges();
        //            }
        //        }
        //    }
        //}




    }
}
