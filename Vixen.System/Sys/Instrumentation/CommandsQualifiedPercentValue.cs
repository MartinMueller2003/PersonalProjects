﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Instrumentation;

namespace Vixen.Sys.Instrumentation
{
	internal class CommandsQualifiedPercentValue : PercentValue
	{
		public CommandsQualifiedPercentValue()
			: base("Commands - Qualified (%)")
		{
		}
	}
}