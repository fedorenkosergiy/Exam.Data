using System;
using System.Collections.Generic;
using UnityEngine;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultContentPieceData : ContentPieceData, DeserializationPostprocessor
	{
		[SerializeReference] private StyleData s;
		[SerializeReference] private TranslationData t;
		[SerializeReference] private TextureData i;

		public StyleData Style => s;
		public TranslationData Text => t;
		public TextureData Image => i;

		public DefaultContentPieceData(StyleData style, TranslationData text, TextureData image)
		{
			s = style;
			t = text;
			i = image;
		}

		public DefaultContentPieceData()
		{
		}

		public void RunDeserializationPostprocessing(ISet<DeserializationPostprocessor> alreadyHandled)
		{
			if (!alreadyHandled.Add(this)) return;
			(Image as DeserializationPostprocessor)?.RunDeserializationPostprocessing(alreadyHandled);
		}
	}
}
