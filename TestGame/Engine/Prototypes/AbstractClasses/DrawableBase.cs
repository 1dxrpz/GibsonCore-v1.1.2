using GameEngineTK.Engine.Components;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Prototypes
{
	internal abstract class DrawableBase : ComponentBase, IDrawableObject
	{
		public DrawableBase() => GameManager.DrawEvent += this.Draw;
		public virtual void Draw() { }
	}
}
