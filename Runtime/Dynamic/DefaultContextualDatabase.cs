using Exam.Data.Static;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Exam.Data.Dynamic
{
	[Serializable]
	public class DefaultContextualDatabase : ContextualDatabase
	{
		[SerializeReference] private List<TestData> tests;

		public IReadOnlyList<TestData> Tests => tests;

		public void AdjustToContext(DatabaseContext context)
		{
			List<TestData> testsList = new List<TestData>();

			if (context.TryGenerateTests(out IEnumerable<TestData> tests)) { testsList.AddRange(tests); }

			this.tests = testsList;
		}
	}
}
