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
	class Renderer : ComponentInstance
	{
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

		public override void Update()
		{
			Transform _t = ParentObject.GetComponent<Transform>();
			
			if (_t.ScreenPosition().X > -_t.Width && _t.ScreenPosition().X < 1920 &&
				_t.ScreenPosition().Y > -_t.Height && _t.ScreenPosition().Y < 1080)
			{
				if (ParentObject.objectParams.isVisible == VisibleState.Visible)
				{
					if (ParentObject.HasComponent<Animation>())
					{
						Animation an = ParentObject.GetComponent<Animation>();

						ScriptManager.ctx.Draw(an.SpriteSheet, new Rectangle(_t.ScreenPosition().ToPoint(), an.size),
							new Rectangle(an.src, an.FrameSize), Color.White, ParentObject.GetComponent<Transform>().Rotation, ParentObject.OriginPosition, ParentObject.Flip, 0);
					}
					else if (ParentObject.HasComponent<Sprite>())
					{
						Sprite _s = ParentObject.GetComponent<Sprite>();
						ScriptManager.ctx.Draw(
							_s.Texture.ToTexture2D(),
							new Rectangle(_t.ScreenPosition().ToPoint(),
							new Point(_s.Width, _s.Height)),
							new Rectangle(0, 0, _s.Texture.Width, _s.Texture.Height),
							Color.White,
							ParentObject.GetComponent<Transform>().Rotation,
							ParentObject.GetComponent<Sprite>().OriginPosition, ParentObject.Flip, 0);
					}
				}

				
				if (ParentObject.HasComponent<BoxCollider>())
				{
					BoxCollider bc = ParentObject.GetComponent<BoxCollider>();
					bc.velocity = ParentObject.GetComponent<Transform>().Velocity;
					bc.Position -= ParentObject.OriginPosition * 2;
					if (BoxCollider.RenderColisionMask)
						ScriptManager.ctx.Draw(BoxCollider.ColliderRenderTexture, new Rectangle(World.ScreenPosition(bc.Position).ToPoint(), new Point(bc.Width, bc.Height)), Color.White);
				}
			}
			
		}
	}
}
