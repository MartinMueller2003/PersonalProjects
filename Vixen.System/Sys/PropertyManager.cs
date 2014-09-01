﻿using System;
using System.Collections.Generic;
using Vixen.Module;
using Vixen.Module.Property;

namespace Vixen.Sys
{
	public class PropertyManager : IEnumerable<IPropertyModuleInstance>
	{
		private Dictionary<Guid, IPropertyModuleInstance> _items = new Dictionary<Guid, IPropertyModuleInstance>();
		//private ModuleLocalDataSet _propertyData;
		private ElementNode _owner;

		public PropertyManager(ElementNode owner)
		{
			_owner = owner;
			//PropertyData = new ModuleLocalDataSet();
		}

		public IPropertyModuleInstance Add(IPropertyModuleInstance instance)
		{
			//IPropertyModuleInstance instance = null;

			if (!_items.ContainsKey(instance.TypeId)) {
				//instance = Modules.ModuleManagement.GetProperty(id);
				if (instance != null) {
					instance.Owner = _owner;
					instance.SetDefaultValues();
					_items[instance.TypeId] = instance;
					PropertyData.AssignModuleInstanceData(instance);
				}
			}

			return instance;
		}

		public IPropertyModuleInstance Add(Guid id)
		{
			IPropertyModuleInstance instance = null;

			if (!_items.ContainsKey(id)) {
				instance = Modules.ModuleManagement.GetProperty(id);
				if (instance != null) {
					instance.Owner = _owner;
					instance.SetDefaultValues();
					_items[id] = instance;
					PropertyData.AssignModuleInstanceData(instance);
				}
			}

			return instance;
		}

		public void Remove(Guid id)
		{
			IPropertyModuleInstance instance;
			if (_items.TryGetValue(id, out instance)) {
				instance.Owner = null;
				_items.Remove(id);
				PropertyData.RemoveModuleTypeData(instance);
			}
		}

		public void Clear()
		{
			_items.Clear();
			PropertyData.Clear();
		}

		public IPropertyModuleInstance Get(Guid propertyTypeId)
		{
			IPropertyModuleInstance instance;
			_items.TryGetValue(propertyTypeId, out instance);
			return instance;
		}

		public bool Contains(Guid propertyTypeId)
		{
			return _items.ContainsKey(propertyTypeId);
		}

		public ModuleLocalDataSet PropertyData
		{
			get { return VixenSystem.ModuleStore.InstanceData; }
		}

		//public ModuleLocalDataSet PropertyData {
		//    get { return _propertyData; }
		//    set {
		//        _propertyData = value;
		//        // Update any properties we already have.
		//        foreach(IPropertyModuleInstance propertyModule in _items.Values) {
		//            _propertyData.AssignModuleTypeData(propertyModule);
		//        }
		//    }
		//}

		public IEnumerator<IPropertyModuleInstance> GetEnumerator()
		{
			return _items.Values.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}