using System;
using System.Windows.Forms;

namespace Lewtz.Presenters
{
	internal sealed class MainPresenter
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

		internal void GenerateLoot()
		{

		}
	}
}
