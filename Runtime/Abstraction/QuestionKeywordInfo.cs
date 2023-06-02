namespace Exam.Data.Abstraction
{
	public interface QuestionKeywordInfo : QuestionRelation
	{
		string Word { get; }

		string Language { get; }
	}
}
