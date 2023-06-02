using Exam.Data.Dynamic;
using Exam.Data.Static;
using UnityEngine.Pool;
using System;
using System.Collections.Generic;
using Exam.Config;

namespace Exam.Data
{
	[Serializable]
	public class DefaultWorkByTopicContext : DatabaseContext
	{
		private IDictionary<RuleNodeData, HashSet<QuestionData>> data =
		new Dictionary<RuleNodeData, HashSet<QuestionData>>();
		[NonSerialized] private GlobalRuntimeConfig config;

		public void Init(IEnumerable<QuestionData> questions, GlobalRuntimeConfig config)
		{
			data.Clear();

			foreach (QuestionData question in questions)
			{
				RuleNodeData[] rules = question.Rules;

				for (int i = 0; i < rules.Length; ++i)
				{
					RuleNodeData topic = GetTopic(rules[i]);

					if (!data.TryGetValue(topic, out HashSet<QuestionData> set))
					{
						set = new HashSet<QuestionData>();
						data.Add(topic, set);
					}

					set.Add(question);
				}
			}

			this.config = config;
		}

		private RuleNodeData GetTopic(RuleNodeData rule)
		{
			if (IsRuleNodeATopic(rule)) { return rule; }

			return GetTopic(rule.Parent);
		}

		private bool IsRuleNodeATopic(RuleNodeData rule) { return rule.Parent.IsRoot; }

		public bool IsTestValid(TestData test) { throw new NotImplementedException(); }

		public bool TryGenerateTests(out IEnumerable<TestData> tests)
		{
			bool result = !data.IsEmptyCollection();

			if (result)
			{
				List<TestData> generatedTests = new List<TestData>();
				List<RuleNodeData> rules = new List<RuleNodeData>(data.Keys);
				rules.Sort();

				foreach (RuleNodeData topic in rules)
				{
					List<QuestionData> allQuestions = ListPool<QuestionData>.Get();
					allQuestions.AddRange(data[topic]);
					List<QuestionData> questions;

					for (int i = 0;
						 i <= allQuestions.Count - config.MaxQuestionsPerTest;
						 i += config.MaxQuestionsPerTest)
					{
						questions = allQuestions.GetRange(i, config.MaxQuestionsPerTest);
						TestData test = GenerateTest(topic, questions, i + 1, i + config.MaxQuestionsPerTest);
						generatedTests.Add(test);
					}

					int questionsLeft = allQuestions.Count % config.MaxQuestionsPerTest;

					if (questionsLeft > 0)
					{
						questions = allQuestions.GetRange(allQuestions.Count - questionsLeft, questionsLeft);

						TestData test = GenerateTest(topic,
													 questions,
													 allQuestions.Count - questionsLeft + 1,
													 allQuestions.Count);

						generatedTests.Add(test);
					}

					ListPool<QuestionData>.Release(allQuestions);
				}

				tests = generatedTests;
			}
			else { tests = default; }

			return result;
		}

		private static TestData GenerateTest(RuleNodeData topic, List<QuestionData> questions, int from, int to)
		{
			StyleData style = topic.Preview.Style;
			const string template = "{0} ({1}-{2})";

			TranslationData text =
			new DynamicTranslationData(topic.Preview.Text, template, from.ToString(), to.ToString());

			ContentPieceData content = new DefaultContentPieceData(style, text, null);
			TestData test = new DefaultTestData(content, content, questions);

			return test;
		}
	}
}
