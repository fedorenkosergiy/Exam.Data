using Exam.Data.Abstraction;
using System;
using UnityEngine;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultAnswerData : AnswerData
	{
		[SerializeField] private int id;
		[SerializeField] private int o;
		[SerializeField] private bool ct;
		[SerializeReference] private ContentPieceData c;
		[SerializeReference] private ContentPieceData p;
		[SerializeReference] private HintData h;

		public int Id => id;

		public int Order => o;

		public bool IsCorrect => ct;

		public ContentPieceData Content => c;

		public ContentPieceData Preview => p;

		public HintData Hint => h;

		public DefaultAnswerData(AnswerInfo answer, ContentPieceData content, HintData hint)
		{
			id = answer.GetId();
			o = answer.GetOrder();
			ct = answer.IsCorrect.ToBool();
			c = content;
			h = hint;
		}

		public DefaultAnswerData() { }

		public int CompareTo(object obj)
		{
			if (obj is DefaultAnswerData casted) { return Order.CompareTo(casted.Order); }

			return 0;
		}
	}
}
