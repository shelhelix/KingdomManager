using System;
using GameComponentAttributes.Attributes;
using GameJamEntry.General;
using UnityEngine;
using UnityEngine.Audio;
using VContainer;

namespace GameJamEntry.MainMenu {
	public class SoundSettingsWatcher : MonoBehaviour, IDisposable {
		[NotNullReference] [SerializeField] AudioMixer Mixer;

		SoundSettingsController _soundSettingsController;
		
		[Inject]
		public void Init(SoundSettingsController settingsController) {
			_soundSettingsController                     =  settingsController;
			_soundSettingsController.OnSoundParamChanged += OnSoundParamChanged;
			UpdateValues();
		}

		public void Dispose() {
			if ( _soundSettingsController == null ) {
				return;
			}
			_soundSettingsController.OnSoundParamChanged -= OnSoundParamChanged;
		}
		
		void OnSoundParamChanged((MixerParamName name, float value) paramChanged) {
			UpdateValues();
		}
		
		void UpdateValues() {
			foreach ( MixerParamName mixerParam in Enum.GetValues(typeof(MixerParamName)) ) {
				var normalizedVolume = _soundSettingsController.GetNormalizedVolume(mixerParam);
				var volume           = GetAbsoluteVolume(normalizedVolume);
				Mixer.SetFloat(mixerParam.ToString(), volume);
			}
		}

		float GetAbsoluteVolume(float normalizedVolume) => Mathf.Log10(normalizedVolume) * 20;
	}
}