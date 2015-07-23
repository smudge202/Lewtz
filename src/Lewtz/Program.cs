using Compose;
using System;
using System.Windows.Forms;

namespace Lewtz
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			var app = new WindowsFormsApplication();
			app.UseServices(services =>
			{

			});
			app.UseLewtz();
			app.Execute();
        }
    }
}
