using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine.Rendering
{
	abstract public class RenderingInstance<P>
	{
		public string name;
		public P parent;
		public bool IsVisible;
	}
}
