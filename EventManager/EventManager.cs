using System;
using Exiled.API.Enums;
using Exiled.API.Features;

using Server = Exiled.Events.Handlers.Server;

namespace EventManager
{
    public sealed class EventManager : Plugin<Config>
    {
		private static readonly Lazy<EventManager> LazyInstance = new Lazy<EventManager>(() => new EventManager());
		public static EventManager Instance => LazyInstance.Value;

		public override PluginPriority Priority { get; } = PluginPriority.Last;

		private Handlers.Server server;

		public override void OnEnabled()
		{
			base.OnEnabled();

			RegisterEvents();
		}

		public override void OnDisabled()
		{
			base.OnDisabled();

			UnregisterEvents();
		}

		private void RegisterEvents()
		{
			server = new Handlers.Server();

			Server.WaitingForPlayers += server.OnWaitingForPlayers;
			Server.RoundStarted += server.OnRoundStarted;
			Server.RestartingRound += server.OnRestartingRound;
		}

		private void UnregisterEvents()
		{
			Server.WaitingForPlayers -= server.OnWaitingForPlayers;

			server = null;
		}

		public override void OnRegisteringCommands()
		{
			base.OnRegisteringCommands();
		}

		private EventManager()
	    {
	    }
    }
}
