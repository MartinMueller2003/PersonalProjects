﻿using System;
using System.Collections.Generic;
using System.Linq;
using Vixen.Execution;

namespace Vixen.Sys {
	class LiveDataSource : IDataSource {
		private EffectNodeQueue _data;

		public LiveDataSource() {
			_data = new EffectNodeQueue();
		}

		public void AddData(EffectNode effectNode) {
			_Add(effectNode);
		}

		public void AddData(IEnumerable<EffectNode> effectNodes) {
			foreach(EffectNode effectNode in effectNodes) {
				_Add(effectNode);
			}
		}

		public IEnumerable<IEffectNode> GetDataAt(TimeSpan time) {
			IEffectNode[] data = _data.Get(time).ToArray();
			return data;
		}

		private void _Add(EffectNode effectNode) {
			effectNode.StartTime += Execution.SystemTime.Position;
			_data.Add(effectNode);
		}
	}
}
