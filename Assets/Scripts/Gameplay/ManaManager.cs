using GameJamEntry.Utils;

namespace GameJamEntry.Gameplay {
	public class ManaManager {
		public ReactiveValue<int> CurrentMana = new();

		public ManaManager() => CurrentMana.Value = 100;

		public void AddMana(int amount) {
			CurrentMana.Value += amount;
		}

		public bool TrySpendMana(int amount) {
			if ( !IsEnoughMana(amount) ) {
				return false;
			}
			CurrentMana.Value -= amount;
			return true;
		}

		public bool IsEnoughMana(int amount) => CurrentMana.Value >= amount;
	}
}