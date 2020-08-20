using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;

namespace EventManager.Commands.ServerConsole
{
	class Reload : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			response = "Not implemented yet.";
			return false;
		}

		public string Command { get; } = "reload";
		public string[] Aliases { get; } = { "rl" };
		public string Description { get; } = "Reloads the something";
	}
}
