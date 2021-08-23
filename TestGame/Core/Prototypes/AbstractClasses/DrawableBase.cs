using GameEngineTK.Core.Components;
using GameEngineTK.Core.Prototypes.Interfaces;

namespace GameEngineTK.Core.Prototypes
{
	internal abstract class DrawableBase : ComponentBase, IDrawableObject
	{
		public DrawableBase() => GameManager.DrawDefaultEvent += this.Draw;
		public virtual void Draw() { }
		public virtual void Unload() { }
	}
}
