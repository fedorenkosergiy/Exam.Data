using Exam.Data.Static;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultStaticDatabase : StaticDatabase, DeserializationPostprocessor
	{
		[SerializeField] private List<string> languages;
		[SerializeReference] private List<TestData> tests;
		[SerializeReference] private List<QuestionData> questions;
		[SerializeReference] private List<StyleData> styles;
		[SerializeReference] private RulesRootData rules;

		public IReadOnlyList<string> Languages => languages;

		public IReadOnlyList<TestData> Tests => tests;

		public IReadOnlyList<QuestionData> Questions => questions;

		public IReadOnlyList<SetData> Sets => throw new NotImplementedException();

		public IReadOnlyList<SubsetData> Subsets => throw new NotImplementedException();

		public IReadOnlyList<StyleData> Styles => styles;

		public RulesRootData Rules => rules;

		public IReadOnlyDictionary<int, QuestionData> QuestionById => throw new NotImplementedException();

		public IReadOnlyList<QuestionKeywordData> Keywords => throw new NotImplementedException();

		public DefaultStaticDatabase(ICollection<string> languages,
									 ICollection<TestData> tests,
									 ICollection<QuestionData> questions,
									 ICollection<SetData> sets,
									 ICollection<SubsetData> subsets,
									 ICollection<StyleData> styles,
									 ICollection<QuestionKeywordData> keywords,
									 RulesRootData rules,
									 ICollection<KeyValuePair<string, int>> guidToId)
		{
			this.languages = new List<string>(languages);
			this.tests = new List<TestData>(tests);
			this.questions = new List<QuestionData>(questions);
			this.styles = new List<StyleData>(styles);
			this.rules = rules;
			Dictionary<string, int> guids = new Dictionary<string, int>();

			foreach (var pair in guidToId) { guids.Add(pair.Key, pair.Value); }
		}

		public DefaultStaticDatabase() { }

		public int GetId(string guid) => throw new NotImplementedException();

		public void RunDeserializationPostprocessing(ISet<DeserializationPostprocessor> alreadyHandled)
		{
			if (!alreadyHandled.Add(this)) return;

			for (int i = 0; i < Questions.Count; ++i)
			{
				(Questions[i] as DeserializationPostprocessor)?.RunDeserializationPostprocessing(alreadyHandled);
			}

			(Rules.Rule as DeserializationPostprocessor)?.RunDeserializationPostprocessing(alreadyHandled);
		}
	}
}
