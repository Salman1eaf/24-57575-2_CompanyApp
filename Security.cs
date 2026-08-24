using System;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeDetails
{
    // BONUS 1: passwords are never stored in plain text.
    // We store the lowercase-hex SHA-256 of the password. The same
    // function is used at register time and at login time, and the
    // migrated Access accounts in Schema.sql are stored as these exact
    // hashes, so everything compares consistently.
    static class Security
    {
        public static string Sha256Hex(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input ?? string.Empty));
                StringBuilder sb = new StringBuilder(bytes.Length * 2);
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
