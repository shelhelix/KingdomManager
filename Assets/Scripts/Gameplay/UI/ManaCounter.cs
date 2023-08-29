using GameComponentAttributes.Attributes;
using TMPro;
using UnityEngine;
using VContainer;

namespace GameJamEntry.Gameplay.UI {
	public class ManaCounter : MonoBehaviour {
		[NotNullReference] [SerializeField] TMP_Text CounterText;

		[Inject]
		public void Init(ManaManager manaManager) {
			manaManager.CurrentMana.OnValueChanged += OnManaChanged;
			OnManaChanged(manaManager.CurrentMana.Value);
		}

		void OnManaChanged(int newAmount) {
			CounterText.text = $"Mana: {newAmount}";
		}
	}
}