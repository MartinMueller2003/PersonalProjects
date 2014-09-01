﻿using System.Linq;
using System.Xml.Linq;
using Vixen.Sys;

namespace Vixen.IO.Xml {
	class XmlSequenceWriter : XmlWriterBase<Sequence> {
		private const string ELEMENT_SEQUENCE = "Sequence";
		//private const string ELEMENT_TIMING_SOURCE = "TimingSource";
		private const string ELEMENT_MODULE_DATA = "ModuleData";
		//private const string ELEMENT_EFFECT_NODES = "EffectNodes";
		//private const string ELEMENT_EFFECT_NODE = "EffectNode";
		//private const string ELEMENT_START_TIME = "StartTime";
		//private const string ELEMENT_TIME_SPAN = "TimeSpan";
		//private const string ELEMENT_TARGET_NODES = "TargetNodes";
		//private const string ELEMENT_TARGET_NODE = "TargetNode";
		private const string ELEMENT_IMPLEMENTATION_CONTENT = "Implementation";
		//private const string ELEMENT_SELECTED_TIMING = "Selected";
		//private const string ELEMENT_FILTER_NODES = "FilterNodes";
		//private const string ELEMENT_FILTER_NODE = "FilterNode";
		//private const string ATTR_TYPE_ID = "typeId";
		//private const string ATTR_INSTANCE_ID = "instanceId";
		//private const string ATTR_ID = "id";
		private const string ATTR_LENGTH = "length";
		//private const string ATTR_SELECTED_TIMING_TYPE = "type";
		//private const string ATTR_SELECTED_TIMING_SOURCE = "source";

		override protected XElement _CreateContent(Sequence sequence) {
			XElement element = new XElement(ELEMENT_SEQUENCE,
				new XAttribute(ATTR_LENGTH, sequence.Length.Ticks),
				_WriteTimingSource(sequence),
				_WriteModuleData(sequence),
				_WriteEffectNodes(sequence),
				_WriteFilterNodes(sequence),
				_WriteImplementationContent(sequence));

			return element;
		}

		private XElement _WriteTimingSource(Sequence sequence) {
			XmlSelectedTimingProviderSerializer serializer = new XmlSelectedTimingProviderSerializer();
			return serializer.WriteObject(sequence.TimingProvider.SelectedTimingProvider);
		}
		//private XElement _WriteTimingSource(Sequence sequence) {
		//    string providerType;
		//    string sourceName;

		//    sequence.TimingProvider.GetSelectedSource(out providerType, out sourceName);

		//    return new XElement(ELEMENT_TIMING_SOURCE,
		//        new XElement(ELEMENT_SELECTED_TIMING,
		//            new XAttribute(ATTR_SELECTED_TIMING_TYPE, providerType ?? string.Empty),
		//            new XAttribute(ATTR_SELECTED_TIMING_SOURCE, sourceName ?? string.Empty)));
		//}

		private XElement _WriteModuleData(Sequence sequence) {
			return new XElement(ELEMENT_MODULE_DATA, sequence.ModuleDataSet.ToXElement());
		}

		private XElement _WriteEffectNodes(Sequence sequence) {
			XmlEffectNodeCollectionSerializer serializer = new XmlEffectNodeCollectionSerializer();
			return serializer.WriteObject(sequence.Data.GetMainStreamData().Cast<EffectNode>());
		}
		//private XElement _WriteEffectNodes(Sequence sequence) {
		//    return new XElement(ELEMENT_EFFECT_NODES,
		//        sequence.Data.GetMainStreamData().Cast<EffectNode>().Select(x =>
		//            new XElement(ELEMENT_EFFECT_NODE,
		//                new XAttribute(ATTR_TYPE_ID, x.Effect.Descriptor.TypeId),
		//                new XAttribute(ATTR_INSTANCE_ID, x.Effect.InstanceId),
		//                new XElement(ELEMENT_START_TIME, x.StartTime.Ticks),
		//                new XElement(ELEMENT_TIME_SPAN, x.TimeSpan.Ticks),
		//                new XElement(ELEMENT_TARGET_NODES,
		//                    x.Effect.TargetNodes.Select(y => 
		//                        new XElement(ELEMENT_TARGET_NODE,
		//                            new XAttribute(ATTR_ID, y.Id)))))));
		//}

		private XElement _WriteFilterNodes(Sequence sequence) {
			XmlPreFilterNodeCollectionSerializer serializer = new XmlPreFilterNodeCollectionSerializer();
			return serializer.WriteObject(sequence.GetPreFilters());
		}
		//private XElement _WriteFilterNodes(Sequence sequence) {
		//    return new XElement(ELEMENT_FILTER_NODES,
		//        sequence.GetPreFilters().Select(x =>
		//            new XElement(ELEMENT_FILTER_NODE,
		//                new XAttribute(ATTR_TYPE_ID, x.PreFilter.Descriptor.TypeId),
		//                new XAttribute(ATTR_INSTANCE_ID, x.PreFilter.InstanceId),
		//                new XElement(ELEMENT_START_TIME, x.StartTime.Ticks),
		//                new XElement(ELEMENT_TIME_SPAN, x.TimeSpan.Ticks),
		//                new XElement(ELEMENT_TARGET_NODES,
		//                    x.PreFilter.TargetNodes.Select(y =>
		//                        new XElement(ELEMENT_TARGET_NODE,
		//                            new XAttribute(ATTR_ID, y.Id)))))));
		//}

		private XElement _WriteImplementationContent(Sequence sequence) {
			return new XElement(ELEMENT_IMPLEMENTATION_CONTENT, _WriteContent(sequence));
		}

		virtual protected XElement _WriteContent(Sequence sequence) {
			return null;
		}

	}
}
