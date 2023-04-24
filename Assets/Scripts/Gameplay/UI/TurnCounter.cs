using GameComponentAttributes.Attributes;
using TMPro;
using UnityEngine;
using VContainer;

namespace GameJamEntry.Gameplay.UI {
	public class TurnCounter : MonoBehaviour {
		[NotNullReference] [SerializeField] TMP_Text CounterText;

		[Inject]
		public void Init(TurnManager turnManager) {
			turnManager.OnTurnEnded += OnManaChanged;
			OnManaChanged(turnManager.CurrentTurnIndex);
		}

		void OnManaChanged(int newTurn) {
			CounterText.text = $"Turn: {newTurn}/{GameplayGoalWatcher.MaxTurnsCount}";
		}
	}
}