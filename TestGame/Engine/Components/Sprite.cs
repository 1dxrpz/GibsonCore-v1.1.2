using GameEngineTK.Engine.Utils;
using Microsoft.Xna.Framework;

namespace GameEngineTK.Engine.Components
{
	class Sprite : SpriteBase
	{
		public Vector2 OriginPosition = new Vector2();

		public override void Update()
		{
			Width = ParentObject.GetComponent<Transform>().Width;
			Height = ParentObject.GetComponent<Transform>().Height;
		}
	}
}
