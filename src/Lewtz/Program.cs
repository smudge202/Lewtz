using Compose;
using Lewtz.Services;
using System;

namespace Lewtz
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
			var app = new WindowsFormsApplication();
			app.UseServices(services =>
			{
				services.AddServices();
				services.AddForms();
			});
			app.UseLewtz();
			app.Execute();
        }
    }
}
