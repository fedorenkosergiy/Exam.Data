using System;

namespace Exam.Data.Static
{
	public interface ExplanationPieceData : IComparable
	{
		RuleNodeData Rule { get; }
		int Order { get; }
	}
}
