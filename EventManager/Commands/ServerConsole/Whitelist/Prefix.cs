using System;
using System.Collections.Generic;
using System.Text;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Whitelist
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	public class Prefix : ParentCommand
	{
		public Prefix() => LoadGeneratedCommands();

		public override void LoadGeneratedCommands()
		{
			RegisterCommand(new Add(this));
			RegisterCommand(new Remove(this));
			RegisterCommand(new Enable(this));
			RegisterCommand(new Disable(this));
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

		public override string Command { get; } = "whitelist";
		public override string[] Aliases { get; } = { "wl" };
		public override string Description { get; } = "The parent command for all EventManager Event Whitelist related commands.";
	}
}