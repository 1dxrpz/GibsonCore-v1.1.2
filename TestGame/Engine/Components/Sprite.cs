using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;
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

		Transform transform;
		public Sprite()
		{
			transform = ParentObject.GetComponent<Transform>();
		}

		public override void Update()
		{
			width = transform.Width;
			height = transform.Height;
		}
	}
}
