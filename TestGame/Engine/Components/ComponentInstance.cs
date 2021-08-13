using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngineTK.Engine.Prototypes;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Components
{
	public abstract class ComponentInstance : IComponentInstance
	{
		public ComponentHandler ParentObject { get; set; }
		public ComponentInstance()
		{
			GameManager.UpdateEvent += this.Update;
		}

		public virtual void Update()
		{
			
		}
	}
}
