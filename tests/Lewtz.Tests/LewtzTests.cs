using FluentAssertions;
using System;
using Xunit;

namespace Lewtz.Tests
{
	public class LewtzTests
	{
		[Fact]
		public void WhenLootGeneratorNotProvidedThenThrowsException()
		{
			Action act = () => new FormLewtz(null);
			act.ShouldThrow<ArgumentNullException>();
		}
	}
}
