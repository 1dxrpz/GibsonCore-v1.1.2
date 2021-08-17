using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngineTK.Engine.Prototypes;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Components
{
	internal abstract class ComponentBase : IComponentObject
	{
		public Action<bool> EnableStateChanged;
		private bool _enabled;
		public ComponentHandler ParentObject { get; set; }

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
			GameManager.UpdateEvent += this.Update;
		}

		public virtual void Update() { }
		public virtual void Init() { }

		public virtual void EnableChanged(bool state) { }
	}
}
