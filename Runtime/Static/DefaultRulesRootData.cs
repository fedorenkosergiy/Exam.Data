using System;
using UnityEngine;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultRulesRootData : RulesRootData
	{
		[SerializeReference] private RuleNodeData rule;

		public RuleNodeData Rule => rule;

		public DefaultRulesRootData(RuleNodeData rule)
		{
			this.rule = rule;
		}

		public DefaultRulesRootData()
		{
		}
	}
}
