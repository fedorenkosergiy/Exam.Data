using UnityEngine.UI;

namespace Exam.Data.Static
{
	public interface StyleData : Loadable
	{
		string Name { get; }
		FontData Data { get; }
		void Apply(Text field);
	}
}
