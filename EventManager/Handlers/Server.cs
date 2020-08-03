using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.Api;

namespace EventManager.Handlers
{
	internal class Server
	{
		readonly Random _rand = new Random();

		internal void OnWaitingForPlayers()
		{
			Settings.CurrentEvent = Settings.NextEvent;

			if (EventManager.Instance.Config.AutoPlay && !EventManager.Instance.Config.EventQueue.IsEmpty())
			{
				string nxt =
					EventManager.Instance.Config.EventQueue[
						_rand.Next(EventManager.Instance.Config.EventQueue.Count)];

				Event ev = Settings.Events.FirstOrDefault(e => e.Name == nxt);
				Settings.NextEvent = ev;
			}
			else
			{
				Settings.NextEvent = null;
			}
		}

		public void OnRoundStarted()
		{
			if (Settings.CurrentEvent != null)
			{
				Settings.DisableBlacklistedPlugins();
			}
		}

		internal void OnRestartingRound()
		{
			if (Settings.CurrentEvent != null)
			{
				Settings.EnableBlacklistedPlugins();
			}
		}
	}
}
