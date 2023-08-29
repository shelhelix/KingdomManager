namespace GameJamEntry.General {
	public class GameState {
		static GameState                _instance;
		public SystemSettingsController SystemSettingsController = new();

		public static GameState Instance => _instance ?? (_instance = new GameState());
	}
}