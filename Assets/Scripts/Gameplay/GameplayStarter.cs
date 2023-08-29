using System.Collections.Generic;
using GameJamEntry.Gameplay.UI;
using GameJamEntry.Gameplay.Zones;
using GameJamEntry.MainMenu.ScreenControl;
using VContainer;
using VContainer.Unity;

namespace GameJamEntry.Gameplay {
	public class GameplayStarter : IStartable {
		List<ZoneView>     _zoneViews;
		ZoneController     _zoneController;
		ScreenManager      _screenManager;
		ManaTransferWindow _manaTransferWindow;
		ManaManager        _manaManager;

		[Inject]
		public GameplayStarter(List<ZoneView> zoneViews, ZoneController zoneController, ScreenManager screenManager, ManaTransferWindow manaTransferWindow, ManaManager manaManager) {
			_zoneViews          = zoneViews;
			_zoneController     = zoneController;
			_screenManager      = screenManager;
			_manaTransferWindow = manaTransferWindow;
			_manaManager        = manaManager;
		}

		public void Start() {
			_screenManager.Init();
			foreach ( var zoneView in _zoneViews ) {
				_zoneController.AddZone(zoneView.Id, zoneView.Params);
			}
			_screenManager.ShowScreen<GameplayScreen>().Forget();
			_manaTransferWindow.Init(_zoneController, _manaManager);
		}
	}
}