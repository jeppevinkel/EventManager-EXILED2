using System;
using System.Collections.Generic;
using System.Text;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Queue
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	public class Prefix : ParentCommand
	{
		public Prefix() => LoadGeneratedCommands();

		public override void LoadGeneratedCommands()
		{
			RegisterCommand(new QueueAdd(this));
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

		public override string Command { get; } = "queue";
		public override string[] Aliases { get; } = {"q"};
		public override string Description { get; } = "The parent command for all EventManager Queue related commands.";
	}
}
