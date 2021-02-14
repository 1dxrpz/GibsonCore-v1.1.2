using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class Animation : Component
	{
		public Texture2D SpriteSheet;
		public int CurrentFrame = 0;
		public int FrameCount = 1;
		public Point FrameSize;

		public int CurrentAnimation = 0;
		public int AnimationCount = 1;
		public int AnimationSpeed;

		public Point size;

		public Animation(Texture2D texture, int width, int height)
		{
			this.SpriteSheet = texture;
			this.size.X = width;
			this.size.Y = height;
			this.FrameSize = new Point(texture.Width, texture.Height);
			
		}
		public Point src;
		public override void Update()
		{
			src.X = CurrentFrame * FrameSize.X;
			src.Y = CurrentAnimation * FrameSize.Y;
		}
	}
}
