using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class DocumentUpload : Form
    {
        Model1 db;
        public DocumentUpload()
        {
           db = new Model1();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            openFileDialog1.Title = "Select file to be upload.";
            //which type file format you want to upload in database. just add them.
            openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        label1.Text = path;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (filename == null)
                {
                    MessageBox.Show("Please select a valid document.");
                }
                else
                {
                    //we already define our connection globaly. We are just calling the object of connection.
                   // con.Open();
                    //SqlCommand cmd = new SqlCommand("insert into doc (document)values('\\Document\\" + filename + "')", con);
                    string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    //System.IO.File.Copy(openFileDialog1.FileName, "\\Files\\" + filename);
                    // cmd.ExecuteNonQuery();
                    //con.Close();
                    Document d = new Document();
                    {
                        d.Name = filename;
                        d.Url = "file";
                        d.UserId = int.Parse("123");
                        d.IsSharable = checkBox1.Checked;
                        d.IsStarred = checkBox2.Checked;
                    };
                    db.document.Add(d);
                    db.SaveChanges();
                    MessageBox.Show("Document uploaded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
