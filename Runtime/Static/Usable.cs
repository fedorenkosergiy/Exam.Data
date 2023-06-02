namespace Exam.Data.Static
{
	public interface Usable
	{
		bool IsUsed { get; }
		bool StartUsing(object user);
		bool StopUsing(object user);
	}
}
