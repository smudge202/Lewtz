using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;

namespace Lewtz.Data
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddDataServices(this IServiceCollection services)
		{
			services.TryAdd(DefaultServices);
			return services;
		}

		public static IEnumerable<ServiceDescriptor> DefaultServices
		{
			get
			{
				yield return ServiceDescriptor.Transient<SeedData, HardcodedDataSeed>();
				yield return ServiceDescriptor.Transient<DataContext, Context>();
			}
		}
	}
}
