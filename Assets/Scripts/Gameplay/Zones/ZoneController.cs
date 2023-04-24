using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameJamEntry.Gameplay.Zones {
	public class ZoneController {
		Dictionary<string, ZoneState> _zones = new();

		public List<string> ZonesIds => _zones.Keys.ToList();
		
		public int RebelZonesCount => _zones.Count(z => z.Value.CurrentMana <= 0);
		public int TotalZonesCount => _zones.Count;

		public void AddZone(string id, ZoneParams zoneParams) {
			if ( _zones.ContainsKey(id) ) {
				Debug.LogWarning($"Zone {id} already exists");
				return;
			}
			_zones[id] = new ZoneState(id, zoneParams);
		}

		public void AddFight(string zoneId, int turnsAmount) {
			if ( string.IsNullOrEmpty(zoneId) || !_zones.ContainsKey(zoneId) ) {
				Debug.LogError($"Zone {zoneId} not found");
				return;
			}
			_zones[zoneId].LeftTurnsInFight += turnsAmount;
		}

		public void AddBlessing(string zoneId, int turnsAmount) {
			if ( string.IsNullOrEmpty(zoneId) || !_zones.ContainsKey(zoneId) ) {
				Debug.LogError($"Zone {zoneId} not found");
				return;
			}
			_zones[zoneId].LeftTurnsWithBlessing += turnsAmount;
		}

		public ZoneState GetZoneState(string zoneId) => _zones.GetValueOrDefault(zoneId);

		public void OnTurnEnded() {
			foreach ( var zone in _zones ) {
				zone.Value.CurrentMana           = Mathf.Max(zone.Value.CurrentMana - CalcZoneConsumption(zone.Key), 0);
				zone.Value.LeftTurnsInFight      = Mathf.Max(zone.Value.LeftTurnsInFight-1, 0);
				zone.Value.LeftTurnsWithBlessing = Mathf.Max(zone.Value.LeftTurnsWithBlessing-1, 0);
			}
		}

		int CalcZoneConsumption(string zoneId) {
			if ( !_zones.ContainsKey(zoneId) ) {
				Debug.LogError($"Zone {zoneId} not found");
				return 0;
			}
			var zone              = _zones[zoneId];
			var zoneParams        = zone.ZoneParams;
			var needToConsumeMana = zoneParams.ZoneDefaultManaConsumption;
			needToConsumeMana += zone.LeftTurnsInFight > 0 ? zoneParams.FightManaConsumption : 0;
			needToConsumeMana -= zone.LeftTurnsWithBlessing > 0 ? zoneParams.BlessingManaConsumption : 0;
			return needToConsumeMana;
		}

		public List<string> GetZonesWithoutFight() {
			return _zones.Where(x => x.Value.LeftTurnsInFight <= 0).Select(x => x.Key).ToList();
		}

		public List<string> GetZoneWithoutBlessing() {
			return _zones.Where(x => x.Value.LeftTurnsWithBlessing <= 0).Select(x => x.Key).ToList();
		}

		public void AddManaToZone(string zoneId, int manaAmount) {
			if ( !_zones.ContainsKey(zoneId) ) {
				Debug.LogError($"Zone {zoneId} not found");
				return;
			}
			_zones[zoneId].CurrentMana += manaAmount;
		}
	}
}