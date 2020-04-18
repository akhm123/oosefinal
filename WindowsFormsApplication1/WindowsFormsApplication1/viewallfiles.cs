using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class viewallfile : Form
    {
        Model1 db;
        public viewallfile()
        {
            db = new Model1();

            InitializeComponent();
            //if (Global.username != null)
            {
                //string connetionString = null;
                //SqlConnection cnn;
                //// SqlCommand cmd;
                //string sql = null;

                //connetionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\harsh\\Documents\\document.mdf;Integrated Security=True;Connect Timeout=30";
                //sql = "Select * from Documents";

                ////cnn = new SqlConnection(connetionString);
                //try
                //{

                //    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\Documents\Document.mdf;Integrated Security=True;Connect Timeout=30");
                //    SqlCommand cmd = new SqlCommand("select * from Documents", con);
                //    con.Open();
                //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //    DataTable dt = new DataTable();
                //    sda.Fill(dt);
                //    //   con.Close();
                //    dataGridView1.DataSource = dt;

                //    // cmd.Dispose();
                //    //       cnn.Close();
                //    //Creating DataTable.
                //    DataTable dt1 = new DataTable();

                //    //Adding the Columns.
                //    foreach (DataGridViewColumn column in dataGridView3.Columns)
                //    {
                //        dt1.Columns.Add(column.HeaderText, column.ValueType);
                //    }

                //    //Adding the Rows.
                //    foreach (DataGridViewRow row in dataGridView3.Rows)
                //    {
                //        dt1.Rows.Add();
                //        foreach (DataGridViewCell cell in row.Cells)
                //        {
                //            dt1.Rows[dt1.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                //        }
                //    }

                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Can not open connection ! ");
                //}
                dataGridView4.DataSource = db.document;
               // dataGridView3.;


            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            DocumentUpload obj1 = new DocumentUpload();

            obj1.Show();
            this.Hide();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}