using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Components;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Prototypes
{
	public abstract class DrawInstance : ComponentInstance, IDrawInstance
	{
		public DrawInstance()
		{
			GameManager.DrawEvent += this.Draw;
		}
		public virtual void Draw() { }
	}
}
