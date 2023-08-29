using System;
using UnityEngine;

namespace GameJamEntry.Global {
	public class AudioPlayer {
		AudioSource _sfxSource;
		AudioSource _bgmSource;

		public event Action BgmClipEnded; 
		
		AudioSourceWatcher _bgmWatcher;
		
		public AudioPlayer(AudioPlayerObjects audioPlayerObjects) {
			_sfxSource                    =  audioPlayerObjects.SfxPlayer;
			_bgmSource                    =  audioPlayerObjects.BgmPlayer;
			_bgmWatcher                   =  new AudioSourceWatcher(_bgmSource);
			_bgmWatcher.IsFinishedPlaying += OnBgmFinished;
		}
		
		public void PlaySfx(AudioClip clip) {
			_sfxSource.PlayOneShot(clip);
		}
		
		public void PlayBgm(AudioClip clip, bool loop = true) {
			_bgmWatcher.StopWatching();
			_bgmSource.clip = clip;
			_bgmSource.loop = loop;
			_bgmSource.Play();
			_bgmWatcher.StartWatching();
		}

		void OnBgmFinished() {
			BgmClipEnded?.Invoke();
		}
	}
}