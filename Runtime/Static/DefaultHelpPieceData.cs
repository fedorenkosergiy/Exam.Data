using System;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultHelpPieceData : HelpPieceData
	{
		public HintData Hint { get; private set; }
		public int Order { get; private set; }

		public DefaultHelpPieceData(HintData hint, int order)
		{
			Hint = hint;
			Order = order;
		}

		public DefaultHelpPieceData() { }

		public int CompareTo(object obj)
		{
			if (obj is HelpPieceData casted)
			{
				return Order.CompareTo(casted.Order);
			}
			throw new Exception();
		}
	}
}
