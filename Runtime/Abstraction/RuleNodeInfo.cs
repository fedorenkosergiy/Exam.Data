using Grabli.Abstraction;

namespace Exam.Data.Abstraction
{
	public interface RuleNodeInfo : ContentPiece
	{
		public int Id { get; }

		public int Order { get; }

		public int ShortTextId { get; }

		public int MarkerTextId { get; }

		public int MarkerStyleId { get; }
	}
}
