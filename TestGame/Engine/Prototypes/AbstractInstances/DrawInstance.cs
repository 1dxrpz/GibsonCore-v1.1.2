using GameEngineTK.Engine.Components;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Prototypes
{
	internal abstract class DrawInstance : ComponentInstance, IDrawInstance
	{
		public DrawInstance() => GameManager.DrawEvent += this.Draw;
		public virtual void Draw() { }
	}
}
