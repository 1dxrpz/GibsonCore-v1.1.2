using GameEngineTK.Core.Prototypes.Enums;

namespace GameEngineTK.Core.Components
{
	public abstract class ObjectParametrs
	{
		public VisibleState isVisible = VisibleState.Visible;
		public bool isDraggable = false;
		public bool MouseDown = false;
		public bool onHover = false;
	}
}
