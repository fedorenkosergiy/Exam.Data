using Exam.Data.Static;
using System.Collections.Generic;
using Exam.Config;

namespace Exam.Data.Dynamic
{
	public interface DatabaseContext
	{
		bool IsTestValid(TestData test);

		bool TryGenerateTests(out IEnumerable<TestData> tests);

		void Init(IEnumerable<QuestionData> questions, GlobalRuntimeConfig config);
	}
}
