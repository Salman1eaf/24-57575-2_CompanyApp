using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EmployeeDetails
{
    // Data-access class for the Users table.
    // Written in the SAME STYLE as Employee.cs (one class, all SQL as
    // named constants, connection string read once from App.config) so
    // the merged project has a single consistent design instead of two.
    class User
    {
        private static string myConn =
            ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // [Password] is bracketed because PASSWORD is a reserved word in T-SQL.
        private const string LoginQuery =
            "SELECT UserID FROM Users WHERE Username = @Username AND [Password] = @Password";
        private const string ExistsQuery =
            "SELECT COUNT(*) FROM Users WHERE Username = @Username";
        private const string RegisterQuery =
            "INSERT INTO Users (Username, [Password]) VALUES (@Username, @Password)";

        // Returns the UserID on success, or 0 when the credentials are wrong.
        // We need the real UserID (not just true/false) because it becomes
        // Session.UserID and then Emp_details.CreatedBy.
        public int ValidateLogin(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand com = new SqlCommand(LoginQuery, con))
            {
                com.Parameters.AddWithValue("@Username", username);
                com.Parameters.AddWithValue("@Password", Security.Sha256Hex(password));
                con.Open();
                object result = com.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);
            }
        }

        public bool UsernameExists(string username)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand com = new SqlCommand(ExistsQuery, con))
            {
                com.Parameters.AddWithValue("@Username", username);
                con.Open();
                return (int)com.ExecuteScalar() > 0;
            }
        }

        public bool RegisterUser(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(myConn))
            using (SqlCommand com = new SqlCommand(RegisterQuery, con))
            {
                com.Parameters.AddWithValue("@Username", username);
                com.Parameters.AddWithValue("@Password", Security.Sha256Hex(password));
                con.Open();
                return com.ExecuteNonQuery() > 0;
            }
        }
    }
}
