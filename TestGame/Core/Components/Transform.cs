using GameEngineTK.Core.Components;
using GameEngineTK.Core.Prototypes.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameEngineTK.Core
{
	internal class Transform : ComponentBase
	{
		public Action<Vector2> PositionChanged;

		public Vector2 Velocity;
		public float Rotation;
		public Vector2 Parallax = new Vector2(1, 1);
		public Vector2 Position
		{
			get => _position;
			set
			{
				_position = value;
			}
		}
		public void SetPosition(Vector2 pos)
		{
			_position = pos;
			PositionChanged?.Invoke(pos);
		}

		private Vector2 _position;
		private int width, height;
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
					(float)(Math.Cos(Rotation)),
					(float)(Math.Sin(Rotation))
				);
			}
			private set { }
		}
		public Vector2 Backward { get { return -Forward; } }
		public Vector2 Top
		{
			get
			{ return new Vector2(
					(float)(Math.Sin(Rotation)),
					(float)(-Math.Cos(Rotation))
				);
			}
		}
		public Vector2 Bottom
		{
			get { return -Top; }
		}

		public void Translate(Vector2 pos)
		{
			_position += pos;
		}
		public void Translate(float _x, float _y)
		{
			_position += new Vector2(_x, _y);
		}
		public void TranslateX(float _x)
		{
			_position += new Vector2(_x, 0);
		}
		public void TranslateY(float _y)
		{
			_position += new Vector2(0, _y);
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
			Vector2 pos = _t._position;
			return Mouse.GetState().X > pos.X &&
				Mouse.GetState().X < pos.X + _t.Width &&
				Mouse.GetState().Y > pos.Y &&
				Mouse.GetState().Y < pos.Y + _t.Width && ParentObject.isVisible == VisibleState.Visible;
		}
		public Vector2 ScreenPosition()
		{
			return ((_position) - GameWorld.CurrentCamera.Position * Parallax);
		}

		private Transform _parentTransform;
		public void RotateTowardPosition(Vector2 pos)
		{
			ParentObject.GetComponent<Transform>().Rotation = (float)Math.Atan2(
				pos.Y - _parentTransform.ScreenPosition().Y,
				pos.X - _parentTransform.ScreenPosition().X);
		}
		public void RotateTowardObject(GameObject obj)
		{
			RotateTowardPosition(obj.GetComponent<Transform>()._position);
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
			transform = this;
		}
		public override void Update()
		{
			_position += Velocity;
		}
	}
}
