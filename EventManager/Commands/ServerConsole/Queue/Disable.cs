using System;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Queue
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	class Disable : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			EventManager.Instance.Config.UseEventWhitelist = false;
			Config.SaveConfigChanges();

			response = $"The event queue has been successfully disabled.";
			return true;
		}

		public Disable(ICommand parent)
		{
			Parent = parent;
		}

		public string Command { get; } = "disable";
		public string[] Aliases { get; } = {"dis"};
		public string Description { get; } = "Disable the event queue.";
		public ICommand Parent = null;
	}
}