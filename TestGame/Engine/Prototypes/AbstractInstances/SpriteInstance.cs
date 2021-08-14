using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Utils;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngineTK.Engine.Components
{
	internal abstract class SpriteInstance : ComponentInstance
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
