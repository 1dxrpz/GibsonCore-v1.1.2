using GibsonCore.Interfaces;

namespace GibsonCore.Abstract
{
	public abstract class DrawableBase : ComponentBase, IDrawableObject
	{
		public DrawableBase()
		{

		}
		public virtual void Draw() { }
		public virtual void Unload() { }
	}
}
