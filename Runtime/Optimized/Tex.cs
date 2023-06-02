using JetBrains.Annotations;
using Exam.Data.Static;
using System;
using UnityEngine.AddressableAssets;

namespace Edo
{
	[Serializable]
	public sealed class Tex : DefaultTextureData
	{
		public Tex(AssetReference reference) : base(reference) { }

		[UsedImplicitly]
		public Tex() { }
	}
}
