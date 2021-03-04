using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using GameEngineTK.Engine;
using GameEngineTK.Scripts;
using PerlinNoise;
using PerlinNoise.Filters;
using PerlinNoise.Transformers;
using System.Threading.Tasks;

namespace GameEngineTK
{
	public class Game1 : Game
	{
		GraphicsDeviceManager _graphics;
		SpriteBatch ctx;
		SpriteFont font;
		//Texture2D cursor_image;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			_graphics.PreferredBackBufferHeight = 1080;
			_graphics.PreferredBackBufferWidth = 1920;
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
			ScriptManager.Services = this.Services;
			ScriptManager.Content = Content;
			ScriptManager.ctx = ctx;
			ScriptManager.graphicsDevice = this.GraphicsDevice;
			//MediaPlayer.Play(song);
			Program.scripts.ForEach(v => { v.Start(); });
		}
		
		//GameObject tiles;
		//GameObject Ground;

		//Song song;

		//Texture2D pl;
		
		protected override void LoadContent()
		{

			BoxCollider.ColliderRenderTexture = Content.Load<Texture2D>("SolidWall");

			ctx = new SpriteBatch(GraphicsDevice);
			font = Content.Load<SpriteFont>("font");
			//cursor_image = Content.Load<Texture2D>("cursor");

			//pl = Content.Load<Texture2D>("player");

			//tiles = new GameObject(Content.Load<Texture2D>("SpriteSheet"), 128, 128);
			//
			//Color[] data = new Color[32 * 32];
			//for (int i = 0; i < data.Length; i++)
			//{
			//	data[i] = Color.White;
			//}
			//Texture2D tex = new Texture2D(_graphics.GraphicsDevice, 32, 32);
			//tex.SetData(data);

			//Player = new GameObject(Content.Load<Texture2D>("player"), 32, 32);
			//Ground = new GameObject(Content.Load<Texture2D>("ground"), 32, 32);

			//song = Content.Load<Song>("Effect");

			//tiles.AddComponent(new Animation(tiles.Texture, 64, 64));
			//Player.AddComponent(new BoxCollider());
			//Ground.AddComponent(new BoxCollider());
		}

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
			base.Update(gameTime);
		}
		protected override void Draw(GameTime gameTime)
		{
			var settings = Services.GetService<ProjectSettings>();
			var debug = Services.GetService<Debug>();
			GraphicsDevice.Clear(Color.Black);
			ctx.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			debug.Update(gameTime);
			if (debug.Enabled)
			{
				var config = ConfigReader.Parse("OVconfigs/project");
				ctx.DrawString(font, "Project name: " + config["name"], new Vector2(10, 10), Color.Gray);
				ctx.DrawString(font, "Author: " + config["author"], new Vector2(10, 25), Color.Gray);
				ctx.DrawString(font, "Version: " + config["version"], new Vector2(10, 40), Color.Gray);
				//ctx.DrawString(font, debug.msg, new Vector2(0, 0), Color.Gold);
				ctx.DrawString(font, " - Debug.Text\n[scope]: message " + debug.text, new Vector2(10, 60), Color.White);
			}
			Program.scripts.ForEach(v => { v.Update(); });
			ctx.End();
			base.Draw(gameTime);

		}
	}
}