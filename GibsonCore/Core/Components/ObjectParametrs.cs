using GibsonCore.Enums;

namespace GibsonCore.Components
{
	public abstract class ObjectParametrs
	{
		public VisibleState isVisible = VisibleState.Visible;
		public bool isDraggable = false;
		public bool MouseDown = false;
		public bool onHover = false;
	}
}
