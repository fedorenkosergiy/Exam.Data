using Exam.Data.Static;
using System;
using UnityEngine;

namespace Exam.Data.Dynamic
{
	[Serializable]
	public class DynamicTranslationData : TranslationData
	{
		[SerializeReference] private TranslationData source;
		[SerializeField] private string template;
		[SerializeField] private string[] args;

		public string this[string language]
		{
			get
			{
				object[] arguments = new object[args.Length + 1];
				arguments[0] = source[language];
				Array.Copy(args, 0, arguments, 1, args.Length);

				return string.Format(template, arguments);
			}
		}

		public string GetTranslation(string language, string fallbackLanguage)
		{
			object[] arguments = new object[args.Length + 1];
			arguments[0] = source.GetTranslation(language, fallbackLanguage);
			Array.Copy(args, 0, arguments, 1, args.Length);

			return string.Format(template, arguments);
		}

		public DynamicTranslationData(TranslationData source, string template, params string[] args)
		{
			this.source = source;
			this.template = template;
			this.args = args;
		}

		public DynamicTranslationData() { }
	}
}
