using GameJamEntry.General;
using GameJamEntry.Global;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameJamEntry {
	public class GameStartScope : LifetimeScope {
		protected override void Configure(IContainerBuilder builder) {
			base.Configure(builder);
			var globalGameState = new GlobalGameState();
			builder.RegisterInstance(globalGameState);
			builder.RegisterInstance(globalGameState.SoundSettingsController);
			builder.RegisterInstance(CreateGlobalObjects());
			builder.Register<AudioPlayer>(Lifetime.Singleton);
			builder.Register<BgmManager>(Lifetime.Singleton);
		}

		AudioPlayerObjects CreateGlobalObjects() {
			var instance = Instantiate(Resources.Load<AudioPlayerObjects>("GameWideObjects"));
			DontDestroyOnLoad(instance.gameObject);
			return instance;
		}
	}
}