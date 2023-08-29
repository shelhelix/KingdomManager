using Com.Shelinc.SceneTransitionEffects;
using Cysharp.Threading.Tasks;
using GameComponentAttributes.Attributes;
using GameJamEntry.Utils.UI;
using UnityEngine;
using VContainer;

namespace GameJamEntry.Gameplay.UI {
	public class ReturnToMenuButton : MonoBehaviour {
		[NotNullReference] [SerializeField] ButtonWrapper Button;

		[Inject]
		public void Init(SceneLoader sceneLoader) {
			Button.RemoveAllAndAddListener(() => sceneLoader.LoadScene("MainMenu").Forget());
		}
	}
}