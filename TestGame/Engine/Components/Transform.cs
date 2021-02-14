using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class Transform : Component
	{
		public Vector2 Velocity;
		public float Rotation;
		public Vector2 Parallax = new Vector2(1, 1);

		public Vector2 Forward
		{
			get
			{
				return new Vector2(
					(float)(1 * Math.Cos(this.Rotation)),
					(float)(1 * Math.Sin(this.Rotation))
				);
			}
			private set { }
		}
		public Vector2 Backward { get { return -this.Forward; } }
		public Vector2 Top
		{
			get
			{ return new Vector2(
					(float)(1 * Math.Sin(this.Rotation)),
					(float)(-1 * Math.Cos(this.Rotation))
				);
			}
		}
		public Vector2 Bottom
		{
			get { return -this.Top; }
		}
		
		public void Translate(Vector2 pos)
		{
			this.Position += pos;
		}
		public void Translate(float _x, float _y)
		{
			this.Position.X += _x;
			this.Position.Y += _y;
		}
		public void TranslateX(float _x)
		{
			this.Position.X += _x;
		}
		public void TranslateY(float _y)
		{
			this.Position.Y += _y;
		}
		public Vector2 ScreenPosition()
		{
			return ((this.Position) - Camera.Position * this.Parallax);
		}
		public override void Update()
		{
			this.Position += this.Velocity;
			base.Update();
		}
	}
}
