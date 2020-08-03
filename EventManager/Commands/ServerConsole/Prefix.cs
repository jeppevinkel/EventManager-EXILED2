using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	public class Prefix : ParentCommand
	{
		public Prefix() => LoadGeneratedCommands();

		public override void LoadGeneratedCommands()
		{
			RegisterCommand(new Queue.Prefix());
			RegisterCommand(new Blacklist.Prefix());
			RegisterCommand(new Whitelist.Prefix());
			RegisterCommand(new Reload());
			RegisterCommand(new List());
			RegisterCommand(new Plugins());
			RegisterCommand(new Play());
		}

		protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			StringBuilder stringBuilder = new StringBuilder("Available commands:\n");

			foreach (KeyValuePair<string, ICommand> kvp in Commands)
			{
				stringBuilder.AppendLine($" - {Command} {kvp.Key} - {kvp.Value.Description} - Aliases: ({kvp.Value.Aliases.Join()})");
			}

			response = stringBuilder.ToString();
			return true;
		}

		public override string Command { get; } = "em";
		public override string[] Aliases { get; } = {"eventmanager"};
		public override string Description { get; } = "The parent command for all EventManager related commands.";
	}
}
