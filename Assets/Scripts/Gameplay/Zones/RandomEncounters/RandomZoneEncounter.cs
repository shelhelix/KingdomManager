using GameJamEntry.Utils;
using UnityEngine;
using VContainer;

namespace GameJamEntry.Gameplay.Zones.RandomEncounters {
	public class RandomZoneEncounter {
		readonly ZoneController  _zoneController;
		readonly EncounterConfig _config;

		[Inject]
		public RandomZoneEncounter(ZoneController zoneController, EncounterConfig config) {
			_zoneController = zoneController;
			_config         = config;
		}

		public void OnTurnEnded(int currentTurnIndex) {
			TryCreateFight(currentTurnIndex);
			TryBlessArea(currentTurnIndex);
		}

		// Blessing
		void TryBlessArea(int currentTurnIndex) {
			if ( !IsNeedToStartEncounter(currentTurnIndex, _config.Blessing) ) {
				return;
			}
			var fightZone     = SelectNextFightZone();
			var fightDuration = GetEncounterPeriod(_config.Blessing);
			_zoneController.AddBlessing(fightZone, fightDuration);
		}

		string SelectNextBlessingZone() {
			var zonesWithoutBlessing = _zoneController.GetZoneWithoutBlessing();
			return zonesWithoutBlessing.Count == 0 ? RandomUtils.GetRandomElementInList(_zoneController.ZonesIds) : RandomUtils.GetRandomElementInList(zonesWithoutBlessing);
		}

		// Fights
		void TryCreateFight(int currentTurnIndex) {
			if ( !IsNeedToStartEncounter(currentTurnIndex, _config.Fight) ) {
				return;
			}
			var fightZone     = SelectNextFightZone();
			var fightDuration = GetEncounterPeriod(_config.Fight);
			_zoneController.AddFight(fightZone, fightDuration);
		}

		string SelectNextFightZone() {
			var zonesWithoutFight = _zoneController.GetZonesWithoutFight();
			return zonesWithoutFight.Count == 0 ? RandomUtils.GetRandomElementInList(_zoneController.ZonesIds) : RandomUtils.GetRandomElementInList(zonesWithoutFight);
		}

		bool IsNeedToStartEncounter(int turnIndex, EncounterInfo encounterInfo) => (turnIndex % encounterInfo.EncounterPeriod) == 0;

		int GetEncounterPeriod(EncounterInfo encounterInfo) => Random.Range(encounterInfo.MinEncounterDuration, encounterInfo.MaxEncounterDuration);
	}
}