using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;

namespace Service
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.TryAdd(GetDefaultServices());
			return services;
		}

		public static IEnumerable<ServiceDescriptor> GetDefaultServices()
		{
			yield break;
		}
	}
}
