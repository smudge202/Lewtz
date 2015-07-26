using System;

namespace Presentation.Presenters
{
	public sealed class MainPresenter
	{
		public MainPresenter(object lootGenerator, object controller, object view)
		{
			if (lootGenerator == null)
				throw new ArgumentNullException(nameof(lootGenerator));
			if (controller == null)
				throw new ArgumentNullException(nameof(controller));
			if (view == null)
				throw new ArgumentNullException(nameof(view));
		}

		internal void Exit()
		{
			//Application.Exit();
		}
	}
}
