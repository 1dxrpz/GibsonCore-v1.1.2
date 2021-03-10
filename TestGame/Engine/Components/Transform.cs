using GameEngineTK.Engine.Prototypes.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class Transform : IComponentManager
	{
		private IGameInstances parent;
		public Vector2 Velocity;
		public float Rotation;
		public Vector2 Parallax = new Vector2(1, 1);

		public Vector2 Position { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public Vector2 Forward
		{
			get
			{
				return new Vector2(
					(float)(1 * Math.Cos(Rotation)),
					(float)(1 * Math.Sin(Rotation))
				);
			}
			private set { }
		}
		public Vector2 Backward { get { return -Forward; } }
		public Vector2 Top
		{
			get
			{ return new Vector2(
					(float)(1 * Math.Sin(Rotation)),
					(float)(-1 * Math.Cos(Rotation))
				);
			}
		}
		public Vector2 Bottom
		{
			get { return -Top; }
		}

		public IGameInstances Parent
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

		public void Translate(Vector2 pos)
		{
			Position += pos;
		}
		public void Translate(float _x, float _y)
		{
			Position += new Vector2(_x, _y);
		}
		public void TranslateX(float _x)
		{
			Position += new Vector2(_x, 0);
		}
		public void TranslateY(float _y)
		{
			Position += new Vector2(0, _y);
		}
		public Vector2 ScreenPosition()
		{
			return ((Position) - Camera.Position * Parallax);
		}
		public void Update()
		{
			Position += Velocity;
		}
	}
}
