using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using GameEngineTK.Engine;
using GameEngineTK.Scripts;

namespace GameEngineTK
{
	public class Game1 : Game
	{
		GraphicsDeviceManager _graphics;
		SpriteBatch ctx;
		SpriteFont font;
		Texture2D cursor_image;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			_graphics.PreferredBackBufferHeight = 1080;
			//_graphics.PreferredBackBufferWidth = 1920;
			_graphics.SynchronizeWithVerticalRetrace = default;
			base.IsFixedTimeStep = default;
			BoxCollider.RenderColisionMask = default;
			this.TargetElapsedTime = TimeSpan.FromMilliseconds(1000 / 60);

		}

		protected override void Initialize()
		{
			Window.Position = Point.Zero;
			base.Initialize();
			Services.AddService<ProjectSettings>(new ProjectSettings());
			Services.AddService<Debug>(new Debug());
			Script.Services = this.Services;
			Script.Content = Content;
			Script.ctx = ctx;
			Script.graphicsDevice = this.GraphicsDevice;
			//MediaPlayer.Play(song);
			Program.scripts.ForEach(v => { v.Start(); });
		}
		
		GameObject tiles;
		//GameObject Cursor;
		GameObject Player;
		GameObject Ground;

		double a = 0;

		Song song;

		Texture2D pl;
		protected override void LoadContent()
		{
			
			
			BoxCollider.ColliderRenderTexture = Content.Load<Texture2D>("SolidWall");

			ctx = new SpriteBatch(GraphicsDevice);
			font = Content.Load<SpriteFont>("font");
			cursor_image = Content.Load<Texture2D>("cursor");

			pl = Content.Load<Texture2D>("player");

			tiles = new GameObject(Content.Load<Texture2D>("SpriteSheet"), 128, 128);

			Color[] data = new Color[32 * 32];
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = Color.White;
			}
			Texture2D tex = new Texture2D(_graphics.GraphicsDevice, 32, 32);
			tex.SetData(data);

			Player = new GameObject(Content.Load<Texture2D>("player"), 32, 32);
			Ground = new GameObject(Content.Load<Texture2D>("ground"), 32, 32);

			song = Content.Load<Song>("Effect");

			tiles.AddComponent(new Animation(tiles.Texture, 64, 64));
			Player.AddComponent(new BoxCollider());
			Ground.AddComponent(new BoxCollider());
		}

		int b = 0;

		ButtonState click = Mouse.GetState().LeftButton;

		protected override void Update(GameTime gameTime)
		{
			var settings = Services.GetService<ProjectSettings>();
			var debug = Services.GetService<Debug>();
			
			_graphics.PreferredBackBufferHeight = settings.WindowHeight;
			_graphics.PreferredBackBufferWidth = settings.WindowWidth;
			_graphics.SynchronizeWithVerticalRetrace = settings.VSync;
			base.IsFixedTimeStep = settings.FixedTS;
			BoxCollider.RenderColisionMask = settings.ShowColliders;
			this.TargetElapsedTime = TimeSpan.FromMilliseconds(1000 / settings.MaxFPS);
			_graphics.ApplyChanges();
			Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			/*
			a += .02 * Time.deltaTime / 10;

			if (Mouse.GetState().LeftButton != click)
			{
				if (Mouse.GetState().LeftButton != ButtonState.Released)
					b++;
				click = Mouse.GetState().LeftButton;
			}
			ctx.DrawString(font, "" + b, new Vector2(10, 340), Color.Aqua);

			Animation til = tiles.GetComponent<Animation>();

			til.CurrentFrame = (int)a % 6;
			til.CurrentAnimation = 0;
			til.AnimationCount = 2;
			til.FrameCount = 6;
			til.FrameSize = new Point(32, 32);

			tiles.objectParams.isDraggable = true;

			Ground.GetComponent<Transform>().Position = new Vector2(0, 200);

			Ground.Width = 128;
			Ground.Height = 128;

			var bc = Player.GetComponent<BoxCollider>();

			if ((pt.Velocity.X > 0 && bc.IsTouchingLeft(Ground)) || (pt.Velocity.X < 0 && bc.IsTouchingRight(Ground))) pt.Velocity.X = 0;
			if ((pt.Velocity.Y > 0 && bc.IsTouchingTop(Ground)) || (pt.Velocity.Y < 0 && bc.IsTouchingBottom(Ground))) pt.Velocity.Y = 0;

			
			//pt.Translate(pt.Forward * Time.deltaTime * .25f);
			//Player.RotateClockwise(.01f * Time.deltaTime);

			Player.OriginPosition = new Vector2(Player.Width / 4, Player.Height / 4);
			Ground.OriginPosition = new Vector2(0, 0);

			tiles.Draw(ctx);
			Ground.Draw(ctx);
			*/
			GraphicsDevice.Clear(Color.Black);
			ctx.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			debug.Update(gameTime);
			if (debug.Enabled)
			{
				ctx.DrawString(font, debug.FPS, new Vector2(0, 0), Color.Gold);
				ctx.DrawString(font, DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString(), new Vector2(10, 100), Color.Gold);
				ctx.DrawString(font, "DeltaTime: " + Time.deltaTime, new Vector2(10, 120), Color.Aqua);
				ctx.DrawString(font, "[Debug.Text]: " + debug.text, new Vector2(10, 140), Color.White);
			}
			Program.scripts.ForEach(v => { v.Update(); });
			ctx.End();
			base.Update(gameTime);
		}
		protected override void Draw(GameTime gameTime)
		{

			base.Draw(gameTime);

		}
	}
}