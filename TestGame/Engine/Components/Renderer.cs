using System;
using System.Diagnostics;
using GameEngineTK.Engine.Prototypes;
using GameEngineTK.Engine.Prototypes.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngineTK.Engine.Components
{
	internal class Renderer : DrawableBase
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

		Texture2D _texture;
		Transform _t;
		public override void Init()
		{
			_texture = new Texture2D(ScriptManager.graphicsDevice, 1, 1);
			Color[] data = new Color[1] { new Color(100, 100, 100, 100) };
			_texture.SetData(data);
			_t = ParentObject.GetComponent<Transform>();
		}
		public override void Draw()
		{
			if (_t.ScreenPosition().X > -_t.Width && _t.ScreenPosition().X < 1920 &&
				_t.ScreenPosition().Y > -_t.Height && _t.ScreenPosition().Y < 1080)
			{
				if (ParentObject.isVisible == VisibleState.Visible)
				{
					if (ParentObject.HasComponent<Animation>())
					{
						Animation an = ParentObject.GetComponent<Animation>();

						ScriptManager.ctx.Draw(an.SpriteSheet, new Rectangle(_t.ScreenPosition().ToPoint(), an.size),
							new Rectangle(an.SourceOffset, an.FrameSize), Color.White, ParentObject.GetComponent<Transform>().Rotation,
							ParentObject.GetComponent<Animation>().OriginPosition, SpriteEffects.None, 0);
					}
					else if (ParentObject.HasComponent<Sprite>())
					{
						Sprite _s = ParentObject.GetComponent<Sprite>();
						ScriptManager.ctx.Draw(
							_s.Texture,
							new Rectangle(_t.ScreenPosition().ToPoint(),
							new Point(_s.Width, _s.Height)),
							new Rectangle(0, 0, _s.Texture.Width, _s.Texture.Height),
							Color.White,
							ParentObject.GetComponent<Transform>().Rotation,
							ParentObject.GetComponent<Sprite>().OriginPosition, SpriteEffects.None, 0);
					}
				}
			}
			
		}
	}
}
