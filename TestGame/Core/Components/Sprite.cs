using GameEngineTK.Core.Utils;
using Microsoft.Xna.Framework;

namespace GameEngineTK.Core.Components
{
	class Sprite : SpriteBase
	{
		public Vector2 OriginPosition = new Vector2();

		public override void Init()
		{
			OriginPosition = new Vector2(ParentObject.GetComponent<Transform>().Width, ParentObject.GetComponent<Transform>().Height) / 2;
		}
		public override void Update()
		{
			Width = ParentObject.GetComponent<Transform>().Width;
			Height = ParentObject.GetComponent<Transform>().Height;
		}
	}
}
