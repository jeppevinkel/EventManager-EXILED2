using System.Collections.Generic;
using System.Linq;
using EventManager.Api;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace EventManager
{
	public static class Settings
	{
		internal static List<Event> Events = new List<Event>();

		internal static Event CurrentEvent = null;

		internal static Event NextEvent = null;

		internal static bool EnableEvent(string name)
		{
			if (name.IsEmpty())
			{
				Log.Debug($"Event name not supplied.", Exiled.Loader.Loader.ShouldDebugBeShown);
				return false;
			}

			Event ev = Events.FirstOrDefault(e => e.Name == name);

			if (ev == null)
			{
				Log.Debug($"Event ({ev.Name}) not found.", Exiled.Loader.Loader.ShouldDebugBeShown);
				return false;
			}

			if (Round.IsStarted)
			{
				NextEvent = ev;
				Log.Debug($"Next event set to ({ev.Name}).", Exiled.Loader.Loader.ShouldDebugBeShown);
				return true;
			}
			else
			{
				CurrentEvent = ev;
				Log.Debug($"Current event set to ({ev.Name}).", Exiled.Loader.Loader.ShouldDebugBeShown);
				return true;
			}
		}

		internal static void DisableBlacklistedPlugins()
		{
			Log.Info("Disabling blacklisted plugins...");
			foreach (IPlugin<IConfig> plugin in Exiled.Loader.Loader.Plugins.Where(p => p.Config.IsEnabled))
			{
				if (!EventManager.Instance.Config.PluginBlacklist.Contains(plugin.Name)) continue;
				plugin.OnDisabled();
				plugin.OnUnregisteringCommands();
			}
		}

		internal static void EnableBlacklistedPlugins()
		{
			Log.Info("Re-enabling blacklisted plugins...");
			foreach (IPlugin<IConfig> plugin in Exiled.Loader.Loader.Plugins.Where(p => p.Config.IsEnabled))
			{
				if (!EventManager.Instance.Config.PluginBlacklist.Contains(plugin.Name)) continue;
				plugin.OnEnabled();
				plugin.OnRegisteringCommands();
			}
		}
	}
}
