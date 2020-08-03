﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;

namespace EventManager.Api
{
	public class Event
	{
		public readonly IPlugin<IConfig> Plugin;
		public readonly string Name;

		public Event(IPlugin<IConfig> p, string n)
		{
			Plugin = p;
			Name = n;
		}
	}
}
