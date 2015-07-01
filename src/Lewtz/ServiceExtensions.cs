using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;

namespace Lewtz
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddForms(this IServiceCollection services)
		{
			services.TryAdd(DefaultServices);
			return services;
		}

		public static IEnumerable<ServiceDescriptor> DefaultServices
		{
			get
			{
				yield return ServiceDescriptor.Transient<FormLewtz, FormLewtz>();
			}
		}
	}
}
