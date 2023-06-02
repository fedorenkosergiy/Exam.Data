using JetBrains.Annotations;
using Exam.Data.Static;
using System;
using System.Collections.Generic;

namespace Edo
{
	[Serializable]
	public sealed class Tst : DefaultTestData
	{
		public Tst(ContentPieceData content, ContentPieceData preview, IEnumerable<QuestionData> questions) :
		base(content, preview, questions) { }

		[UsedImplicitly]
		public Tst() { }
	}
}
