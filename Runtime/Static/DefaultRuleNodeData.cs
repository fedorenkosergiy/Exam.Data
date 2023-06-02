using Exam.Data.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultRuleNodeData : RuleNodeData, DeserializationPostprocessor
	{
		[SerializeField] private int id;
		[SerializeField] private int o;
		[SerializeReference] private ContentPieceData c;
		[SerializeReference] private ContentPieceData p;
		[SerializeReference] private ContentPieceData m;
		[SerializeReference] private RuleNodeData pt;
		[SerializeReference] private RuleNodeData[] ch;

		public bool IsRoot => Parent == null;

		public bool IsLeaf => Children == null || Children.Length == 0;

		public ContentPieceData Content => c;

		public ContentPieceData Preview => p;

		public RuleNodeData Parent => pt;

		public RuleNodeData[] Children => ch;

		public ContentPieceData Marker => m;

		public int Id => id;

		public int Order => o;

		public int CompareTo(object obj)
		{
			if (obj is DefaultRuleNodeData casted) { return o.CompareTo(casted.o); }

			return 0;
		}

		public DefaultRuleNodeData(ContentPieceData content,
								   ContentPieceData preview,
								   ContentPieceData marker,
								   RuleNodeData parent,
								   RuleNodeInfo ruleNode)
		{
			c = content;
			p = preview;
			m = marker;
			pt = parent;
			id = ruleNode.Id;
			o = ruleNode.Order;
		}

		public DefaultRuleNodeData() { }

		public void SetChildren(ICollection<RuleNodeData> children) { ch = children.ToArray(); }

		public void RunDeserializationPostprocessing(ISet<DeserializationPostprocessor> alreadyHandled)
		{
			if (!alreadyHandled.Add(this)) return;

			(Content as DeserializationPostprocessor)?.RunDeserializationPostprocessing(alreadyHandled);

			for (int i = 0; i < Children.Length; ++i)
			{
				(Children[i] as DeserializationPostprocessor)?.RunDeserializationPostprocessing(alreadyHandled);
			}
		}
	}
}
