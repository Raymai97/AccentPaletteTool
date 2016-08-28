using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace AccentPaletteTool
{
    static class Program
    {
        public static ColorDialog colorDlg;
        public static frmAccentColorMenu acmDlg;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            colorDlg = new ColorDialog();
            acmDlg = new frmAccentColorMenu();
            Application.Run(new frmMain());
        }

    }
}
