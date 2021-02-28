using GameEngineTK.Engine.Prototypes;
using GameEngineTK.Engine.Prototypes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public class Params
	{
		public bool isVisible = true;
		public bool isDraggable = false;
		public bool MouseDown = false;
		public bool onHover = false;
	}
	public class GameObject
	{
		int width;
		int height;
		Texture2D texture;
		TextureHandler vtexture;

		public Params objectParams = new Params();

		/// <summary>
		/// Creates new GameObject instance
		/// </summary>
		public GameObject(Texture2D texture, int width, int height)
		{
			this.Components.Add(new Transform());
			this.Components.Add(new Physics());
			this.Components.Add(new Animation(texture, width, height));


			this.texture = texture;
			this.width = width;
			this.height = height;
		}
		public GameObject(TextureHandler vtexture, int width, int height)
		{
			this.Components.Add(new Transform());
			this.Components.Add(new Physics());
			this.Components.Add(new Animation(vtexture.ToTexture2D(), width, height));

			this.vtexture = vtexture;
			this.width = width;
			this.height = height;
		}
		/// <summary>
		/// Texture origin position
		/// </summary>
		public int Width
		{
			get { return this.width; }
			set {
				this.GetComponent<Animation>().size.X = value;
				this.width = value;
			}
		}
		public int Height
		{
			get { return this.height; }
			set {
				this.GetComponent<Animation>().size.Y = value;
				this.height = value;
			}
		}

		// REWRITE TO TRANSFORM FIELD
		public void RotateTowardPosition(Vector2 pos)
		{
			this.GetComponent<Transform>().Rotation = (float)Math.Atan2(pos.Y - this.GetComponent<Transform>().ScreenPosition().Y, pos.X - this.GetComponent<Transform>().ScreenPosition().X);
		}
		public void RotateTowardObject(GameObject obj)
		{
			this.RotateTowardPosition(obj.GetComponent<Transform>().Position);
		}
		public void RotateClockwise(float angle)
		{
			this.GetComponent<Transform>().Rotation += angle;
		}
		public void RotateCounterClockwise(float angle)
		{
			this.GetComponent<Transform>().Rotation -= angle;
		}
		// REWRITE TO TRANSFORM FIELD

		public SpriteEffects Flip = default;

		public Texture2D Texture {
			get { return this.texture; }
			set {
				this.GetComponent<Animation>().SpriteSheet = value;
				this.texture = value;
			}
		}

		public TextureHandler VTexture {
			get { return this.vtexture; }
			set
			{
				this.GetComponent<Animation>().SpriteSheet = value.ToTexture2D();
				this.vtexture = value;
			}
		}

		private List<IComponentManager> Components = new List<IComponentManager>();

		public bool AddComponent(IComponentManager c)
		{
			if (this.HasComponent(c))
				return false;
			Components.Add(c);
			return true;
		}
		public bool RemoveComponent(IComponentManager c)
		{
			if (!this.HasComponent(c))
				return false;
			Components.Remove(c);
			return true;
		}

		public T GetComponent<T>()
		{
			for (int i = 0; i < this.Components.Count; i++)
				if (this.Components[i] is T) return (T)Convert.ChangeType(this.Components[i], typeof(T));
			throw new ArgumentException($"{this} does not contain {nameof(T)} component");
		}
		[Obsolete("This method deprecated; missing components throw an exception")]
		public bool HasComponent<T>()
		{
			for (int i = 0; i < this.Components.Count; i++)
				if (this.Components[i] is T) return true;
			return false;
		}
		[Obsolete("This method deprecated; missing components throw an exception")]
		public bool HasComponent(IComponentManager obj)
		{
			for (int i = 0; i < this.Components.Count; i++)
				if (this.Components[i].Equals(obj)) return true;
			return false;
		}

		// MAKE FUNCTIONS COMPONENT
		public bool OnObjectClicked()
		{
			var MouseDown = this.objectParams.MouseDown;
			if (Mouse.GetState().LeftButton == ButtonState.Pressed && MouseDown)
				return false;
			else
			{
				if (!MouseDown && this.isHover() && Mouse.GetState().LeftButton == ButtonState.Pressed)
					MouseDown = true;
			}
			return MouseDown;
		} // crap
		public Vector2 OriginPosition = new Vector2();
		
		// REWRITE TO TRANSFORM FIELD
		public bool onObjectDragging()
		{
			if (this.isHover() && Mouse.GetState().LeftButton == ButtonState.Released)
				this.objectParams.onHover = true;
			else if (Mouse.GetState().LeftButton == ButtonState.Released)
				this.objectParams.onHover = false;
			return this.objectParams.onHover && Mouse.GetState().LeftButton == ButtonState.Pressed && this.objectParams.isVisible;
		}
		public bool isHover()
		{
			Vector2 pos = this.GetComponent<Transform>().Position;
			return Mouse.GetState().X > pos.X &&
				Mouse.GetState().X < pos.X + this.width &&
				Mouse.GetState().Y > pos.Y &&
				Mouse.GetState().Y < pos.Y + this.height && this.objectParams.isVisible;
		}

		// MAKE FUNCTIONS COMPONENT

		// TEST THIS OPTION FOR OPTIMISATION ISSUES
		public float Distance(GameObject obj)
		{
			Vector2 opos = obj.GetComponent<Transform>().Position - obj.OriginPosition;
			Vector2 pos = this.GetComponent<Transform>().Position - this.OriginPosition;
			return (float) Math.Sqrt((pos.X - opos.X) * (pos.X - opos.X) + (pos.Y - opos.Y) * (pos.Y - opos.Y));
		}
		public float VDistance(GameObject obj)
		{
			Vector2 opos = obj.GetComponent<Transform>().Position;
			Vector2 pos = this.GetComponent<Transform>().Position;
			return Vector2.Distance(opos, pos);
		}
		// TEST THIS OPTION FOR OPTIMISATION ISSUES

		public void Draw()
		{
			
			var _t = this.GetComponent<Transform>();
			if (_t.ScreenPosition().X > -Width && _t.ScreenPosition().X < 1920 &&
				_t.ScreenPosition().Y > -Height && _t.ScreenPosition().Y < 1080)
			{
				if (Components.Count > 0)
					Components.ForEach(v =>
					{
						v.Update();
						v.Width = width;
						v.Height = height;
						v.Position = this.GetComponent<Transform>().Position;
					});
				if (this.HasComponent<Animation>())
				{
					Animation an = this.GetComponent<Animation>();

					Script.ctx.Draw(an.SpriteSheet, new Rectangle(_t.ScreenPosition().ToPoint(), an.size),
						new Rectangle(an.src, an.FrameSize), Color.White, this.GetComponent<Transform>().Rotation, OriginPosition, Flip, 0);
				}
				else if (objectParams.isVisible)
				{
					Script.ctx.Draw(texture, new Rectangle(_t.ScreenPosition().ToPoint(), new Point(Width, Height)),
						new Rectangle(0, 0, texture.Width, texture.Height), Color.White, this.GetComponent<Transform>().Rotation, OriginPosition, Flip, 0);
				}
				if (this.HasComponent<BoxCollider>())
				{
					BoxCollider bc = this.GetComponent<BoxCollider>();
					bc.velocity = this.GetComponent<Transform>().Velocity;
					bc.Position -= OriginPosition * 2;
					if (BoxCollider.RenderColisionMask)
						Script.ctx.Draw(BoxCollider.ColliderRenderTexture, new Rectangle(World.ScreenPosition(bc.Position).ToPoint(), new Point(bc.Width, bc.Height)), Color.White);
				}
			}
		}

	}
}