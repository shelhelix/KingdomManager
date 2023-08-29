using Com.Shelinc.FullscreenCanvasController;
using Com.Shelinc.SceneTransitionEffects;
using GameJamEntry.General;
using GameJamEntry.MainMenu.UI.Settings;

namespace GameJamEntry.MainMenu.UI {
	public class MainMenuScreenHelper {
		readonly ScreenManager            _screenManager;
		readonly SoundSettingsController _soundSettingsController;
		readonly SceneLoader              _sceneLoader;

		public MainMenuScreenHelper(ScreenManager screenManager, SoundSettingsController settingsController, SceneLoader sceneLoader) {
			_screenManager            = screenManager;
			_soundSettingsController = settingsController;
			_sceneLoader              = sceneLoader;
			screenManager.Init();
		}
		
		public void ShowMainMenuScreen() {
			_screenManager.ShowScreen<MainMenuScreen>(x => x.Init(this, _sceneLoader)).Forget();
		}

		public void ShowSettingsScreen() {
			_screenManager.ShowScreen<SettingsScreen>(x => x.Init(this, _soundSettingsController)).Forget();
		}
	}
}