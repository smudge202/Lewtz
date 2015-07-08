using System;

namespace Lewtz.Services
{
	internal sealed class DefaultLootGenerator : GenerateLoot
	{
		public LootResult Generate(LootRequest request)
		{
			if (request == null)
				throw new ArgumentNullException("request");
			throw new NotImplementedException();
		}
	}
}
