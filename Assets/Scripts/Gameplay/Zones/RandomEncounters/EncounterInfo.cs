using System;

namespace GameJamEntry.Gameplay.Zones.RandomEncounters {
	[Serializable]
	public class EncounterInfo {
		public int EncounterPeriod;
		public int MinEncounterDuration;
		public int MaxEncounterDuration;
	}
}