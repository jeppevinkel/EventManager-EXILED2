using System;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Whitelist
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	class Enable : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			EventManager.Instance.Config.UseEventWhitelist = true;
			Config.SaveConfigChanges();

			response = $"The event whitelist has been successfully enabled.";
			return true;
		}

		public Enable(ICommand parent)
		{
			Parent = parent;
		}

		public string Command { get; } = "enable";
		public string[] Aliases { get; } = {"en"};
		public string Description { get; } = "Enable the event whitelist.";
		public ICommand Parent = null;
	}
}