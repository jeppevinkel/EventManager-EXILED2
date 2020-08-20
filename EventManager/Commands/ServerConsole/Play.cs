using System;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole
{
	class Play : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (arguments.IsEmpty())
			{
				response = $"Usage: em {Command} <event name>";
				return false;
			}

			string s = arguments.Join(delimiter: " ");

			if (Settings.EnableEvent(s))
			{
				response = $"Next event set to {s}";
				return true;
			}
			response = $"Failed to set next event to {s}";
			return false;
		}

		public string Command { get; } = "play";
		public string[] Aliases { get; } = {"pl"};
		public string Description { get; } = "Sets the next event to <event name>.";
	}
}
