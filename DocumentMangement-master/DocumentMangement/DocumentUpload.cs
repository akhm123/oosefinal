using DocumentMangement.Models;
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
    public partial class DocumentUpload : Form
    {
        string intp;
        string path;
        public DocumentUpload()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C://Desktop";
            openFileDialog1.Title = "Select file to be upload.";
            openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        label1.Text = path;
                    }
                    for(int i=path.Length-1;i>=0;i--)
                    {
                        if (path[i] == '.')
                            intp = path.Substring(i + 1);
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
            DbContextclass db = new DbContextclass();
            try
            {
                string filename = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (filename == null)
                {
                    MessageBox.Show("Please select a valid document.");
                }
                else
                {
                   // string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    Document d = new Document();
                    {
                        d.Name = filename;
                        d.Url = path;
                        d.UserName =Global.username;
                        d.Type = intp;
                        label3.Text = path;
                        d.IsSharable = IsSharable.Checked;
                        d.IsStarred = checkBox2.Checked;
                    };
                    db.document.Add(d);
                    db.SaveChanges();
                    MessageBox.Show("Document uploaded.");

                    viewallfile v = new viewallfile();
                    v.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
