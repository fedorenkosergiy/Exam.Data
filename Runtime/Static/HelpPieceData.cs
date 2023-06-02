using System;

namespace Exam.Data.Static
{
	public interface HelpPieceData : IComparable
	{
		HintData Hint { get; }
		int Order { get; }
	}
}
