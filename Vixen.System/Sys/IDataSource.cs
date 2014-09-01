﻿using System;
using System.Collections.Generic;

namespace Vixen.Sys {
	public interface IDataSource {
		IEnumerable<IEffectNode> GetDataAt(TimeSpan time);
	}
}
