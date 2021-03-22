using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Rendering;
using GameEngineTK.Engine.Utils;

namespace GameEngineTK.Engine.Prototypes.Interfaces
{
	public interface IGameInstances
	{
		public TextureHandler texture { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public Layer parent { get; set; }
		public string name { get; set; }
		public void Draw();
	}
}
