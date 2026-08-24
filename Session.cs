using System;

namespace EmployeeDetails
{
    // Holds the identity of whoever is currently logged in.
    // The CRUD screen reads Session.UserID to stamp Emp_details.CreatedBy,
    // which is how the two former apps (Users + Employees) are linked.
    static class Session
    {
        public static int UserID { get; set; }
        public static string Username { get; set; }

        public static void Clear()
        {
            UserID = 0;
            Username = null;
        }
    }
}
