using Compose;

namespace Lewtz
{
	using System;
	using System.Windows.Forms;
	using Microsoft.Framework.DependencyInjection;

	internal sealed class WindowsFormsApplication : Executable
	{
		public override void Execute()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			base.Execute();
		}
	}
}
