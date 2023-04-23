using Cysharp.Threading.Tasks;

namespace GameJamEntry.MainMenu.SceneLoading.Transitions {
	public interface ISceneTransition {
		public UniTask HideScenes();
		public UniTask ShowScenes();
	}
}