namespace Exam.Data.Static
{
	public interface TranslationData
	{
		string this[string language] { get; }

		string GetTranslation(string language, string fallbackLanguage);
	}
}
