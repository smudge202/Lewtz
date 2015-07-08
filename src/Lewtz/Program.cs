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
			// This is an OWIN styled startup which gives you access
			// to dependency injection. For when you understand DI: You're welcome. ;)
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
