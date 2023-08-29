using GameComponentAttributes.Attributes;
using UnityEngine;

namespace GameJamEntry.Global {
	public class AudioPlayerObjects : MonoBehaviour {
		[NotNullReference] public AudioSource BgmPlayer;
		[NotNullReference] public AudioSource SfxPlayer;
	}
}