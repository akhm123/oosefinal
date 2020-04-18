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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbContextclass db = new DbContextclass();

            User user = new User();
            user.UserName = textBox1.Text.ToString();
            user.Password = textBox2.Text.ToString();
            var k = db.users.Where((s) => s.UserName == user.UserName && s.Password == user.Password)
                .FirstOrDefault();

            if (k == null)
                MessageBox.Show("invalid login credntials");
            else
            {
                //textBox1.Text = user.Name;
                Global.username = user.UserName;
                //db.users.Add(user);
                //db.SaveChanges();
                // DocumentUpload obj1 = new DocumentUpload();
                viewallfile obj1 = new viewallfile();
                obj1.Show();
                this.Hide();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Registration obj = new Registration();
            obj.Show();
            this.Hide();
        }
    }
}
