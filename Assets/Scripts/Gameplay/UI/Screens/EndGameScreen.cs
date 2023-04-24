using GameComponentAttributes.Attributes;
using GameJamEntry.MainMenu.ScreenControl;
using UnityEngine;

namespace GameJamEntry.Gameplay.UI {
	public class EndGameScreen : BaseScreen {
		[NotNullReference] [SerializeField] GameObject WinRoot;
		[NotNullReference] [SerializeField] GameObject LoseRoot;
		
		public void Init(bool isWin) {
			WinRoot.gameObject.SetActive(isWin);
			LoseRoot.gameObject.SetActive(!isWin);
		}
	}
}