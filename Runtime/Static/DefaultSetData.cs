using Grabli.Abstraction;
using System;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultSetData : SetData
	{
		public int Id { get; private set; }
		public ContentPieceData Content { get; private set; }
		public ContentPieceData Preview { get; private set; }

		public DefaultSetData(IdentifiableReadonly<int> set, ContentPieceData content)
		{
			Id = set.GetId();
			Content = content;
		}

		public DefaultSetData() { }
	}
}
