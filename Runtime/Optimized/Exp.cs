using JetBrains.Annotations;
using Exam.Data.Static;
using Grabli.Abstraction;
using System;

namespace Edo
{
	[Serializable]
	public sealed class Exp : DefaultExplanationPieceData
	{
		public Exp(OrderableReadonly<int> explanation, RuleNodeData rule) : base(explanation, rule) { }

		[UsedImplicitly]
		public Exp() { }
	}
}
