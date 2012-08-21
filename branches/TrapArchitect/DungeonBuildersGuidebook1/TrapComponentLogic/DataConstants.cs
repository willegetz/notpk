﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DungeonBuildersGuidebook1.TrapComponentLogic
{
	public static class DataConstants
	{
		public static string DataFilesPath
		{
			get { return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\DataFiles\"; }
		}
	}
}
