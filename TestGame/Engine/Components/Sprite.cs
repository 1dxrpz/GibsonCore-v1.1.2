using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;
using GameEngineTK.Engine.Utils;
using Microsoft.Xna.Framework;

namespace GameEngineTK.Engine.Components
{
	class Sprite : IComponentManager
	{
		private int width, height;
		private Vector2 position;
		private GameObject parent;
		private TextureHandler texture;

		public GameObject Parent
		{
			get
			{
				return parent;
			}

			set
			{
				parent = value;
			}
		}
		public Vector2 Position
		{
			get
			{
				return position;
			}

			set
			{
				position = position;
			}
		}
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
		public void Update()
		{
			width = parent.GetComponent<Transform>().Width;
			height = parent.GetComponent<Transform>().Height;
		}
	}
}
