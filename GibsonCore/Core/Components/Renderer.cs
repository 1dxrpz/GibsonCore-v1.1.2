using GibsonCore.Abstract;
using GibsonCore.Enums;
using GibsonCore.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GibsonCore.Components
{
	public class Renderer : DefaultRendererBase
	{
		private int _width, _height;
		private float _opacity = 1f;

		public int LayerDepth = 0;
		public float Opacity
		{
			get => _opacity;
			set
			{
				if (value < 0)
					throw new Exception($"[{ParentObject.Name}] Opacity out of bounds (0f; 1f)");
				_opacity = value;
			}
		}
		public int Width
		{
			get
			{
				return _width;
			}

			set
			{
				_width = value;
			}
		}
		public int Height
		{
			get
			{
				return _height;
			}

			set
			{
				_height = value;
			}
		}

		Texture2D _texture;
		Transform _t;
		Animation _an;
		Sprite _s;
		public override void Init()
		{
			_texture = new Texture2D(ScriptManager.graphicsDevice, 1, 1);
			Color[] data = new Color[1] { new Color(100, 100, 100, 100) };
			_texture.SetData(data);
			_t = ParentObject.GetComponent<Transform>();
			
		}

		bool _upd = false;

		public override void Unload()
		{
			_texture.Dispose();
		}
		public override void Draw()
		{
			if (!_upd)
			{
				if (ParentObject.HasComponent<Animation>())
				{
					_an = ParentObject.GetComponent<Animation>();
					_upd = true;
				}
				if (ParentObject.HasComponent<Sprite>())
				{
					_s = ParentObject.GetComponent<Sprite>();
					_upd = true;
				}
			}
			if (_t.ScreenPosition().X > -_t.Width && _t.ScreenPosition().X < 1920 &&
				_t.ScreenPosition().Y > -_t.Height && _t.ScreenPosition().Y < 1080)
			{
				if (ParentObject.isVisible == VisibleState.Visible)
				{
					if (ParentObject.HasComponent<Animation>())
					{
						//GameEntry.effect.CurrentTechnique.Passes[0].Apply();
						ScriptManager.ctx.Draw(
							_an.SpriteSheet,
							new Rectangle((_t.ScreenPosition()).ToPoint(), new Point(_an.Width, _an.Height)),
							new Rectangle(_an.SourceOffset, _an.FrameSize),
							new Color(Color.White, _opacity), _t.Rotation,
							_an.FrameSize.ToVector2() / 2, SpriteEffects.None, LayerDepth);
					}
					else if (ParentObject.HasComponent<Sprite>())
					{
						ScriptManager.ctx.Draw(
							_s.Texture,
							new Rectangle((_t.ScreenPosition()).ToPoint(),
							new Point(_s.Width, _s.Height)),
							new Rectangle(0, 0, _s.Texture.Width, _s.Texture.Height),
							Color.White,
							_t.Rotation,
							new Vector2(_s.Texture.Width, _s.Texture.Height) / 2, SpriteEffects.None, LayerDepth);
					}
				}
			}
			
		}
	}
}
