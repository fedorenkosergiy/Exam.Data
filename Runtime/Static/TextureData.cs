using UnityEngine;

namespace Exam.Data.Static
{
	public interface TextureData : Loadable
	{
		Sprite Sprite { get; }
	}
}
