using GibsonCore.Abstract;
using Microsoft.Xna.Framework;

namespace GibsonCore.Components
{
	public class Sprite : SpriteBase
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
