using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDetails
{
    // Data-access class for the Emp_details table.
    // This is the original EmployeeDetails design, extended with CreatedBy
    // so every new employee record is linked to the user who created it.
    class Employee
    {
        private static string myConn =
            ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Age { get; set; }        // maps to column EmpAge
        public string ContactNo { get; set; }  // maps to column EmpContact
        public string Gender { get; set; }
        public int CreatedBy { get; set; }      // the link to Users.UserID

        // LEFT JOIN (not JOIN): rows migrated from the old app have
        // CreatedBy = NULL, and an inner join would silently hide them.
        private const string SelectQuery =
            @"SELECT e.EmpId, e.EmpName, e.EmpAge, e.EmpContact, e.EmpGender,
                     u.Username AS CreatedBy
              FROM   Emp_details e
              LEFT JOIN Users u ON e.CreatedBy = u.UserID";

        private const string SearchQuery =
            @"SELECT e.EmpId, e.EmpName, e.EmpAge, e.EmpContact, e.EmpGender,
                     u.Username AS CreatedBy
              FROM   Emp_details e
              LEFT JOIN Users u ON e.CreatedBy = u.UserID
              WHERE  e.EmpId LIKE @kw OR e.EmpName LIKE @kw";

        private const string InsertQuery =
            @"INSERT INTO Emp_details (EmpId, EmpName, EmpAge, EmpContact, EmpGender, CreatedBy)
              VALUES (@EmpId, @EmpName, @EmpAge, @EmpContact, @EmpGender, @CreatedBy)";

        private const string UpdateQuery =
            @"UPDATE Emp_details
              SET EmpName = @EmpName, EmpAge = @EmpAge, EmpContact = @EmpContact, EmpGender = @EmpGender
              WHERE EmpId = @EmpId";

        private const string DeleteQuery =
            "DELETE FROM Emp_details WHERE EmpId = @EmpId";

        public DataTable GetEmployees()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand com = new SqlCommand(SelectQuery, con))
            using (SqlDataAdapter da = new SqlDataAdapter(com))
            {
                da.Fill(dt);
            }
            return dt;
        }

        // BONUS 2 (part 1): search by ID or name using LIKE @kw.
        // An empty keyword returns everything (LIKE '%%'), so it doubles as "show all".
        public DataTable SearchEmployees(string keyword)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand com = new SqlCommand(SearchQuery, con))
            {
                com.Parameters.AddWithValue("@kw", "%" + (keyword ?? string.Empty) + "%");
                using (SqlDataAdapter da = new SqlDataAdapter(com))
                    da.Fill(dt);
            }
            return dt;
        }

        public bool InsertEmployee(Employee employee)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand com = new SqlCommand(InsertQuery, con))
            {
                com.Parameters.AddWithValue("@EmpId", employee.EmpId);
                com.Parameters.AddWithValue("@EmpName", employee.EmpName);
                com.Parameters.AddWithValue("@EmpAge", employee.Age);
                com.Parameters.AddWithValue("@EmpContact", employee.ContactNo);
                com.Parameters.AddWithValue("@EmpGender", employee.Gender);
                com.Parameters.AddWithValue("@CreatedBy", employee.CreatedBy);
                con.Open();
                rows = com.ExecuteNonQuery();
            }
            return rows > 0;
        }

        public bool UpdateEmployee(Employee employee)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand com = new SqlCommand(UpdateQuery, con))
            {
                com.Parameters.AddWithValue("@EmpName", employee.EmpName);
                com.Parameters.AddWithValue("@EmpAge", employee.Age);
                com.Parameters.AddWithValue("@EmpContact", employee.ContactNo);
                com.Parameters.AddWithValue("@EmpGender", employee.Gender);
                com.Parameters.AddWithValue("@EmpId", employee.EmpId);
                con.Open();
                rows = com.ExecuteNonQuery();
            }
            return rows > 0;
        }

        public bool DeleteEmployee(Employee employee)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand com = new SqlCommand(DeleteQuery, con))
            {
                com.Parameters.AddWithValue("@EmpId", employee.EmpId);
                con.Open();
                rows = com.ExecuteNonQuery();
            }
            return rows > 0;
        }
    }
}
