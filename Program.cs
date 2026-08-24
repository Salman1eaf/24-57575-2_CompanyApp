using System;
using System.Windows.Forms;

namespace EmployeeDetails
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());   // single entry point; app starts at Login
        }
    }
}
