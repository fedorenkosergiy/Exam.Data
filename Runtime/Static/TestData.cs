namespace Exam.Data.Static
{
	public interface TestData : PreviewProvider
	{
		QuestionData [] Questions { get; }
		int Count { get; }
	}
}
