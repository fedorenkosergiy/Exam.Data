using System;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultSubsetData : SubsetData
	{
		public SetData Set { get; private set; }

		public ContentPieceData Content { get; private set; }

		public ContentPieceData Preview { get; private set; }

		public DefaultSubsetData(SetData set, ContentPieceData content)
		{
			Set = set;
			Content = content;
		}

		public DefaultSubsetData()
		{
		}
	}
}
