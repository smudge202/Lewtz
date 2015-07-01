using Lewtz.Data;
using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;

namespace Lewtz.Services
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.TryAdd(DefaultServices);
			return services
				.AddDataServices();
		}

		public static IEnumerable<ServiceDescriptor> DefaultServices
		{
			get
			{
				yield return ServiceDescriptor.Transient<GenerateLoot, DefaultLootGenerator>();
			}
		}
	}
}
