using GameEngineTK.Engine.Prototypes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GameEngineTK.Engine
{
	public class BoxCollider : IComponentManager
	{
		private GameObject parent;
		static public Texture2D ColliderRenderTexture;
		static public bool RenderColisionMask = false;

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

		public Vector2 velocity = new Vector2();
		public bool OverObject(GameObject obj)
		{
			if (!obj.HasComponent<BoxCollider>()) return false;
			else
			{
				var ot = obj.GetComponent<Transform>();
				var offsetRect = new Rectangle((this.Position).ToPoint(), new Point(this.Width, this.Height));
				var objectRect = new Rectangle(ot.Position.ToPoint(), new Point(ot.Width, ot.Height));
				return !Rectangle.Intersect(offsetRect, objectRect).IsEmpty;
			}
		}
		
		public bool IsTouchingLeft(GameObject obj)
		{
			BoxCollider _obj = obj.GetComponent<BoxCollider>();
			return this.Position.X + this.Width + this.velocity.X > _obj.Position.X &&
				this.Position.X < _obj.Position.X &&
				this.Position.Y + this.Height > _obj.Position.Y + 5 &&
				this.Position.Y < _obj.Position.Y + _obj.Height - 5;
		}
		public bool IsTouchingRight(GameObject obj)
		{
			BoxCollider _obj = obj.GetComponent<BoxCollider>();
			return this.Position.X + this.velocity.X < _obj.Position.X + _obj.Width &&
				this.Position.X + this.Width > _obj.Position.X + _obj.Width &&
				this.Position.Y + this.Height > _obj.Position.Y + 5 &&
				this.Position.Y < _obj.Position.Y + _obj.Height - 5;
		}
		public bool IsTouchingTop(GameObject obj)
		{
			BoxCollider _obj = obj.GetComponent<BoxCollider>();
			return this.Position.Y + this.Height + this.velocity.Y > _obj.Position.Y &&
				this.Position.Y < _obj.Position.Y &&
				this.Position.X + this.Width > _obj.Position.X + 5 &&
				this.Position.X < _obj.Position.X + _obj.Width - 5;
		}
		public bool IsTouchingBottom(GameObject obj)
		{
			BoxCollider _obj = obj.GetComponent<BoxCollider>();
			return this.Position.Y + this.velocity.Y < _obj.Position.Y + _obj.Height &&
				this.Position.Y + this.Height > _obj.Position.Y + _obj.Height &&
				this.Position.X + this.Width > _obj.Position.X + 5 &&
				this.Position.X < _obj.Position.X + _obj.Width - 5;
		}
		
		public void Update()
		{
			
		}

		public void init()
		{
			
		}
	}
}
