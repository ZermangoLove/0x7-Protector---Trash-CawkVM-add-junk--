using System;
using System.Collections.Generic;

namespace Helpers.MethodBlocks
{
	public static class BlockUtils
	{
		public static void AddListEntry<TKey, TValue>(this IDictionary<TKey, List<TValue>> self, TKey key, TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (!self.TryGetValue(key, out var value2))
			{
				List<TValue> list2 = (self[key] = new List<TValue>());
				value2 = list2;
			}
			value2.Add(value);
		}
	}
}
