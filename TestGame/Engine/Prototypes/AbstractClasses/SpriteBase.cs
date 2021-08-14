using Microsoft.Xna.Framework.Graphics;

namespace GameEngineTK.Engine.Components
{
	internal abstract class SpriteBase : ComponentBase
	{
		private int width, height;
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

		public Texture2D Texture;
	}
}
