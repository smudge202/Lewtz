using FluentAssertions;
using Lewtz.Presenters;
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

			[Unit]
			public static void WhenLootGeneratorIsNullThenThrowsException()
			{
				Action act = () => new MainPresenter(null);
				act.ShouldThrow<ArgumentNullException>();
			}

			[Unit]
			public static void WhenLootGeneratorProvidedThenDoesNotThrowException()
			{
				Action act = () => new MainPresenter(DefaultGenerator);
				act.ShouldNotThrow<ArgumentNullException>();
			}
		}
	}
}
