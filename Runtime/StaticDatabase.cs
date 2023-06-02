using Exam.Data.Static;
using System.Collections.Generic;

namespace Exam.Data.Static
{
	public interface StaticDatabase
	{
		IReadOnlyList<string> Languages { get; }
		IReadOnlyList<TestData> Tests { get; }
		IReadOnlyList<QuestionData> Questions { get; }
		IReadOnlyDictionary<int, QuestionData> QuestionById { get; }
		IReadOnlyList<SetData> Sets { get; }
		IReadOnlyList<SubsetData> Subsets { get; }
		IReadOnlyList<StyleData> Styles { get; }
		IReadOnlyList<QuestionKeywordData> Keywords { get; }
		RulesRootData Rules { get; }

		int GetId(string guid);
	}
}
