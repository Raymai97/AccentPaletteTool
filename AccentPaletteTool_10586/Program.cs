using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace AccentPaletteTool_10586
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //if (Args.Length > 1)
            //{
            //    switch (Args[1])
            //    {
            //        case "-restartDWM" :
            //            RestartDWM();
            //            return;
            //    }
            //}
            Application.Run(new frmMain());
        }

        //public static void RestartDWM() // This tool doesn't need this...
        //{
        //    if (Environment.OSVersion.Version.Build >= 9200)
        //    {
        //        var procs = Process.GetProcessesByName("dwm");
        //        foreach (var p in procs)
        //        {
        //            if (System.IO.Path.GetDirectoryName(p.MainModule.FileName) ==
        //                Environment.GetFolderPath(Environment.SpecialFolder.System))
        //            {
        //                p.Kill();
        //            }

        //        }
        //    }
        //    else
        //    {
        //        throw new NotSupportedException("RestartDWM only supports Win8 or newer OS.");
        //    }
        //}

        public static string[] Args = Environment.GetCommandLineArgs();

        public static bool IsRunAsAdmin()
        {
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static bool TryRestartAsAdmin(string Arguments = "")
        {
            var pInfo = new ProcessStartInfo();
            pInfo.FileName = Application.ExecutablePath;
            pInfo.WorkingDirectory = Environment.CurrentDirectory;
            pInfo.Verb = "runas";
            pInfo.UseShellExecute = true;
            if (Arguments == "")
            {
                for (int i = 1; i < Args.Length; i++)
                {
                    pInfo.Arguments += Args[i] + " ";
                }
            }
            else
            {
                pInfo.Arguments = Arguments;
            }
            try
            {
                Process.Start(pInfo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
