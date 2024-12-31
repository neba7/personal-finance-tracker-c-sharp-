using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_finance_tracker_c_sharp_
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            db newdb1 = new db();

            string name = nameBox.Text;
            string password = passwordBox.Text;

            bool check = newdb1.login(name, password);

            if (check) 
            {
                dashboard newdashboard1 = new dashboard();
                this.Hide();
                newdashboard1.ShowDialog();
                this.Show();
            }
            else
            {

                MessageBox.Show("Incorrect name or password", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            signup newsignup = new signup();
            this.Hide();    
            newsignup.ShowDialog();
            this.Show();
        }
    }
}
