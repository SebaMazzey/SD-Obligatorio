using CircuitosApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartamentoApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setup baseUrl and circuitNumber
            HttpService.AddBaseUrl("http://localhost:8001");
            var circuitNumber = 0;

            Application.Run(new AppVotos(circuitNumber));
        }
    }
}
