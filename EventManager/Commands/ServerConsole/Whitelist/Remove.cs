using System;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Whitelist
{
	class Remove : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (arguments.IsEmpty())
			{
				response = $"Usage: em {Parent.Command} {Command} <event name>";
				return false;
			}

			string s = arguments.Join(delimiter: " ");

			if (EventManager.Instance.Config.PluginBlacklist.RemoveAll(str => str.Equals(s)) > 0)
			{
				Config.SaveConfigChanges();

				response = $"{s} has been successfully added to the whitelist.";
				return true;
			}

			response = $"{s} wasn't found on the whitelist.";
			return false;
		}

		public Remove() { }

		public Remove(ICommand parent)
		{
			Parent = parent;
		}

		public string Command { get; } = "remove";
		public string[] Aliases { get; } = {"rm"};
		public string Description { get; } = "Remove an event from the event whitelist.";
		public ICommand Parent = null;
	}
}