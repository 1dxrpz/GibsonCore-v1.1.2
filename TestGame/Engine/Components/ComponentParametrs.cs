using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Enums;

namespace GameEngineTK.Engine.Components
{
	public abstract class ComponentParametrs
	{
		public VisibleState isVisible = VisibleState.Visible;
		public bool isDraggable = false;
		public bool MouseDown = false;
		public bool onHover = false;
	}
}
