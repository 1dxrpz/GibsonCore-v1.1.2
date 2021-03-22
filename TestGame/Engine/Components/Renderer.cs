using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Enums;
using GameEngineTK.Engine.Prototypes.Interfaces;
using GameEngineTK.Engine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngineTK.Engine.Components
{
	class Renderer : IComponentManager
	{
		private int width, height;
		private Vector2 position;
		private GameObject parent;
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
		public Vector2 Position
		{
			get
			{
				return position;
			}

			set
			{
				position = position;
			}
		}
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

		public void Update()
		{
			
			Transform _t = Parent.GetComponent<Transform>();
			
			if (_t.ScreenPosition().X > -_t.Width && _t.ScreenPosition().X < 1920 &&
				_t.ScreenPosition().Y > -_t.Height && _t.ScreenPosition().Y < 1080)
			{
				if (Parent.objectParams.isVisible == VisibleState.Visible)
				{
					if (Parent.HasComponent<Animation>())
					{
						Animation an = Parent.GetComponent<Animation>();

						ScriptManager.ctx.Draw(an.SpriteSheet, new Rectangle(_t.ScreenPosition().ToPoint(), an.size),
							new Rectangle(an.src, an.FrameSize), Color.White, Parent.GetComponent<Transform>().Rotation, Parent.OriginPosition, Parent.Flip, 0);
					}
					else if (Parent.HasComponent<Sprite>())
					{
						Sprite _s = Parent.GetComponent<Sprite>();
						ScriptManager.ctx.Draw(
							_s.Texture.ToTexture2D(),
							new Rectangle(_t.ScreenPosition().ToPoint(),
							new Point(_s.Width, _s.Height)),
							new Rectangle(0, 0, _s.Texture.Width, _s.Texture.Height),
							Color.White,
							Parent.GetComponent<Transform>().Rotation,
							Parent.OriginPosition, Parent.Flip, 0);
					}
				}

				
				if (Parent.HasComponent<BoxCollider>())
				{
					BoxCollider bc = Parent.GetComponent<BoxCollider>();
					bc.velocity = Parent.GetComponent<Transform>().Velocity;
					bc.Position -= Parent.OriginPosition * 2;
					if (BoxCollider.RenderColisionMask)
						ScriptManager.ctx.Draw(BoxCollider.ColliderRenderTexture, new Rectangle(World.ScreenPosition(bc.Position).ToPoint(), new Point(bc.Width, bc.Height)), Color.White);
				}
			}
			
		}
	}
}
