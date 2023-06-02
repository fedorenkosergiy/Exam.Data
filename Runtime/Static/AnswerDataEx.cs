namespace Exam.Data.Static
{
	public static class AnswerDataEx
	{
		public static bool IsWrong(this AnswerData answerData)
		{
			return !answerData.IsCorrect;
		}
	}
}
