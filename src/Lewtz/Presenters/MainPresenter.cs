using System.Windows.Forms;

namespace Lewtz.Presenters
{
	internal sealed class MainPresenter : IMainPresenter
	{
		public void TerminateApplication()
		{
			Application.Exit();
		}
	}
}
