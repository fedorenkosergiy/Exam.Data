using Exam.Data.Abstraction;
using UnityEngine.Pool;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static System.StringSplitOptions;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultQuestionData : QuestionData, DeserializationPostprocessor
	{
		[SerializeField] private int id;
		[SerializeField] private int r;
		[SerializeField] private bool ee;
		[SerializeField] private string[] l;

		[SerializeReference] private AnswerData[] answers;
		[SerializeReference] private ContentPieceData c;
		[SerializeReference] private ContentPieceData p;
		[SerializeReference] private ExplanationPieceData[] e;
		[SerializeReference] private RuleNodeData[] rs;

		public int Id => id;
		public int Revision => r;
		public bool IsExplanationEnabled => ee;
		public bool IsEnabled => throw new NotImplementedException();
		public string Code => throw new NotImplementedException();
		public string[] Labels => l;
		public AnswerData[] Answers => answers;
		public HelpPieceData[] Help => throw new NotImplementedException();
		public RuleNodeData[] Rules => rs;
		public SetData[] Sets => throw new NotImplementedException();
		public ContentPieceData Content => c;
		public ContentPieceData Preview => p;
		public ExplanationPieceData[] Explanation => e;

		public DefaultQuestionData(
			IEnumerable<AnswerData> answers,
			QuestionInfo question,
			ContentPieceData content,
			IEnumerable<ExplanationPieceData> explanation,
			IEnumerable<RuleNodeData> rules)
		{
			List<AnswerData> list = ListPool<AnswerData>.Get();
			list.AddRange(answers);
			list.Sort();
			this.answers = list.ToArray();
			ListPool<AnswerData>.Release(list);

			c = content;
			r = question.Revision;
			ee = question.IsExplanationEnabled.ToBool();
			e = explanation.ToArray();
			id = question.GetId();
			if (question.Labels.IsSmth())
			{
				char[] dividers = { ',' };
				l = question.Labels.Split(dividers, RemoveEmptyEntries);
			}
			else
			{
				l = default;
			}

			HashSet<RuleNodeData> uniqueRules = new HashSet<RuleNodeData>();
			foreach (RuleNodeData rule in rules)
			{
				uniqueRules.Add(rule);
			}

			rs = uniqueRules.ToArray();
		}

		public DefaultQuestionData()
		{
		}

		public void RunDeserializationPostprocessing(ISet<DeserializationPostprocessor> alreadyHandled)
		{
			if (!alreadyHandled.Add(this)) return;
			(Content as DeserializationPostprocessor)?.RunDeserializationPostprocessing(alreadyHandled);
		}
	}
}
