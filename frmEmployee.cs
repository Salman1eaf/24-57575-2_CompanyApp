using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EmployeeDetails
{
    // This is the old Form1, renamed to frmEmployee for the merged app.
    public partial class frmEmployee : Form
    {
        private readonly Employee employee = new Employee();

        public frmEmployee()
        {
            InitializeComponent();
        }

        // The grid is loaded in Form_Load (not the constructor) and wrapped in
        // try/catch, so the Visual Studio designer never tries to hit the DB.
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                dgvEmployeeDetails.DataSource = employee.GetEmployees();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool InputsValid()
        {
            if (txtEmpId.Text.Trim() == "" || txtEmpName.Text.Trim() == "" ||
                txtAge.Text.Trim() == "" || cboGender.SelectedItem == null)
            {
                MessageBox.Show("Emp Id, Name, Age and Gender are required.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            int parsedAge;
            if (!int.TryParse(txtAge.Text.Trim(), out parsedAge))
            {
                MessageBox.Show("Age must be a number.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private Employee ReadForm()
        {
            return new Employee
            {
                EmpId = txtEmpId.Text.Trim(),
                EmpName = txtEmpName.Text.Trim(),
                Age = txtAge.Text.Trim(),
                ContactNo = txtContactNo.Text.Trim(),
                Gender = cboGender.SelectedItem == null ? "" : cboGender.SelectedItem.ToString()
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!InputsValid()) return;
            try
            {
                Employee emp = ReadForm();
                emp.CreatedBy = Session.UserID;   // stamp the logged-in user

                if (employee.InsertEmployee(emp))
                {
                    RefreshGrid();
                    ClearControls();
                    MessageBox.Show("Employee has been added successfully.");
                }
                else
                {
                    MessageBox.Show("Could not add the employee. Please try again.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!InputsValid()) return;
            try
            {
                if (employee.UpdateEmployee(ReadForm()))
                {
                    RefreshGrid();
                    ClearControls();
                    MessageBox.Show("Employee has been updated successfully.");
                }
                else
                {
                    MessageBox.Show("No matching employee to update.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BONUS 2 (part 2): confirm before deleting.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEmpId.Text.Trim() == "")
            {
                MessageBox.Show("Select an employee from the grid first.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Delete employee " + txtEmpId.Text.Trim() + "?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                Employee emp = new Employee { EmpId = txtEmpId.Text.Trim() };
                if (employee.DeleteEmployee(emp))
                {
                    RefreshGrid();
                    ClearControls();
                    MessageBox.Show("Employee has been deleted successfully.");
                }
                else
                {
                    MessageBox.Show("No matching employee to delete.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnSearchEmp_Click(object sender, EventArgs e)
        {
            try
            {
                dgvEmployeeDetails.DataSource = employee.SearchEmployees(txtSearchEmp.Text.Trim());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Populate the input boxes when a grid row is clicked.
        // Both events are handled so clicking ANYWHERE on a row works —
        // the cell body (CellClick) or the grey row-header (RowHeaderMouseClick).
        private void dgvEmployeeDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) PopulateFromRow(e.RowIndex);
        }

        private void dgvEmployeeDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0) PopulateFromRow(e.RowIndex);
        }

        // Cells are read BY COLUMN NAME, not by position, so adding the
        // CreatedBy column does not shift which field lands where.
        private void PopulateFromRow(int rowIndex)
        {
            DataGridViewRow row = dgvEmployeeDetails.Rows[rowIndex];
            txtEmpId.Text = SafeCell(row, "EmpId");
            txtEmpName.Text = SafeCell(row, "EmpName");
            txtAge.Text = SafeCell(row, "EmpAge");
            txtContactNo.Text = SafeCell(row, "EmpContact");
            cboGender.Text = SafeCell(row, "EmpGender");
        }

        private static string SafeCell(DataGridViewRow row, string column)
        {
            object value = row.Cells[column].Value;
            return value == null ? "" : value.ToString();
        }

        private void ClearControls()
        {
            txtEmpId.Text = "";
            txtEmpName.Text = "";
            txtAge.Text = "";
            txtContactNo.Text = "";
            cboGender.SelectedIndex = -1;
            cboGender.Text = "";
        }
    }
}
