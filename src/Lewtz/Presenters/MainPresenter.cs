using System;
using System.Windows.Forms;

namespace Lewtz.Presenters
{
	public sealed class MainPresenter
	{
		public MainPresenter(object lootGenerator)
		{
			if (lootGenerator == null)
				throw new ArgumentNullException(nameof(lootGenerator));
		}

		internal void Exit()
		{
			Application.Exit();
		}
	}
}
