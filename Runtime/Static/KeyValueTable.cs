using System;
using System.Collections.Generic;
using UnityEngine;

namespace Exam.Data.Static
{
	[Serializable]
	public abstract class KeyValueTable<TKey, TValue>
	{
		[SerializeField] private List<TKey> k = new List<TKey>();
		[SerializeField] private List<TValue> v = new List<TValue>();

		public void OverrideFromDictionary(IDictionary<TKey, TValue> source)
		{
			k.Clear();
			v.Clear();
			foreach (KeyValuePair<TKey, TValue> item in source)
			{
				k.Add(item.Key);
				v.Add(item.Value);
			}
		}

		public IDictionary<TKey, TValue> ToDictionary()
		{
			IDictionary<TKey, TValue> result = new Dictionary<TKey, TValue>(k.Count);
			for (int i = 0; i < k.Count; ++i)
			{
				result.Add(k[i], v[i]);
			}

			return result;
		}

		public void Clear()
		{
			k.Clear();
			v.Clear();
		}
	}
}
