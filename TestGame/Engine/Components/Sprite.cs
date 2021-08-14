using GameEngineTK.Engine.Utils;
using Microsoft.Xna.Framework;

namespace GameEngineTK.Engine.Components
{
	class Sprite : ComponentInstance
	{
		private int width, height;
		public Vector2 OriginPosition = new Vector2();

		public int Width
		{
			get
			{
				return width;
			}

			set
			{
				width = value;
			}
		}
		public int Height
		{
			get
			{
				return height;
			}

			set
			{
				height = value; 
			}
		}

		public TextureHandler Texture;

		public override void Update()
		{
			width = ParentObject.GetComponent<Transform>().Width;
			height = ParentObject.GetComponent<Transform>().Height;
		}
	}
}
