using Cysharp.Threading.Tasks;
using GameJamEntry.MainMenu.SceneLoading.Transitions;
using UnityEngine.SceneManagement;

namespace GameJamEntry.MainMenu.SceneLoading {
	public class SceneLoader {
		readonly ISceneTransition _transition;

		public SceneLoader(ISceneTransition transition) => _transition = transition;

		public async UniTask LoadScene(string sceneName) {
			await _transition.HideScenes();
			await SceneManager.LoadSceneAsync(sceneName);
			await _transition.ShowScenes();
		}
	}
}