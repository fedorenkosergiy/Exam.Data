using Grabli.Abstraction;

namespace Exam.Data.Abstraction
{
	public interface QuestionInfo : ContentPiece, IdentifiableReadonly<int>
	{
		int Revision { get; }

		int IsExplanationEnabled { get; }

		string Labels { get; }
	}
}
