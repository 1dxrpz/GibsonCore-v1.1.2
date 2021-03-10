using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Rendering;

namespace GameEngineTK.Engine.Prototypes.Interfaces
{
	public interface IGameInstances
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public Layer parent { get; set; }
		public string name { get; set; }
		public void Draw();
	}
}
