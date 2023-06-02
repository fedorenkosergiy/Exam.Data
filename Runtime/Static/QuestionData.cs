namespace Exam.Data.Static
{
	public interface QuestionData : ContentProvider
	{
		int Id { get; }
		string Code { get; }
		AnswerData[] Answers { get; }
		int Revision { get; }
		bool IsExplanationEnabled { get; }
		bool IsEnabled { get; }
		SetData [] Sets { get; }
		ExplanationPieceData [] Explanation { get; }
		HelpPieceData [] Help { get; }
		RuleNodeData[] Rules { get; }
		string [] Labels { get; }
	}
}
