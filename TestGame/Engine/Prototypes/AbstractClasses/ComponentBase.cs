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
		public ComponentHandler ParentObject { get; set; }
		public ComponentBase()
		{
			GameManager.UpdateEvent += this.Update;
		}

		public virtual void Update() { }
		public virtual void Init() { }
	}
}
