using Compose;
using Microsoft.Framework.DependencyInjection;

namespace Lewtz
{
	using System.Windows.Forms;
	internal static class ApplicationExtensions
	{
		public static void UseLewtz(this Executable app)
		{
			app.OnExecute(() =>
			{
				app
					.ApplicationServices
					.GetService<Data.SeedData>()
					.Generate();
					Application.Run(app.ApplicationServices.GetService<FormLewtz>());
            });
		}
	}
}
