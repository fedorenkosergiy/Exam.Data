using Grabli.Abstraction;

namespace Exam.Data.Abstraction
{
	public interface AnswerInfo : ContentPiece, QuestionRelation, IdentifiableReadonly<int>, OrderableReadonly<int>
	{
		int IsCorrect { get; }
	}
}
