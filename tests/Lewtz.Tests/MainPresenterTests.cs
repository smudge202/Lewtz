using FluentAssertions;
using Presentation.Presenters;
using System;
using TestAttributes;

namespace Lewtz.Tests
{
	public class MainPresenterTests
	{
		public class Constructor
		{
			private static object DefaultGenerator
			{
				get
				{
					return new object();
				}
			}

			private static object DefaultController
			{
				get
				{
					return new object();
				}
			}

			private static object DefaultView
			{
				get
				{
					return new object();
				}
			}

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
	}
}
