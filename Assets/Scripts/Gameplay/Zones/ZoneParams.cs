using UnityEngine;

namespace GameJamEntry.Gameplay.Zones {
	[CreateAssetMenu(fileName = "ZoneConfig", menuName = "GameJamEntry/ZoneConfig")]
	public class ZoneParams : ScriptableObject {
		public int ZoneDefaultManaConsumption;
		public int FightManaConsumption;
		public int BlessingManaConsumption;
		public int StartManaAmount;
	}
}