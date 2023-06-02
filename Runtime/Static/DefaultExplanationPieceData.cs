using Grabli.Abstraction;
using System;
using UnityEngine;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultExplanationPieceData : ExplanationPieceData
	{
		[SerializeField] private int o;
		[SerializeReference] private RuleNodeData r;
		public RuleNodeData Rule => r;
		public int Order => o;

		public DefaultExplanationPieceData(OrderableReadonly<int> explanation, RuleNodeData rule)
		{
			r = rule;
			o = explanation.GetOrder();
		}

		public DefaultExplanationPieceData()
		{
		}

		public int CompareTo(object obj)
		{
			if (obj is ExplanationPieceData casted)
			{
				return Order.CompareTo(casted.Order);
			}

			throw new Exception();
		}
	}
}
