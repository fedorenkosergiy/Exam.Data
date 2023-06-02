namespace Exam.Data.Static
{
	public interface ContentProvider
	{
		ContentPieceData Content { get; }
		ContentPieceData Preview { get; }
	}
}
