using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem;
using Exiled.API.Interfaces;

namespace EventManager.Commands.ServerConsole
{
	[CommandHandler(typeof(GameConsoleCommandHandler))]
	class Plugins : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (Exiled.Loader.Loader.Plugins.IsEmpty())
			{
				response = "No plugins are currently loaded.";
				return false;
			}

			StringBuilder stringBuilder = new StringBuilder("Loaded plugins:\n");

			foreach (IPlugin<IConfig> plugin in Exiled.Loader.Loader.Plugins)
			{
				stringBuilder.AppendLine($" - {plugin.Name}");
			}

			response = stringBuilder.ToString();
			return true;
		}

		public string Command { get; } = "plugins";
		public string[] Aliases { get; } = { };
		public string Description { get; } = "Returns a list of all plugin assembly names.";
	}
}
