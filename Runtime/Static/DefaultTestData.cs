using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultTestData : TestData
	{
		[SerializeReference] private ContentPieceData c;
		[SerializeReference] private ContentPieceData p;
		[SerializeReference] private QuestionData[] q;

		public ContentPieceData Content => c;

		public ContentPieceData Preview => p;

		public QuestionData[] Questions => q;

		public int Count => Questions.Is() ? Questions.Length : 0;

		public DefaultTestData(ContentPieceData content, ContentPieceData preview, IEnumerable<QuestionData> questions)
		{
			c = content;
			p = preview;
			q = questions.ToArray();
		}

		public DefaultTestData() { }
	}
}
