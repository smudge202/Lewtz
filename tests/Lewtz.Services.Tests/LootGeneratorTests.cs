using FluentAssertions;
using Microsoft.Framework.DependencyInjection;
using System;
using TestAttributes;

namespace Lewtz.Services.Tests
{
	public class LootGeneratorTests
	{
		[Unit]
		public static void WhenRequestIsNullThenThrowsException()
		{
			Action act = () => GetLootGenerator().Generate(null);
			act.ShouldThrow<ArgumentNullException>();
		}

		private static GenerateLoot GetLootGenerator()
		{
			return new ServiceCollection()
				.AddServices()
				.BuildServiceProvider()
				.GetRequiredService<GenerateLoot>();
		}
	}
}
