using GibsonCore.Interfaces;

namespace GibsonCore.Abstract
{
	public abstract class DrawableBase : DxComponent, IDrawableObject
	{
		public DrawableBase()
		{

		}
		public virtual void Draw() { }
		public virtual void Unload() { }
	}
	public abstract class DefaultRendererBase : DefaultComponent, IDrawableObject
	{
		public DefaultRendererBase()
		{

		}
		public virtual void Draw() { }
		public virtual void Unload() { }
	}
}
