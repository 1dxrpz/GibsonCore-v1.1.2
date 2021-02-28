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
		
		//GameObject tiles;
		//GameObject Ground;

		double a = 0;

		//Song song;

		//Texture2D pl;
		NoiseField<float> perlinNoise;
		Texture2D noiseTexture;
		public void GenerateNoiseTexture()
		{
			PerlinNoiseGenerator gen = new PerlinNoiseGenerator();
			gen.Interpolation = InterpolationAlgorithms.CosineInterpolation;

			gen.OctaveCount = 10;
			gen.Persistence = .5f;

			//perlinNoise = gen.GeneratePerlinNoise(512, 512);
			perlinNoise = gen.GeneratePerlinNoise(Window.ClientBounds.Width, Window.ClientBounds.Height);


			LinearGradientColorFilter filter = new LinearGradientColorFilter();
			Texture2DTransformer transformer = new Texture2DTransformer(_graphics.GraphicsDevice);

			//filter.AddColorPoint(0.0f, 0.40f, Color.Blue);
			//filter.AddColorPoint(0.4f, 0.50f, Color.Yellow);
			//filter.AddColorPoint(0.50f, 0.70f, Color.Green);
			//filter.AddColorPoint(0.70f, 0.90f, Color.SaddleBrown);
			//filter.AddColorPoint(0.90f, 1.00f, Color.White);

			filter.StartColor = Color.White;
			filter.EndColor = Color.Black;
			filter.StartPercentage = .4f;

			noiseTexture = transformer.Transform(filter.Filter(perlinNoise));
		}
		protected override void LoadContent()
		{
			this.GenerateNoiseTexture();

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

		bool generated = false;
		protected override void Update(GameTime gameTime)
		{	
			if (Keyboard.GetState().IsKeyDown(Keys.F) && !generated)
			{
				Task.Run(GenerateNoiseTexture);
				generated = true;
			}
			else if (Keyboard.GetState().IsKeyUp(Keys.F))
			{
				generated = false;
			}
			
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
			ctx.Draw(noiseTexture, new Vector2(0, 0), Color.White);
			if (debug.Enabled)
			{
				ctx.DrawString(font, debug.FPS, new Vector2(0, 0), Color.Gold);
				ctx.DrawString(font, DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString(), new Vector2(10, 100), Color.Gold);
				ctx.DrawString(font, "DeltaTime: " + Time.deltaTime, new Vector2(10, 120), Color.Aqua);
				ctx.DrawString(font, " - Debug.Text\n[scope]: message " + debug.text, new Vector2(400, 0), Color.White);
			}
			Program.scripts.ForEach(v => { v.Update(); });
			ctx.End();
			base.Draw(gameTime);

		}
	}
}