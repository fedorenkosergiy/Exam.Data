using System;

namespace Exam.Data.Static
{
	public interface AnswerData : IComparable, ContentProvider
	{
		int Id { get; }

		int Order { get; }

		bool IsCorrect { get; }

		HintData Hint { get; }
	}
}
