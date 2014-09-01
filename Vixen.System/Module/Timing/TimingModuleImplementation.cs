﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Sys.Attribute;

namespace Vixen.Module.Timing
{
	[TypeOfModule("Timing")]
	internal class TimingModuleImplementation : ModuleImplementation<ITimingModuleInstance>
	{
		public TimingModuleImplementation()
			: base(new TimingModuleManagement(), new TimingModuleRepository())
		{
		}
	}
}