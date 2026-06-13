using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystemV20._0._1
{
    static class Program
    {

        /// <summary>
        /// Declare Public Static int UsrID to store ID of user in it
        /// in Program.cs to show in all project
        /// Declare it before [STAThread] 
        /// </summary>
        public static int UsrID;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new PAL.FRM_Intro());
            Application.Run(new PAL.FRM_Main());
        }
    }
}
