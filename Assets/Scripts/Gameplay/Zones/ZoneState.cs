namespace GameJamEntry.Gameplay.Zones {
	public class ZoneState {
		public string Id;
		public int    LeftTurnsInFight;
		public int    LeftTurnsWithBlessing;

		public int CurrentMana;

		public ZoneParams ZoneParams;

		public ZoneState(string id, ZoneParams zoneParams) {
			Id          = id;
			ZoneParams  = zoneParams;
			CurrentMana = ZoneParams.StartManaAmount;
		}
	}
}