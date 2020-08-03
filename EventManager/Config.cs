using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Exiled.API.Interfaces;
using Exiled.Loader;

namespace EventManager
{
	public sealed class Config : IConfig
	{
		[Description("Determines if the EventManager should be enabled or not.")]
		public bool IsEnabled { get; set; } = true;

		[Description("Enables automatically playing events.")]
		public bool AutoPlay { get; set; } = false;

		[Description("Events to play during auto play. Putting the same event multiple times increases the chance of it being chosen. (complete list of events can be found by typing \"em list\")")]
		public List<string> EventQueue { get; set; } = new List<string>();

		[Description("Determines if only whitelisted events should be used.")]
		public bool UseEventWhitelist { get; set; } = false;

		[Description("Whitelisted events if whitelist is enabled.")]
		public List<string> EventWhitelist { get; set; } = new List<string>();

		[Description("List of plugins to disable during events. (list of names can be found by typing \"em plugins\")")]
		public List<string> PluginBlacklist { get; set; } = new List<string>
		{
			"SCP-575",
			"tranq-gun"
		};

		internal static void SaveConfigChanges()
		{
			Dictionary<string, IConfig> configs = Loader.Plugins.ToDictionary(plugin => plugin.Prefix, plugin => plugin.Config);
			configs.Add("exiled_loader", Loader.Config);

			ConfigManager.Save(configs);
			ConfigManager.Reload();
		}
	}
}
