using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Rendering;
using GameEngineTK.Engine.Utils;

namespace GameEngineTK.Engine.Prototypes.Interfaces
{
	public interface IGameInstances
	{
		Layer Parent { get; set; }
		public string name { get; set; }
		public void Draw();
	}
}
