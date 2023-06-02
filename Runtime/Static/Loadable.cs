using Cysharp.Threading.Tasks;

namespace Exam.Data.Static
{
	public interface Loadable
	{
		bool IsLoaded { get; }
		UniTask LoadAsync();
		void Load();
		void Unload();
	}
}
