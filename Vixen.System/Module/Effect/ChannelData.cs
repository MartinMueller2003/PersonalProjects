﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vixen.Sys;
using Vixen.Commands;

namespace Vixen.Module.Effect {
	// Operates against CommandNodes because the effect needs to generate data that is
	// timed relative to the effect's start.
	public class ChannelData : Dictionary<Guid, CommandNode[]> {
		public ChannelData() {
		}

		public ChannelData(IDictionary<Guid, CommandNode[]> data)
			: base(data) {
		}

		public void AddCommandNodesForChannel(Guid channel, IEnumerable<CommandNode> commands)
		{
			if (ContainsKey(channel)) {
				this[channel] = this[channel].Concat(commands).ToArray();
			} else {
				this[channel] = commands.ToArray();
			}
		}

		public void AddCommandNodeForChannel(Guid channel, params CommandNode[] commands)
		{
			AddCommandNodesForChannel(channel, commands);
		}

		public void AddChannelData(ChannelData other)
		{
			foreach (KeyValuePair<Guid, CommandNode[]> kvp in other) {
				AddCommandNodesForChannel(kvp.Key, kvp.Value);
			}
		}

		public void OffsetAllCommandsByTime(TimeSpan offset)
		{
			foreach (KeyValuePair<Guid, CommandNode[]> kvp in this.ToArray()) {
				List<CommandNode> newCommands = new List<CommandNode>();
				foreach (CommandNode cn in kvp.Value)
					newCommands.Add(new CommandNode(cn.Command, cn.StartTime + offset, cn.TimeSpan));
				this[kvp.Key] = newCommands.ToArray();
			}
		}

		static public ChannelData Restrict(ChannelData channelData, TimeSpan startTime, TimeSpan endTime)
		{
			return new ChannelData(channelData.ToDictionary(
				x => x.Key,
				x => x.Value.Where(y => !(y.StartTime >= endTime || y.EndTime < startTime)).ToArray()));
		}
	}
}
