using System;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Queue
{
	class Enable : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			EventManager.Instance.Config.UseEventWhitelist = true;
			Config.SaveConfigChanges();

			response = $"The event queue has been successfully enabled.";
			return true;
		}

		public Enable() { }

		public Enable(ICommand parent)
		{
			Parent = parent;
		}

		public string Command { get; } = "enable";
		public string[] Aliases { get; } = {"en"};
		public string Description { get; } = "Enable the event queue.";
		public ICommand Parent = null;
	}
}