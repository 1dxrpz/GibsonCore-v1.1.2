using GameEngineTK.Engine.Prototypes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class BufferedAnimation
	{
		public int CurrentFrame = 0;
		public int FrameCount = 1;
		public int FrameDepth = 1;
		public double AnimationSpeed = 1.0;
		public Texture2D SpriteSheet;
		public Point FrameSize;
		public BufferedAnimation() { }
		public BufferedAnimation(Texture2D spritesheet, int framecount, Point framesize, double speed)
		{
			SpriteSheet = spritesheet;
			FrameCount = framecount;
			FrameSize = framesize;
			AnimationSpeed = speed;
		}
		public BufferedAnimation(Texture2D spritesheet, int framecount, Point framesize, int depth, double speed)
		{
			SpriteSheet = spritesheet;
			FrameCount = framecount;
			FrameSize = framesize;
			AnimationSpeed = speed;
			FrameDepth = depth;
		}
	}
	public class Animation
	{
		public int CurrentFrame = 0;
		public int CurrentAnimation = 0;
		public int FrameCount = 1;
		public int AnimationCount = 1;
		public Point FrameSize;
		public double AnimationSpeed = 1.0;
		public Texture2D SpriteSheet;
		public Animation() { }
		public Animation(Texture2D spritesheet, int framecount, Point framesize, double speed)
		{
			SpriteSheet = spritesheet;
			FrameCount = framecount;
			FrameSize = framesize;
			AnimationSpeed = speed;
		}
		public Animation(Texture2D spritesheet, int framecount, Point framesize, int animationcount, double speed)
		{
			SpriteSheet = spritesheet;
			FrameCount = framecount;
			FrameSize = framesize;
			AnimationCount = animationcount;
			AnimationSpeed = speed;
		}
	}
	public class BufferedAnimatedSprite : IComponentManager
	{
		private GameObject parent;
		public BufferedAnimation animation = new BufferedAnimation();
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

		public Vector2 Position { get; set; }

		public int Width { get; set; }

		public int Height { get; set; }

		public void init()
		{
			
		}

		public double counter = 0;
		public Point size;
		public Point src;
		public void Update()
		{
			counter = counter <= animation.FrameCount - 1 ? counter + animation.AnimationSpeed / 100 * Time.deltaTime : 0;

			if (animation.AnimationSpeed != 0)
				animation.CurrentFrame = (int)Math.Round(counter);
			Width = parent.GetComponent<Transform>().Width;
			Height = parent.GetComponent<Transform>().Height;
			size = new Point(Width, Height);
			src.X = (animation.CurrentFrame % animation.FrameDepth) * animation.FrameSize.X;
			src.Y = (animation.CurrentFrame / animation.FrameDepth) * animation.FrameSize.Y;
		}
	}
	public class AnimatedSprite : IComponentManager
	{
		private GameObject parent;

		public Animation animation = new Animation();

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

		public AnimatedSprite()
		{
			size.X = Width;
			size.Y = Height;
			animation.FrameSize = new Point(32, 32);
		}

		public AnimatedSprite(Texture2D texture)
		{
			animation.SpriteSheet = texture;
			size.X = Width;
			size.Y = Height;
			animation.FrameSize = new Point(texture.Width, texture.Height);
		}
		
		public double counter = 0;
		public Point src;
		public void Update()
		{
			counter = counter <= animation.FrameCount - 1? counter + animation.AnimationSpeed / 100 * Time.deltaTime : 0;
			
			if (animation.AnimationSpeed != 0)
				animation.CurrentFrame = (int)Math.Round(counter);
			Width = parent.GetComponent<Transform>().Width;
			Height = parent.GetComponent<Transform>().Height;
			size = new Point(Width, Height);
			src.X = animation.CurrentFrame * animation.FrameSize.X;
			src.Y = animation.CurrentAnimation * animation.FrameSize.Y;
		}

		public void init()
		{
			
		}
	}
}
