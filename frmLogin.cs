using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter both username and password.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int userId = new User().ValidateLogin(txtUsername.Text.Trim(), txtPassword.Text);

                if (userId > 0)
                {
                    // Remember who logged in so the CRUD screen can stamp CreatedBy.
                    Session.UserID = userId;
                    Session.Username = txtUsername.Text.Trim();

                    new frmDashboard().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong username or password, please try again.",
                        "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        // If the login window is closed (the X), end the whole application.
        // Without this, a login form that was only Hide()den earlier can keep
        // the process alive invisibly after every visible window is gone.
        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
