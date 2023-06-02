using Exam.Data.Dynamic;
using Exam.Data.Static;
using Cysharp.Threading.Tasks;

namespace Exam.Data
{
	public interface ComplexDatabase
	{
		StaticDatabase StaticData { get; }

		ContextualDatabase WorkByTopics { get; }

		ContextualDatabase WorkOnMistakes { get; }

		ContextualDatabase RandomTest { get; }

		ContextualDatabase MostDifficultTests { get; }

		UniTask UnloadUnusedAssets();
	}
}
