using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using GibsonCore.Core;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Content;

using Penumbra;
using Microsoft.Xna.Framework.Input;
using GibsonCore.Abstract;
using GibsonCore.Utils;
using System.Diagnostics;
using GibsonCore.Interfaces;

namespace GibsonCore.Core
{
	public class GameEntry : Game
	{
		public void Execute<T>() where T : DxScript, new()
		{
			T _script = new T();
		}
		[DllImport("kernel32.dll")]
		private static extern bool AllocConsole();

		GameManager GameManager;
		SceneManager SceneManager;

		RenderTarget2D _renderTarget;
		public static ContentManager contentManager;

		ProjectSettings settings;
		private readonly GraphicsDeviceManager _graphics;
		private SpriteBatch ctx;
		private SpriteFont font;

		PenumbraComponent penumbra;
		Frames fps;

		Lighting lighting;
		public static Scene scene;

		public GameEntry()
		{
			ScriptManager.Services = Services;
			SceneManager = new SceneManager();
			Services.AddService(SceneManager);
			

			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			_graphics.SynchronizeWithVerticalRetrace = default;
			IsFixedTimeStep = default;
			TargetElapsedTime = TimeSpan.FromMilliseconds(1000 / 60);
		}
		protected override void Initialize()
		{
			
			scene = new Scene();
			SceneManager.Add(scene);

			fps = new Frames();
			GameWorld.World = new tainicom.Aether.Physics2D.Dynamics.World(new tainicom.Aether.Physics2D.Common.Vector2(0, 100f));

			Camera camera = new Camera();
			GameWorld.CurrentCamera = camera;

			contentManager = Content;
			AllocConsole();
			GameManager = new GameManager();
			Window.Position = Point.Zero;

			Services.AddService<ProjectSettings>(new ProjectSettings());
			
			ScriptManager.Content = Content;
			ctx = new SpriteBatch(GraphicsDevice);
			ScriptManager.ctx = ctx;
			ScriptManager.graphicsDevice = GraphicsDevice;

			
			penumbra = new PenumbraComponent(this);
			Services.AddService<PenumbraComponent>(penumbra);
			Components.Add(penumbra);
			lighting = new Lighting();
			Services.AddService<Lighting>(lighting);

			penumbra.Enabled = false;
			penumbra.Visible = false;

			var config = ConfigReader.Parse("project");
			settings = Services.GetService<ProjectSettings>();
			
			_graphics.PreferredBackBufferHeight = settings.WindowHeight;
			_graphics.PreferredBackBufferWidth = settings.WindowWidth;
			_graphics.SynchronizeWithVerticalRetrace = settings.VSync;
			_graphics.ApplyChanges();

			GameManager.Init();

			base.IsFixedTimeStep = settings.FixedTS;
			base.Initialize();
		}

		protected override void LoadContent()
		{
			font = Content.Load<SpriteFont>("font");
			_renderTarget = new RenderTarget2D(_graphics.GraphicsDevice, 1920, 1080);
		}

		private Vector2 _scaleDelta = Vector2.Zero;

		protected override void Update(GameTime gameTime)
		{
			Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			GameWorld.World.Step(Time.deltaTime * .001f);
			
			TargetElapsedTime = TimeSpan.FromMilliseconds(1000 / settings.MaxFPS);
			GameManager.Update();
			
			base.Update(gameTime);
		}
		protected override void EndRun()
		{
			base.EndRun();
		}
		protected override void Dispose(bool disposing)
		{
			Content.Dispose();
			base.Dispose(disposing);
		}
		protected override void UnloadContent()
		{
			//GameManager.UnloadEvent();
			Content.Unload();
			base.UnloadContent();
		}

		protected override void Draw(GameTime gameTime)
		{
			//ProjectSettings settings = Services.GetService<ProjectSettings>();
			penumbra.BeginDraw();
			fps.Update(gameTime);

			//GraphicsDevice.SetRenderTarget(_renderTarget);
			
			GraphicsDevice.Clear(Color.SkyBlue);

			//ctx.Begin(SpriteSortMode.Texture, BlendState.NonPremultiplied, SamplerState.PointClamp);
			//GameManager.DrawFX();
			//ctx.End();

			ctx.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, SamplerState.PointClamp);
			ctx.DrawString(font, $"fps: {Frames.FPS}", new Vector2(10, 10), Color.White);
			GameManager.DrawDefault();
			ctx.End();

			base.Draw(gameTime);
		}
	}
}
