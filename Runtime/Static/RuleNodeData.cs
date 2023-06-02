using System;
using System.Collections.Generic;
using Grabli.Abstraction;

namespace Exam.Data.Static
{
	public interface RuleNodeData : ContentProvider, IComparable
	{
		int Id { get; }

		int Order { get; }

		RuleNodeData Parent { get; }

		RuleNodeData[] Children { get; }

		bool IsRoot { get; }

		bool IsLeaf { get; }

		ContentPieceData Marker { get; }

		void SetChildren(ICollection<RuleNodeData> children);
	}
}
