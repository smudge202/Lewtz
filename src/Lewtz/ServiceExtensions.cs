using Lewtz.Presenters;
using Microsoft.Framework.DependencyInjection;
using System.Collections.Generic;

namespace Lewtz
{
	internal static class ServiceExtensions
	{
		public static IServiceCollection AddMvp(this IServiceCollection services)
		{
			services.TryAdd(GetDefaultServices());
			return services;
		}

		public static IEnumerable<ServiceDescriptor> GetDefaultServices()
		{
			yield return ServiceDescriptor.Transient<MainPresenter, MainPresenter>();
		}
	}
}
