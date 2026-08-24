namespace EmployeeDetails
{
    partial class frmEmployee
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEmpId = new System.Windows.Forms.Label();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtEmpId = new System.Windows.Forms.TextBox();
            this.txtEmpName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSearchEmp = new System.Windows.Forms.Label();
            this.txtSearchEmp = new System.Windows.Forms.TextBox();
            this.btnSearchEmp = new System.Windows.Forms.Button();
            this.dgvEmployeeDetails = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeDetails)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(160, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Employee Details";
            //
            // lblEmpId
            //
            this.lblEmpId.AutoSize = true;
            this.lblEmpId.Location = new System.Drawing.Point(24, 70);
            this.lblEmpId.Name = "lblEmpId";
            this.lblEmpId.Size = new System.Drawing.Size(46, 15);
            this.lblEmpId.TabIndex = 1;
            this.lblEmpId.Text = "Emp Id:";
            //
            // lblEmpName
            //
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Location = new System.Drawing.Point(24, 105);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(70, 15);
            this.lblEmpName.TabIndex = 2;
            this.lblEmpName.Text = "Emp Name:";
            //
            // lblAge
            //
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(24, 140);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 15);
            this.lblAge.TabIndex = 3;
            this.lblAge.Text = "Age:";
            //
            // lblContact
            //
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(24, 175);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(60, 15);
            this.lblContact.TabIndex = 4;
            this.lblContact.Text = "Contact #:";
            //
            // lblGender
            //
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(24, 210);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(50, 15);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "Gender:";
            //
            // txtEmpId
            //
            this.txtEmpId.Location = new System.Drawing.Point(110, 67);
            this.txtEmpId.Name = "txtEmpId";
            this.txtEmpId.Size = new System.Drawing.Size(200, 23);
            this.txtEmpId.TabIndex = 6;
            //
            // txtEmpName
            //
            this.txtEmpName.Location = new System.Drawing.Point(110, 102);
            this.txtEmpName.Name = "txtEmpName";
            this.txtEmpName.Size = new System.Drawing.Size(200, 23);
            this.txtEmpName.TabIndex = 7;
            //
            // txtAge
            //
            this.txtAge.Location = new System.Drawing.Point(110, 137);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(200, 23);
            this.txtAge.TabIndex = 8;
            //
            // txtContactNo
            //
            this.txtContactNo.Location = new System.Drawing.Point(110, 172);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(200, 23);
            this.txtContactNo.TabIndex = 9;
            //
            // cboGender
            //
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cboGender.Location = new System.Drawing.Point(110, 207);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(200, 23);
            this.cboGender.TabIndex = 10;
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(24, 255);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(65, 30);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnUpdate
            //
            this.btnUpdate.Location = new System.Drawing.Point(95, 255);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(65, 30);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(166, 255);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 30);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnClear
            //
            this.btnClear.Location = new System.Drawing.Point(237, 255);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 30);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // lblSearchEmp
            //
            this.lblSearchEmp.AutoSize = true;
            this.lblSearchEmp.Location = new System.Drawing.Point(350, 70);
            this.lblSearchEmp.Name = "lblSearchEmp";
            this.lblSearchEmp.Size = new System.Drawing.Size(115, 15);
            this.lblSearchEmp.TabIndex = 15;
            this.lblSearchEmp.Text = "Search ID or Name:";
            //
            // txtSearchEmp
            //
            this.txtSearchEmp.Location = new System.Drawing.Point(470, 67);
            this.txtSearchEmp.Name = "txtSearchEmp";
            this.txtSearchEmp.Size = new System.Drawing.Size(200, 23);
            this.txtSearchEmp.TabIndex = 16;
            //
            // btnSearchEmp
            //
            this.btnSearchEmp.Location = new System.Drawing.Point(680, 66);
            this.btnSearchEmp.Name = "btnSearchEmp";
            this.btnSearchEmp.Size = new System.Drawing.Size(80, 26);
            this.btnSearchEmp.TabIndex = 17;
            this.btnSearchEmp.Text = "Search";
            this.btnSearchEmp.UseVisualStyleBackColor = true;
            this.btnSearchEmp.Click += new System.EventHandler(this.btnSearchEmp_Click);
            //
            // dgvEmployeeDetails
            //
            this.dgvEmployeeDetails.AllowUserToAddRows = false;
            this.dgvEmployeeDetails.AllowUserToDeleteRows = false;
            this.dgvEmployeeDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeDetails.Location = new System.Drawing.Point(350, 105);
            this.dgvEmployeeDetails.Name = "dgvEmployeeDetails";
            this.dgvEmployeeDetails.ReadOnly = true;
            this.dgvEmployeeDetails.RowTemplate.Height = 25;
            this.dgvEmployeeDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeDetails.Size = new System.Drawing.Size(410, 320);
            this.dgvEmployeeDetails.TabIndex = 18;
            this.dgvEmployeeDetails.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEmployeeDetails_RowHeaderMouseClick);
            this.dgvEmployeeDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeeDetails_CellClick);
            //
            // frmEmployee
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 451);
            this.Controls.Add(this.dgvEmployeeDetails);
            this.Controls.Add(this.btnSearchEmp);
            this.Controls.Add(this.txtSearchEmp);
            this.Controls.Add(this.lblSearchEmp);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtEmpName);
            this.Controls.Add(this.txtEmpId);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblEmpName);
            this.Controls.Add(this.lblEmpId);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Management";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmpId;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtEmpId;
        private System.Windows.Forms.TextBox txtEmpName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSearchEmp;
        private System.Windows.Forms.TextBox txtSearchEmp;
        private System.Windows.Forms.Button btnSearchEmp;
        private System.Windows.Forms.DataGridView dgvEmployeeDetails;
    }
}
