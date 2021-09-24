using System;
using GibsonCore.Components;
using GibsonCore.Interfaces;

namespace GibsonCore.Abstract
{
	public abstract class ComponentBase : IComponentObject
	{
		protected Transform transform;
		public Action<bool> EnableStateChanged;
		public ComponentHandler ParentObject { get; set; }

		private bool _enabled;

		public bool Enabled
		{
			get => _enabled;
			set
			{
				EnableStateChanged?.Invoke(value);
				_enabled = value;
			}
		}

		public ComponentBase()
		{
			EnableStateChanged += EnableChanged;
			//GameManager.UpdateEvent += this.Update;
		}

		public virtual void Update() { }
		public virtual void Init() { }

		public virtual void EnableChanged(bool state) { }
	}
}
