using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	public class Layer : RenderingInstance
	{
		public Layout Parent;
		public List<IGameInstances> Children = new List<IGameInstances>();
	}
}
