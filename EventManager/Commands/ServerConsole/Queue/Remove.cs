using System;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Queue
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
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

			if (EventManager.Instance.Config.EventQueue.RemoveAll(str => str.Equals(s)) > 0)
			{
				Config.SaveConfigChanges();

				response = $"{s} has been successfully added to the event queue.";
				return true;
			}

			response = $"{s} wasn't found in the event queue.";
			return false;
		}

		public Remove() { }

		public Remove(ICommand parent)
		{
			Parent = parent;
		}

		public string Command { get; } = "remove";
		public string[] Aliases { get; } = { "rm" };
		public string Description { get; } = "Remove an event from the event queue.";
		public ICommand Parent = null;
	}
}