using System;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Blacklist
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	class Remove : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (arguments.IsEmpty())
			{
				response = $"Usage: em {Parent.Command} {Command} <plugin name>";
				return false;
			}

			string s = arguments.Join(delimiter: " ");

			if (EventManager.Instance.Config.PluginBlacklist.RemoveAll(str => str.Equals(s)) > 0)
			{
				Config.SaveConfigChanges();

				response = $"{s} has been successfully added to the blacklist.";
				return true;
			}

			response = $"{s} wasn't found on the blacklist.";
			return false;
		}

		public Remove(ICommand parent)
		{
			Parent = parent;
		}

		public string Command { get; } = "remove";
		public string[] Aliases { get; } = {"rm"};
		public string Description { get; } = "Remove a plugin from the blacklist.";
		public ICommand Parent = null;
	}
}