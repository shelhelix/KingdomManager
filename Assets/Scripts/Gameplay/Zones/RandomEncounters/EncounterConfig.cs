using UnityEngine;

namespace GameJamEntry.Gameplay.Zones.RandomEncounters {
	[CreateAssetMenu(fileName = "EncounterConfig", menuName = "GameJamEntry/EncounterConfig")]
	public class EncounterConfig : ScriptableObject {
		public EncounterInfo Fight;
		public EncounterInfo Blessing;
	}
}