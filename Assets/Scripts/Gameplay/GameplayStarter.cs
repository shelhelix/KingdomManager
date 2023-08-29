using System.Collections.Generic;
using Com.Shelinc.FullscreenCanvasController;
using GameJamEntry.Gameplay.UI;
using GameJamEntry.Gameplay.Zones;
using UnityEngine;
using VContainer;

namespace GameJamEntry.Gameplay {
	public class GameplayStarter : MonoBehaviour {
		[Inject]
		void Init(List<ZoneView> zoneViews, ZoneController zoneController, ScreenManager screenManager, ManaTransferWindow manaTransferWindow, ManaManager manaManager) {
			screenManager.Init();
			foreach ( var zoneView in zoneViews ) {
				zoneController.AddZone(zoneView.Id, zoneView.Params);
			}
			screenManager.ShowScreen<GameplayScreen>().Forget();
			manaTransferWindow.Init(zoneController, manaManager);
		}
	}
}