using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using EventManager.Api;

namespace EventManager.Commands.ServerConsole
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	class List : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (Settings.Events.IsEmpty())
			{
				response = "No events are currently loaded.";
				return false;
			}
			StringBuilder stringBuilder = new StringBuilder("Available events:\n");
			foreach (Event @event in Settings.Events)
			{
				stringBuilder.AppendLine($" - {@event.Name}");
			}

			response = stringBuilder.ToString();
			return true;
		}

		public string Command { get; } = "list";
		public string[] Aliases { get; } = {"ls"};
		public string Description { get; } = "Lists all registered events.";
	}
}
