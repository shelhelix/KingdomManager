using System.Collections.Generic;
using GameComponentAttributes.Attributes;
using GameJamEntry.Global;
using GameJamEntry.MainMenu.UI;
using UnityEngine;
using VContainer;

namespace GameJamEntry.Gameplay {

	public class MainMenuStarter : MonoBehaviour {
		[NotNullReference] [SerializeField] List<AudioClip> Bgms;

		[Inject]
		public void Init(MainMenuScreenHelper mainMenuScreenManager, BgmManager bgmManager) {
			mainMenuScreenManager.ShowMainMenuScreen();
			bgmManager.PlayBgms(Bgms);
		}
	}
}