using Grabli.Abstraction;

namespace Exam.Data.Abstraction
{
	public interface FontInfo : IdentifiableReadonly<int>
	{
		string FileName { get; }
	}
}
