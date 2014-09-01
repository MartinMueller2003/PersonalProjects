﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Sys.Attribute;

namespace Vixen.Module.Media
{
	[TypeOfModule("Media")]
	internal class MediaModuleImplementation : ModuleImplementation<IMediaModuleInstance>
	{
		public MediaModuleImplementation()
			: base(new MediaModuleManagement(), new MediaModuleRepository())
		{
		}
	}
}