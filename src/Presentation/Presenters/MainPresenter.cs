using System;

namespace Presentation.Presenters
{
	internal sealed class MainPresenter : IMainPresenter
	{
		private readonly IApplicationController _controller;

		public MainPresenter(object lootGenerator, IApplicationController controller, object view)
		{
			if (lootGenerator == null)
				throw new ArgumentNullException(nameof(lootGenerator));
			if (controller == null)
				throw new ArgumentNullException(nameof(controller));
			if (view == null)
				throw new ArgumentNullException(nameof(view));
			_controller = controller;
		}

		public void Exit()
		{
			_controller.Exit();
		}
	}
}
