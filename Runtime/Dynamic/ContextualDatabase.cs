using Exam.Data.Static;
using System.Collections.Generic;

namespace Exam.Data.Dynamic
{
	public interface ContextualDatabase
	{
		IReadOnlyList<TestData> Tests { get; }

		void AdjustToContext(DatabaseContext context);
	}
}
