using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Exiled.API.Features;
using Exiled.API.Interfaces;

namespace EventManager.Api
{
	public static class Api
	{
		/// <summary>
		/// Register event to EventManager.
		/// </summary>
		/// <param name="plugin">The plugin used for the event.</param>
		/// <param name="name">Name of the event. (As few words as possible. Preferably a single word)</param>
		/// <returns>Success status.</returns>
		public static bool RegisterEvent(IPlugin<IConfig> plugin, string name = null)
		{
			try
			{
				string n = string.IsNullOrEmpty(name) ? plugin.Name : name;

				if (EventManager.Instance.Config.UseEventWhitelist && !EventManager.Instance.Config.EventWhitelist.Contains(n))
				{
					return false;
				}

				Settings.Events.Add(new Event(plugin, n));
				return true;
			}
			catch (Exception e)
			{
				Log.Error(e);
				return false;
			}
		}

		/// <summary>
		/// Returns the currently running event.
		/// </summary>
		/// <returns>Currently running event.</returns>
		public static Event GetCurrentEvent()
		{
			return Settings.CurrentEvent;
		}

		/// <summary>
		/// Returns the next event.
		/// </summary>
		/// <returns>Next event.</returns>
		public static Event GetNextEvent()
		{
			return Settings.NextEvent;
		}

		/// <summary>
		/// Returns a readonly list of all events.
		/// </summary>
		/// <returns>List of events.</returns>
		public static ReadOnlyCollection<Event> GetEventList()
		{
			return Settings.Events.AsReadOnly();
		}
	}
}
