﻿using System.Collections.Generic;
using Com.Shelinc.FullscreenCanvasController;
using Com.Shelinc.SceneTransitionEffects;
using Com.Shelinc.SceneTransitionEffects.Transitions.Implementations;
using GameComponentAttributes.Attributes;
using GameJamEntry.Gameplay.UI;
using GameJamEntry.Gameplay.Zones;
using GameJamEntry.Gameplay.Zones.RandomEncounters;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameJamEntry.Gameplay {
	public class GameplayScope : LifetimeScope {
		[NotNullReference] [SerializeField] List<ZoneView>     Zones;
		[NotNullReference] [SerializeField] EncounterConfig    EncounterConfig;
		[NotNullReference] [SerializeField] ScreenManager      ScreenManager;
		[NotNullReference] [SerializeField] ManaTransferWindow ManaTransferWindow;

		protected override void Configure(IContainerBuilder builder) {
			base.Configure(builder);
			builder.RegisterInstance(EncounterConfig);
			builder.RegisterInstance(Zones);
			builder.RegisterInstance(ScreenManager);
			builder.RegisterInstance(ManaTransferWindow);

			builder.Register<ManaManager>(Lifetime.Scoped);
			builder.Register<ManaIncomer>(Lifetime.Scoped);
			builder.Register<ZoneController>(Lifetime.Scoped);
			builder.Register<RandomZoneEncounter>(Lifetime.Scoped);
			builder.Register<TurnManager>(Lifetime.Scoped);
			builder.Register<GameplayGoalWatcher>(Lifetime.Scoped);

			builder.RegisterInstance(new SceneLoader(FadeSceneTransition.Instance));
		}
	}
}