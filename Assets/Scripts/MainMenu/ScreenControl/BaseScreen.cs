using Cysharp.Threading.Tasks;
using DG.Tweening;
using GameComponentAttributes.Attributes;
using NaughtyAttributes;
using UnityEngine;

namespace GameJamEntry.MainMenu.ScreenControl {
	public class BaseScreen : MonoBehaviour {
		[BoxGroup("transition params")]
		[NotNullReference] public CanvasGroup CanvasGroup;

		public async UniTask Show() {
			CanvasGroup.blocksRaycasts = false;
			await CanvasGroup.DOFade(1, 0.3f);
			CanvasGroup.blocksRaycasts = true;
		}

		public async UniTask Hide() {
			CanvasGroup.blocksRaycasts = false;
			await CanvasGroup.DOFade(0, 0.3f);
		}

		public void InstantHide() {
			CanvasGroup.blocksRaycasts = false;
			CanvasGroup.alpha          = 0;
		}
	}
}