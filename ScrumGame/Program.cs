using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrumGame
{
    static class Program
    {
        public static Form Properties { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetupForm setup = new SetupForm();
            setup.ShowDialog();
            Properties = new MainForm((int)setup.NumPlayersNumericUpDown.Value);
            Application.Run(Properties);
        }
    }
}
