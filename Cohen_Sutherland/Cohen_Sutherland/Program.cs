using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cohen_Sutherland
{
    static class Program
    {

        /// <summary>
        /// Our Main Form
        /// </summary>
        internal static FormMain fmMain;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            fmMain = new FormMain();

            Application.Run(fmMain);

            



        }
    }
}
