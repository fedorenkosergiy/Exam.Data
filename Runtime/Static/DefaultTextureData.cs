using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Exam.Data.Static
{
	[Serializable]
	public class DefaultTextureData : SimpleUsable, TextureData
	{
		[SerializeField] private string k;
		private AsyncOperationHandle<Sprite> loadingHandle;
		private volatile bool isLoading = false;

		public bool IsLoaded => loadingHandle.IsValid() && loadingHandle.IsDone;

		public Sprite Sprite => loadingHandle.IsValid() ? loadingHandle.Result : null;

		public DefaultTextureData(AssetReference reference)
		{
			k = reference.RuntimeKey.ToString();
		}

		public DefaultTextureData() { }

		public async UniTask LoadAsync()
		{
			while (isLoading)
			{
				await UniTask.Yield();
			}

			isLoading = true;
			await PrepareSprite();
			isLoading = false;
		}

		public void Load()
		{
			throw new NotImplementedException();
		}

		private async UniTask PrepareSprite()
		{
			if (Sprite)
			{
				return;
			}

			loadingHandle = Addressables.LoadAssetAsync<Sprite>(k);
			await loadingHandle;
		}

		public void Unload()
		{
			if (loadingHandle.IsValid())
			{
				Addressables.Release(loadingHandle);
			}
		}
	}
}
