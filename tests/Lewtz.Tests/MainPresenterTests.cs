using FluentAssertions;
using Moq;
using Presentation;
using Presentation.Presenters;
using System;
using TestAttributes;

namespace WinForms.Tests
{
	public class MainPresenterTests
	{
		private static object DefaultGenerator
		{
			get
			{
				return new object();
			}
		}

		private static IApplicationController DefaultController
		{
			get
			{
				return new Mock<IApplicationController>().Object;
			}
		}

		private static object DefaultView
		{
			get
			{
				return new object();
			}
		}

		public class Constructor
		{
			[Unit]
			public static void WhenLootGeneratorIsNullThenThrowsException()
			{
				Action act = () => new MainPresenter(null, DefaultController, DefaultView);
				act.ShouldThrow<ArgumentNullException>();
			}

			[Unit]
			public static void WhenApplicationControllerIsNullThenThrowsException()
			{
				Action act = () => new MainPresenter(DefaultGenerator, null, DefaultView);
				act.ShouldThrow<ArgumentNullException>();
			}

			[Unit]
			public static void WhenViewIsNullThenThrowsException()
			{
				Action act = () => new MainPresenter(DefaultGenerator, DefaultController, null);
				act.ShouldThrow<ArgumentNullException>();
			}

			[Unit]
			public static void WhenDependenciesProvidedThenDoesNotThrowException()
			{
				Action act = () => new MainPresenter(DefaultGenerator, DefaultController, DefaultView);
				act.ShouldNotThrow<ArgumentNullException>();
			}
		}

		public class Exit
		{
			private static IMainPresenter CreateTarget(
				object lootGenerator = null,
				IApplicationController controller = null,
				object view = null)
			{
				return new MainPresenter(
					lootGenerator ?? DefaultGenerator,
					controller ?? DefaultController,
					view ?? DefaultView);
            }

			[Unit]
			public static void WhenInvokedThenCallsExitOnController()
			{
				var controller = new Mock<IApplicationController>();
				CreateTarget(controller: controller.Object).Exit();
				controller.Verify(m => m.Exit(), Times.Once);
			}
		}
	}
}
