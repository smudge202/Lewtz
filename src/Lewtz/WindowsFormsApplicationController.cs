using Presentation;
using System.Windows.Forms;

namespace WinForms
{
	internal sealed class WindowsFormsApplicationController : IApplicationController
	{
		public void Exit()
		{
			Application.Exit();
		}
	}
}
