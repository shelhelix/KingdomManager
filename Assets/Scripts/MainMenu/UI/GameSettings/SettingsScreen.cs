using Com.Shelinc.FullscreenCanvasController;
using GameComponentAttributes.Attributes;
using GameJamEntry.General;
using GameJamEntry.Utils.UI;
using UnityEngine;

namespace GameJamEntry.MainMenu.UI.Settings {
	public class SettingsScreen : BaseScreen {
		[NotNullReference] [SerializeField] ButtonWrapper      ReturnButton;
		[NotNullReference] [SerializeField] SoundSettingsBlock MasterSettingsBlocks;
		[NotNullReference] [SerializeField] SoundSettingsBlock MusicSettingsBlocks;
		[NotNullReference] [SerializeField] SoundSettingsBlock SfxSettingsBlocks;
		
		public void Init(MainMenuScreenHelper helper, SoundSettingsController settingsController) {
			ReturnButton.RemoveAllAndAddListener(helper.ShowMainMenuScreen);
			MasterSettingsBlocks.Init(settingsController, MixerParamName.MasterVolume);
			MusicSettingsBlocks.Init(settingsController, MixerParamName.MusicVolume);
			SfxSettingsBlocks.Init(settingsController, MixerParamName.SfxVolume);
		}
	}
}
