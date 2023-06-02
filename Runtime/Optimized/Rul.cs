using JetBrains.Annotations;
using Exam.Data.Static;
using Exam.Data.Abstraction;
using System;

namespace Edo
{
	[Serializable]
	public sealed class Rul : DefaultRuleNodeData
	{
		public Rul(ContentPieceData content,
				   ContentPieceData preview,
				   ContentPieceData marker,
				   RuleNodeData parent,
				   RuleNodeInfo ruleNode) : base(content, preview, marker, parent, ruleNode) { }

		[UsedImplicitly]
		public Rul() { }
	}
}
