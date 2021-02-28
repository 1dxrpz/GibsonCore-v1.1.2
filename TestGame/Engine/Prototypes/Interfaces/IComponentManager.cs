using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameEngineTK.Engine.Prototypes.Interfaces
{
	public interface IComponentManager
	{
		public Vector2 Position { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public void Update();
	}
}
