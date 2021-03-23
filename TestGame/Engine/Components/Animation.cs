using GameEngineTK.Engine.Prototypes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class Animation : IComponentManager
	{
		private GameObject parent;

		public Texture2D SpriteSheet;
		public int CurrentFrame = 0;
		public int FrameCount = 1;
		public Point FrameSize;

		public int CurrentAnimation = 0;
		public int AnimationCount = 1;
		public double AnimationSpeed = 1.0;

		public Vector2 Position { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

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

		public Point size;

		public Animation()
		{
			size.X = Width;
			size.Y = Height;
			FrameSize = new Point(32, 32);
		}

		public Animation(Texture2D texture)
		{
			SpriteSheet = texture;
			size.X = Width;
			size.Y = Height;
			FrameSize = new Point(texture.Width, texture.Height);
		}
		public Point src;
		public double counter = 0;
		public void Update()
		{
			counter = counter <= FrameCount - 1 ? counter + AnimationSpeed / 100 * Time.deltaTime : 0;
			if (AnimationSpeed != 0)
				CurrentFrame = (int)Math.Round(counter);
			Width = parent.GetComponent<Transform>().Width;
			Height = parent.GetComponent<Transform>().Height;
			size = new Point(Width, Height);
			src.X = CurrentFrame * FrameSize.X;
			src.Y = CurrentAnimation * FrameSize.Y;
		}
	}
}
