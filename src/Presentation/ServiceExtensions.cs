using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;

namespace Presentation
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddMvp(this IServiceCollection services)
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
