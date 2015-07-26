using Compose;
using Service;
using System;

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
				services
					.AddMvp()
					.AddServices();
			});
			app.UseLewtz();
			app.Execute();
        }
    }
}
