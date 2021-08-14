using GameEngineTK.Engine.Components;
using GameEngineTK.Engine.Prototypes.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameEngineTK.Engine
{
	internal class Transform : ComponentBase
	{
		public Vector2 Velocity;
		public float Rotation;
		public Vector2 Parallax = new Vector2(1, 1);
		public Vector2 Position { get; set; }

		private int width = 32, height = 32;
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

		public Vector2 Scale = Vector2.One;

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

		

		public bool OnObjectClicked()
		{
			bool MouseDown = ParentObject.MouseDown;
			if (Mouse.GetState().LeftButton == ButtonState.Pressed && MouseDown)
				return false;
			else
			{
				if (!MouseDown && this.IsHover() && Mouse.GetState().LeftButton == ButtonState.Pressed)
					MouseDown = true;
			}
			return MouseDown;
		}

		public bool OnObjectDragging()
		{
			if (this.IsHover() && Mouse.GetState().LeftButton == ButtonState.Released)
				ParentObject.onHover = true;
			else if (Mouse.GetState().LeftButton == ButtonState.Released)
				ParentObject.onHover = false;
			return ParentObject.onHover && Mouse.GetState().LeftButton == ButtonState.Pressed && ParentObject.isVisible == VisibleState.Visible;
		}
		public bool IsHover()
		{
			Transform _t = ParentObject.GetComponent<Transform>();
			Vector2 pos = _t.Position;
			return Mouse.GetState().X > pos.X &&
				Mouse.GetState().X < pos.X + _t.Width &&
				Mouse.GetState().Y > pos.Y &&
				Mouse.GetState().Y < pos.Y + _t.Width && ParentObject.isVisible == VisibleState.Visible;
		}
		public Vector2 ScreenPosition()
		{
			return ((Position) - Camera.Position * Parallax);
		}

		Transform _parentTransform;
		public void RotateTowardPosition(Vector2 pos)
		{
			ParentObject.GetComponent<Transform>().Rotation = (float)Math.Atan2(
				pos.Y - _parentTransform.ScreenPosition().Y,
				pos.X - _parentTransform.ScreenPosition().X);
		}
		public void RotateTowardObject(GameObject obj)
		{
			RotateTowardPosition(obj.GetComponent<Transform>().Position);
		}
		public void RotateClockwise(float angle)
		{
			ParentObject.GetComponent<Transform>().Rotation += angle;
		}
		public void RotateCounterClockwise(float angle)
		{
			ParentObject.GetComponent<Transform>().Rotation -= angle;
		}
		public override void Init()
		{
			_parentTransform = ParentObject.GetComponent<Transform>();
		}
		public override void Update()
		{
			//Position += Velocity;
		}
	}
}
