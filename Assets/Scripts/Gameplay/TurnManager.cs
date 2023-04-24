﻿using System;
using GameJamEntry.Gameplay.Zones;
using GameJamEntry.Gameplay.Zones.RandomEncounters;
using VContainer;

namespace GameJamEntry.Gameplay {
	public class TurnManager {
		
		public int CurrentTurnIndex { get; private set; }

		readonly ManaIncomer         _manaIncomer;
		readonly RandomZoneEncounter _randomZoneEncounter;
		readonly ZoneController      _zoneController;

		public event Action<int> OnTurnEnded;
		
		[Inject]
		public TurnManager(ManaIncomer manaIncomer, RandomZoneEncounter randomZoneEncounter, ZoneController zoneController) {
			_manaIncomer         = manaIncomer;
			_randomZoneEncounter = randomZoneEncounter;
			_zoneController      = zoneController;
			CurrentTurnIndex     = 1;
		}
		
		public void EndTurn() {
			_manaIncomer.AddManaOnTurnEnded();
			_randomZoneEncounter.OnTurnEnded(CurrentTurnIndex);
			_zoneController.OnTurnEnded();
			CurrentTurnIndex++;
			OnTurnEnded?.Invoke(CurrentTurnIndex);
		}
	}
}