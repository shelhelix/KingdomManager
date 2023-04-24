using System;
using GameJamEntry.Gameplay.Zones;
using VContainer;

namespace GameJamEntry.Gameplay {
	public class GameplayGoalWatcher {
		public const int MaxTurnsCount = 30;

		public event Action<bool> OnGameEnded;

		ZoneController _zoneController;
		
		[Inject]
		public GameplayGoalWatcher(TurnManager turnManager, ZoneController zoneController) {
			_zoneController    =  zoneController;
			turnManager.OnTurnEnded += OnTurnEnded;
		}

		void OnTurnEnded(int newTurnIndex) {
			if ( newTurnIndex >= MaxTurnsCount ) {
				OnGameEnded?.Invoke(true);
				return;
			}
			if ( _zoneController.RebelZonesCount > _zoneController.TotalZonesCount / 2) {
				OnGameEnded?.Invoke(false);
			}
		}
	}
}