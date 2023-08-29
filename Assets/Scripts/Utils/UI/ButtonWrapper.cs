using GameComponentAttributes.Attributes;
using GameJamEntry.Global;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VContainer;

namespace GameJamEntry.Utils.UI {
	[RequireComponent(typeof(Button))]
	public sealed class ButtonWrapper : MonoBehaviour {
		[NotNullReference] public Button    Button;
		
		[NotNullReference] public AudioClip ClickSound;

		AudioPlayer _player;

		public bool Interactable {
			get => Button.interactable;
			set => Button.interactable = value;
		}

		void OnValidate() {
			if ( !Button ) {
				Button = GetComponent<Button>();
			}
		}

		[Inject]
		public void Init(AudioPlayer player) {
			_player = player;
		}
		
		public void RemoveAllListeners() {
			Button.onClick.RemoveAllListeners();
			Button.onClick.AddListener(PlaySound);
		}

		public void RemoveAllAndAddListener(UnityAction action) {
			RemoveAllListeners();
			Button.onClick.AddListener(action);
		}

		void PlaySound() {
			if ( !ClickSound ) {
				Debug.LogWarning("ButtonWithSfx: Click sound is not set");
				return;
			}
			_player.PlaySfx(ClickSound);
		}
	}
}