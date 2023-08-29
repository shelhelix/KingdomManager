using System;
using UnityEngine;

namespace GameJamEntry.General {
	public class SoundSettingsController {
		SoundSettingsControllerState _controllerState = new();

		public float GetNormalizedVolume(MixerParamName mixerParamName) => _controllerState.GetOrCreateEntry(mixerParamName).Volume;

		public void SetNormalizedVolume(MixerParamName mixerParamName, float volume) {
			var clampedVolume = Mathf.Clamp01(volume);
			_controllerState.GetOrCreateEntry(mixerParamName).Volume = clampedVolume;
			OnSoundParamChanged?.Invoke((mixerParamName, volume));
			_controllerState.Save();
		}

		public event Action<(MixerParamName paramName, float value)> OnSoundParamChanged;
	}
}