using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentMangement;
using DocumentMangement.Models;

namespace DocumentMangement
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != textBox2.Text)
            {
                MessageBox.Show("password and confirm pass does not match");

            }
            else
            {
               

                User user = new User();
                user.UserName = textBox1.Text.ToString();
                user.Password = textBox2.Text.ToString();
                user.Email = textBox3.Text.ToString();
                user.ContactNo = textBox4.Text.ToString();
                //   textBox1.Text = user.Name;
                DbContextclass db = new DbContextclass();


               var olduser= db.users.Where(x => x.UserName == user.UserName).FirstOrDefault();
                if (olduser == null)
                {
                    db.users.Add(user);
                    db.SaveChanges();
                    Form1 obj1 = new Form1();
                    obj1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User Already Exists");
                }
            }
        }
    }
}
