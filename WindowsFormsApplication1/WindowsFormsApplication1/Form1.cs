using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //User user = new User();
            //Model1 db = new Model1();
            //var x= db.user.FirstOrDefault();
            //if (x != null)
            //    textBox1.Text = x.Name; 

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();

            User user = new User();
            user.Name = textBox1.Text.ToString();
            user.Password = textBox2.Text.ToString();
            var k = db.users.Where((s) => s.Name == user.Name && s.Password == user.Password)
                .FirstOrDefault();

            if (k == null)
                MessageBox.Show("invalid login credntials");
            else
            {
                textBox1.Text = user.Name;
                Global.username = user.Name;
                db.users.Add(user);
                db.SaveChanges();
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
