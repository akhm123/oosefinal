using DocumentMangement.Models;
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

namespace DocumentMangement
{
    public partial class DocumentUpload : Form
    {
        string intp;
        string path;
        int f = 0;
        public DocumentUpload()
        {
            DbContextclass db = new DbContextclass();
            InitializeComponent();
            var count = from p in db.document
                            where p.UserName == Global.username
                            select p;

            var sub = from p in db.UserSubscription
                      where p.UserName == Global.username
                      select p;
            if(count.Count()>1 && sub.Count()==0)
            {
                f = 1;
               
               
            
            }
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

            if (f == 1)
            {
                MessageBox.Show("You need to purchase our sunsctiprion to upload more files");

                PurchaseSubscription p = new PurchaseSubscription();

                p.Show();
                this.Hide();
            }
            else
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


                        string _path = @"C:\Users\Admin\Downloads\DocumentMangement-master\DocumentMangement\Documents\" + filename;
                        // File.Create(_path);// "~/C:/Users/Admin/Downloads/DocumentMangement-master/Documents " + filename);
                        File.Copy(path, _path);// SaveAs(_path);
                                               // string path = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        Document d = new Document();
                        {
                            d.Name = filename;
                            d.Url = _path;
                            d.UserName = Global.username;
                            d.Type = intp;
                         //   label3.Text = path;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
