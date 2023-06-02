using JetBrains.Annotations;
using Exam.Data.Static;
using Exam.Data.Abstraction;
using System;

namespace Edo
{
	[Serializable]
	public sealed class Tsl : DefaultTranslationData
	{
		public Tsl(TranslationInfo[] translations) : base(translations) { }

		[UsedImplicitly]
		public Tsl() { }
	}
}
