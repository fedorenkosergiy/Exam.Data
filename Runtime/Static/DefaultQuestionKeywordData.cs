using Exam.Data.Abstraction;
using System;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultQuestionKeywordData : QuestionKeywordData
	{
		public QuestionData Question { get; private set; }

		public string Word { get; private set; }

		public string Language { get; private set; }

		public DefaultQuestionKeywordData() { }

		public DefaultQuestionKeywordData(QuestionKeywordInfo keyword, QuestionData question)
		{
			Question = question;
			Word = keyword.Word;
			Language = keyword.Language;
		}
	}
}
