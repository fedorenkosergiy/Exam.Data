using JetBrains.Annotations;
using Exam.Data.Static;
using Exam.Data.Abstraction;
using System;

namespace Edo
{
	[Serializable]
	public sealed class Ans : DefaultAnswerData
	{
		public Ans(AnswerInfo answer, ContentPieceData content, HintData hint) : base(answer, content, hint) { }

		[UsedImplicitly]
		public Ans() { }
	}
}
