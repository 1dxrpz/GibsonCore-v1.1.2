using GibsonCore.Abstract;
using GibsonCore.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GibsonCore.Components
{
	public class Animation : SpriteBase
	{
		private int _currentFrame = 0;
		private int _currentAnimation = 0;

		public Texture2D SpriteSheet;
		public int CurrentFrame
		{
			get => _currentFrame;
			set {
				SourceOffset.X = value * FrameSize.X;
				_currentFrame = value;
			}
		}
		public int CurrentAnimation
		{
			get => _currentAnimation;
			set
			{
				SourceOffset.Y = value * FrameSize.Y;
				_currentAnimation = value;
			}
		}

		public int FrameCount = 1;
		public Point FrameSize;
		public Vector2 OriginPosition = new Vector2();
		public int AnimationCount = 1;
		public double AnimationSpeed = 1.0;
		public Point SourceOffset = new Point(0, 0);

		public Animation()
		{
			FrameSize = new Point(32, 32);
		}

		public Animation(Texture2D texture)
		{
			SpriteSheet = texture;
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
		}
	}
}
