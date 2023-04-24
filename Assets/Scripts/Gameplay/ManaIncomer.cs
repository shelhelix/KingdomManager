using VContainer;

namespace GameJamEntry.Gameplay {
	public class ManaIncomer {
		const int ManaPerTurn = 15;
		
		ManaManager _manaManager;
		
		[Inject]
		public ManaIncomer(ManaManager manaManager) => _manaManager = manaManager;

		public void AddManaOnTurnEnded() {
			_manaManager.AddMana(ManaPerTurn);
		}
	}
}