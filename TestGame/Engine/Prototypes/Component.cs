using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class Component
	{
		public Vector2 Position;
		public int Width;
		public int Height;

		public virtual void Update() { }
	}
}
