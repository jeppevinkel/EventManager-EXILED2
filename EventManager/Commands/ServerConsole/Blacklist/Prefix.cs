using System;
using System.Collections.Generic;
using System.Text;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Blacklist
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	public class Prefix : ParentCommand
	{
		public Prefix() => LoadGeneratedCommands();

		public override void LoadGeneratedCommands()
		{
			RegisterCommand(new Add(this));
			RegisterCommand(new Remove(this));
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

		public override string Command { get; } = "blacklist";
		public override string[] Aliases { get; } = { "bl" };
		public override string Description { get; } = "The parent command for all EventManager Blacklist related commands.";
	}
}