using Compose;
using Presentation;
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
					.AddViews()
					.AddMvp();
			});
			app.UseLewtz();
			app.Execute();
        }
    }
}
