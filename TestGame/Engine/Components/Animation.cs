using GameEngineTK.Engine.Components;
using GameEngineTK.Engine.Prototypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace GameEngineTK.Engine
{
	internal class Animation : SpriteInstance
	{
		public Texture2D SpriteSheet;
		public int CurrentFrame = 0;
		public int FrameCount = 1;
		public Point FrameSize;
		public Vector2 OriginPosition = new Vector2();
		public int CurrentAnimation = 0;
		public int AnimationCount = 1;
		public double AnimationSpeed = 1.0;
		public Point size;
		public Point SourceOffset;

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

		private double _counter = 0;
		public override void Update()
		{
			_counter = _counter <= FrameCount - 1 ? _counter + AnimationSpeed / 100 * Time.deltaTime : 0;
			if (AnimationSpeed != 0)
				CurrentFrame = (int)Math.Round(_counter);
			Width = ParentObject.GetComponent<Transform>().Width;
			Height = ParentObject.GetComponent<Transform>().Height;
			size = new Point(Width, Height);
			SourceOffset.X = CurrentFrame * FrameSize.X;
			SourceOffset.Y = CurrentAnimation * FrameSize.Y;
		}
	}
}
