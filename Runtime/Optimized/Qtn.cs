using JetBrains.Annotations;
using Exam.Data.Static;
using Exam.Data.Abstraction;
using System;
using System.Collections.Generic;

namespace Edo
{
	[Serializable]
	public sealed class Qtn : DefaultQuestionData
	{
		public Qtn(IEnumerable<AnswerData> answers,
				   QuestionInfo question,
				   ContentPieceData content,
				   IEnumerable<ExplanationPieceData> explanation,
				   IEnumerable<RuleNodeData> rules) : base(answers, question, content, explanation, rules) { }

		[UsedImplicitly]
		public Qtn() { }
	}
}
