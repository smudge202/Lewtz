using Microsoft.Framework.DependencyInjection;
using Presentation;
using System.Collections.Generic;

namespace WinForms
{
	internal static class ServiceExtensions
	{
		public static IServiceCollection AddViews(this IServiceCollection services)
		{
			services.TryAdd(GetDefaultServices());
			return services;
		}

		public static IEnumerable<ServiceDescriptor> GetDefaultServices()
		{
			yield return ServiceDescriptor.Transient<IApplicationController, WindowsFormsApplicationController>();
			yield return ServiceDescriptor.Transient<FormLewtz, FormLewtz>();
		}
	}
}
