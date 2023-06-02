using JetBrains.Annotations;
using Exam.Data.Static;
using System;

namespace Edo
{
	[Serializable]
	public sealed class Ctn : DefaultContentPieceData
	{
		public Ctn(StyleData style, TranslationData text, TextureData image) : base(style, text, image) { }

		[UsedImplicitly]
		public Ctn() { }
	}
}
