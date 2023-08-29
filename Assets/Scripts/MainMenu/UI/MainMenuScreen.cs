using Com.Shelinc.FullscreenCanvasController;
using Com.Shelinc.SceneTransitionEffects;
using Cysharp.Threading.Tasks;
using GameComponentAttributes.Attributes;
using GameJamEntry.Utils.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace  GameJamEntry.MainMenu.UI {
	public class MainMenuScreen : BaseScreen {
		const string JamLink = "add link to jam here";
		
		[NotNullReference] [SerializeField] ButtonWrapper PlayButton;
		[NotNullReference] [SerializeField] ButtonWrapper SettingsButton;
		[NotNullReference] [SerializeField] ButtonWrapper JamLinkButton;
		[NotNullReference] [SerializeField] ButtonWrapper ExitButton;

		public void Init(MainMenuScreenHelper mainMenuScreenHelper, SceneLoader sceneLoader) {
			PlayButton.RemoveAllAndAddListener(() => sceneLoader.LoadScene(SceneLoader.GameplaySceneName).Forget());
			SettingsButton.RemoveAllAndAddListener(mainMenuScreenHelper.ShowSettingsScreen);
			JamLinkButton.RemoveAllAndAddListener(() => Application.OpenURL(JamLink));
			ExitButton.RemoveAllAndAddListener(Exit);
		}

		void Exit() {
			#if UNITY_EDITOR
				EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
		}
	}
}