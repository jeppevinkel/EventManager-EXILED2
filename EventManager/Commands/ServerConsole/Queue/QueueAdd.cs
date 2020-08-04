using System;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Queue
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	class QueueAdd : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (arguments.IsEmpty())
			{
				response = $"Usage: em {Parent.Command} {Command} <event name>";
				return false;
			}

			string s = arguments.Join(delimiter: " ");

			EventManager.Instance.Config.EventQueue.Add(s);
			Config.SaveConfigChanges();

			response = $"{s} has been successfully added to the event queue.";
			return true;
		}

		public QueueAdd() { }

		public QueueAdd(ICommand parent)
		{
			Parent = parent;
		}

		public string Command { get; } = "add";
		public string[] Aliases { get; } = { };
		public string Description { get; } = "Add an event to the event queue.";
		public ICommand Parent = null;
	}
}