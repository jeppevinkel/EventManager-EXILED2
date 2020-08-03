using System;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Whitelist
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	class Add : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (arguments.IsEmpty())
			{
				response = $"Usage: em {Parent.Command} {Command} <event name>";
				return false;
			}

			string s = arguments.Join(delimiter: " ");

			EventManager.Instance.Config.EventWhitelist.Add(s);
			Config.SaveConfigChanges();

			response = $"{s} has been successfully added to the whitelist.";
			return true;
		}

		public Add(ICommand parent)
		{
			Parent = parent;
		}

		public string Command { get; } = "add";
		public string[] Aliases { get; } = { };
		public string Description { get; } = "Add an event to the whitelist.";
		public ICommand Parent = null;
	}
}
