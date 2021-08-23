using Microsoft.Xna.Framework.Graphics;

namespace GameEngineTK.Core.Components
{
	internal abstract class SpriteBase : ComponentBase
	{
		private int width = 32, height = 32;
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
