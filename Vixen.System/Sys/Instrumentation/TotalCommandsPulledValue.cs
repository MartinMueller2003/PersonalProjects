﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Instrumentation;

namespace Vixen.Sys.Instrumentation
{
	internal class TotalCommandsPulledValue : CountValue
	{
		public TotalCommandsPulledValue()
			: base("Total Commands Pulled")
		{
		}
	}
}