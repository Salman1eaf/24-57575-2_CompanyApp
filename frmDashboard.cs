using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeDetails
{
    public partial class frmDashboard : Form
    {
        private readonly Employee employee = new Employee();

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome, " + (Session.Username ?? "user") + "!";
            LoadGrid("");
        }

        // Bind by the query result. Because the SELECT uses a LEFT JOIN,
        // the grid also shows who created each employee (CreatedBy = Username).
        private void LoadGrid(string keyword)
        {
            try
            {
                dgvSearchResult.DataSource = employee.SearchEmployees(keyword);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid(txtSearch.Text.Trim());
        }

        private void btnManageEmployees_Click(object sender, EventArgs e)
        {
            new frmEmployee().ShowDialog();   // modal: dashboard waits
            LoadGrid(txtSearch.Text.Trim());  // refresh after CRUD changes
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            Session.Clear();

            // Show a FRESH, cleared login window BEFORE closing the dashboard,
            // then close only the dashboard (not the application).
            frmLogin login = new frmLogin();
            login.Show();
            this.Close();
        }
    }
}
