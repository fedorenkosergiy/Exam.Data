using Exam.Data.Abstraction;
using System;
using LangToValue = System.Collections.Generic.IDictionary<string, string>;
using UnityEngine;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultTranslationData : TranslationData
	{
		[SerializeField] private StringsTable t = new StringsTable();

		private LangToValue table;

		private LangToValue Table => table ??= t.ToDictionary();

		public string this[string language] => !Table.TryGetValue(language, out string result) ? "" : result;

		public DefaultTranslationData(TranslationInfo[] translations)
		{
			for (int i = 0; i < translations.Length; ++i)
			{
				Table.Add(translations[i].Language, translations[i].Value);
			}

			t.OverrideFromDictionary(Table);
		}

		public DefaultTranslationData() { }

		public string GetTranslation(string language, string fallbackLanguage)
		{
			if (Table.TryGetValue(language, out string result)) { return result; }

			return !Table.TryGetValue(fallbackLanguage, out result) ? "" : result;
		}
	}
}
