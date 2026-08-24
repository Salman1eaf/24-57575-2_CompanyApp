using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Original bug: this used && so it only complained when ALL boxes
            // were empty. It must be || so any empty box is caught.
            if (txtUsername.Text.Trim() == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("All fields are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtPassword.Focus();
                return;
            }

            try
            {
                User user = new User();

                if (user.UsernameExists(txtUsername.Text.Trim()))
                {
                    MessageBox.Show("Username already exists. Please choose another.",
                        "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (user.RegisterUser(txtUsername.Text.Trim(), txtPassword.Text))
                {
                    MessageBox.Show("Account created successfully! Please log in.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new frmLogin().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Could not create the account. Please try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
