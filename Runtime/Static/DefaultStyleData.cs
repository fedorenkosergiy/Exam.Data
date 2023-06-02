using Exam.Data.Abstraction;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using UiText = UnityEngine.UI.Text;
using UnityEngine;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultStyleData : StyleData
	{
		[SerializeField] private int anchor;
		[SerializeField] private float fontSize;
		[SerializeField] private string name;
		[SerializeField] private string fontFileName;

		public FontData Data { get; private set; }

		public bool IsLoaded { get; private set; }

		public string Name => name;

		public DefaultStyleData(StyleInfo rawStyle, FontInfo rawFont)
		{
			anchor = rawStyle.Anchor;
			fontSize = rawStyle.FontSize;
			fontFileName = rawFont.FileName;
			IsLoaded = false;
			name = rawStyle.Name;
		}

		public DefaultStyleData() { }

		public void Apply(UiText field)
		{
			if (Data.font.Is()) { field.font = Data.font; }

			field.alignment = Data.alignment;
			field.fontSize = Data.fontSize;
		}

		public async UniTask LoadAsync() { throw new NotImplementedException(); }

		public void Load()
		{
			if (IsLoaded) { return; }

			Data = new FontData
			{
			alignment = anchor.ToUnityTextAnchor(),
			fontSize = (int)fontSize,
			};

			IsLoaded = true;
		}

		public void Unload()
		{
			IsLoaded = false;

			if (Data.Is()) { Data.font = null; }
		}
	}
}
