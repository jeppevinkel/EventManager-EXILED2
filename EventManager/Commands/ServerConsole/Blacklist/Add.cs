using System;
using CommandSystem;
using HarmonyLib;

namespace EventManager.Commands.ServerConsole.Blacklist
{
	class Add : ICommand
	{
		public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
		{
			if (arguments.IsEmpty())
			{
				response = $"Usage: em {Parent.Command} {Command} <plugin name>";
				return false;
			}

			string s = arguments.Join(delimiter: " ");

			EventManager.Instance.Config.PluginBlacklist.Add(s);
			Config.SaveConfigChanges();

			response = $"{s} has been successfully added to the blacklist.";
			return true;
		}

		public Add() { }

		public Add(ICommand parent)
		{
			Parent = parent;
		}

		public string Command { get; } = "add";
		public string[] Aliases { get; } = { };
		public string Description { get; } = "Add new plugin to the blacklist.";
		public ICommand Parent = null;
	}
}
