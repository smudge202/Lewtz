using FluentAssertions;
using Moq;
using System;
using TestAttributes;
using Xunit;

namespace Lewtz.Tests
{
	public class FormLewtzTests
	{
		[Unit]
		public void WhenNoPresenterSuppliedThenThrowsException()
		{
			Action act = () => new FormLewtz(null);
			act.ShouldThrow<ArgumentNullException>();
		}

		[Unit]
		public void WhenPresenterProvidedThenDoesNotThrowException()
		{
			Action act = () => new FormLewtz(new Mock<Presenters.IMainPresenter>().Object);
			Record.Exception(act).Should().BeNull();
		}

		// All controls, methods, and so forth on a Windows Form
		// are private, and therefore inaccessible to tests.
		// As a result (and to break up logic nicely) we pass all
		// information from the UI to/fro the Presenter, which we
		// can test.

		// This is the Model-View-Presenter pattern. However, because
		// I'm really not a fan of WinForms, I haven't gone ahead
		// and implemented the Model, nor the bindings for the View.
		// More than happy to provide some guidance on this if y
	}
}
