using Exam.Data.Dynamic;
using Exam.Data.Static;
using Exam.Data.Static;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UniTask = Cysharp.Threading.Tasks.UniTask;

namespace Exam.Data
{
	[Serializable]
	public class DefaultComplexDatabase : ScriptableObject, ComplexDatabase, DeserializationPostprocessor
	{
		[SerializeReference] private StaticDatabase staticData;
		[SerializeReference] private ContextualDatabase workByTopics;
		[SerializeReference] private ContextualDatabase workOnMistakes;
		[SerializeReference] private ContextualDatabase randomTest;

		public StaticDatabase StaticData => staticData;

		public ContextualDatabase WorkByTopics => workByTopics;

		public ContextualDatabase WorkOnMistakes => workOnMistakes;

		public ContextualDatabase RandomTest => randomTest;

		public ContextualDatabase MostDifficultTests { get; private set; }

		[NonSerialized] private IList<Usable> usableAndLoadable;

		public void Init(StaticDatabase staticData,
						 ContextualDatabase workByTopics,
						 ContextualDatabase workOnMistakes,
						 ContextualDatabase randomTest,
						 ContextualDatabase mostDifficultTests)
		{
			this.staticData = staticData;
			this.workByTopics = workByTopics;
			this.workOnMistakes = workOnMistakes;
			this.randomTest = randomTest;
			MostDifficultTests = mostDifficultTests;
		}

		public async UniTask UnloadUnusedAssets()
		{
			int used = 0;

			for (int i = 0; i < usableAndLoadable.Count; ++i)
			{
				Usable item = usableAndLoadable[i];

				if (item.IsUsed) { used++; }

				if (item is Loadable loadable && loadable.IsLoaded && !item.IsUsed) { loadable.Unload(); }
			}

			await Resources.UnloadUnusedAssets();
		}

		public void CalculateUsedItems()
		{
			int used = 0;

			for (int i = 0; i < usableAndLoadable.Count; ++i)
			{
				if (usableAndLoadable[i].IsUsed) { used++; }
			}
		}

		public void RunDeserializationPostprocessing(ISet<DeserializationPostprocessor> alreadyHandled)
		{
			if (!alreadyHandled.Add(this)) return;

			usableAndLoadable = new List<Usable>();
			RegisterQuestionsAsUsableAndLoadable();
			RegisterRulesAsUsableAndLoadable(StaticData.Rules.Rule.Children);
			_ = StaticData.Tests;

			(StaticData as DeserializationPostprocessor)?.RunDeserializationPostprocessing(alreadyHandled);
		}

		private void RegisterQuestionsAsUsableAndLoadable()
		{
			IReadOnlyList<QuestionData> questions = StaticData.Questions;

			for (int i = 0; i < questions.Count; ++i)
			{
				TextureData textureData = questions[i].Content.Image;

				if (textureData.Is() && textureData is Usable usable) { usableAndLoadable.Add(usable); }
			}
		}

		private void RegisterRulesAsUsableAndLoadable(RuleNodeData[] rules)
		{
			for (int i = 0; i < rules.Length; ++i)
			{
				if (rules[i].IsLeaf)
				{
					if (rules[i].Content.Image is Usable usable) { usableAndLoadable.Add(usable); }
				}
				else { RegisterRulesAsUsableAndLoadable(rules[i].Children); }
			}
		}

		public Task Load() { throw new NotImplementedException(); }
	}
}
