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
    public partial class signup : Form
    {
        
        public signup()
        {
            InitializeComponent();
            
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string email = emailBox.Text;
            string password = passwordBox.Text;

            db newdb1 = new db();

            if (newdb1.user_check_by_name(name))
            {
                MessageBox.Show("User already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (newdb1.user_check_by_email(email)) 
            {
                MessageBox.Show("email already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int row = newdb1.insert(name, password, email);
                if (row > 0)
                {
                    MessageBox.Show("User created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Close();
                }
            }
        }

        private void signup_Load(object sender, EventArgs e)
        {

        }

        
    }
}
