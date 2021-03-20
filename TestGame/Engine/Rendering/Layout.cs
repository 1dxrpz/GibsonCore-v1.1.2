using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	public class Layout : RenderingInstance
	{
		public Scene Parent;
		public List<Layer> Children = new List<Layer>();
	}
}
