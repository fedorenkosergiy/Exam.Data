namespace Exam.Data.Static
{
	public static class QuestionDataEx
	{
		public static AnswerData GetAnswerById(this QuestionData question, int id)
		{
			for (int i = 0; i < question.Answers.Length; ++i)
			{
				if (question.Answers[i].Id == id)
				{
					return question.Answers[i];
				}
			}
			return default;
		}

		public static bool HasLabel(this QuestionData question, string label)
		{
			if (question.Labels.IsNull())
			{
				return false;
			}
			for(int i = 0; i < question.Labels.Length; ++i)
			{
				if (question.Labels[i] == label)
				{
					return true;
				}
			}
			return false;
		}

		public static bool HasLabels(this QuestionData question)
		{
			return question.Labels.Is() && question.Labels.Length > 0;
		}
	}
}
