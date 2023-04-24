using GameComponentAttributes.Attributes;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace GameJamEntry.Gameplay.UI {
	public class EndTurnButton : MonoBehaviour {
		[NotNullReference] [SerializeField] Button Button;

		[Inject]
		public void Init(TurnManager turnManager) {
			Button.onClick.AddListener(turnManager.EndTurn);
		}
	}
}