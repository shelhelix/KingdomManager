using GameJamEntry.MainMenu.ScreenControl;
using UnityEngine;
using VContainer;

namespace GameJamEntry.Gameplay.UI {
	public class GameplayUIWatcher : MonoBehaviour {
		ScreenManager _screenManager;
		
		[Inject]
		public void Init(GameplayGoalWatcher watcher, ScreenManager screenManager) {
			watcher.OnGameEnded += OnGameEnded;
			_screenManager      =  screenManager;
		}

		void OnGameEnded(bool isWin) {
			_screenManager.ShowScreen<EndGameScreen>(x => x.Init(isWin)).Forget();
		}
	}
}