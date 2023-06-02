using Grabli.Abstraction;
using System;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultHintData : HintData
	{
		public int Id { get; private set; }
		public ContentPieceData Content { get; private set; }
		public ContentPieceData Preview { get; private set; }

		public DefaultHintData(IdentifiableReadonly<int> hint, ContentPieceData content)
		{
			Id = hint.GetId();
			Content = content;
		}

		public DefaultHintData() { }
	}
}
