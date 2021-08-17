using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using GameEngineTK.Engine;
using GameEngineTK.Engine.Rendering;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Content;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Utilities;

namespace GameEngineTK
{
	
	public class Game1 : Game
	{
		[DllImport("kernel32.dll")]
		private static extern bool AllocConsole();

		GameManager GameManager;

		public static ContentManager contentManager;

		private readonly GraphicsDeviceManager _graphics;
		private SpriteBatch ctx;
		private SpriteFont font;
		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			_graphics.SynchronizeWithVerticalRetrace = default;
			IsFixedTimeStep = default;
			//BoxCollider.RenderColisionMask = default;
			TargetElapsedTime = TimeSpan.FromMilliseconds(1000 / 60);
		}
		protected override void Initialize()
		{
			TWorld.World = new tainicom.Aether.Physics2D.Dynamics.World(new tainicom.Aether.Physics2D.Common.Vector2(0, 100f));
			ConvertUnits.SetDisplayUnitToSimUnitRatio(1f);

			contentManager = Content;
			AllocConsole();
			GameManager = new GameManager();
			Window.Position = Point.Zero;
			
			Services.AddService<ProjectSettings>(new ProjectSettings());
			Services.AddService<TDebug>(new TDebug());
			ScriptManager.Services = Services;
			ScriptManager.Content = Content;
			ctx = new SpriteBatch(GraphicsDevice);
			ScriptManager.ctx = ctx;
			ScriptManager.graphicsDevice = GraphicsDevice;
			//MediaPlayer.Play(song);
			var config = ConfigReader.Parse("project");
			if (config.ContainsKey("EnsureDefaults") && ConfigReader.GetBool(config, "EnsureDefaults"))
			{
				ScriptManager.DefaultScene = new Scene("DefaultScene");
				ScriptManager.DefaultLayout = new Layout("DefaultLayout");
				ScriptManager.DefaultLayer = new Layer("DefaultLayer");
				ScriptManager.DefaultScene.Add(ScriptManager.DefaultLayout);
				ScriptManager.DefaultLayout.Add(ScriptManager.DefaultLayer);
			}
			GameManager.Init();
			base.Initialize();
		}
		protected override void LoadContent()
		{
			font = Content.Load<SpriteFont>("font");
		}
		protected override void Update(GameTime gameTime)
		{
			Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			TWorld.World.Step(Time.deltaTime * .001f);
			ProjectSettings settings = Services.GetService<ProjectSettings>();
			_graphics.PreferredBackBufferHeight = settings.WindowHeight;
			_graphics.PreferredBackBufferWidth = settings.WindowWidth;
			_graphics.SynchronizeWithVerticalRetrace = settings.VSync;
			base.IsFixedTimeStep = settings.FixedTS;
			//BoxCollider.RenderColisionMask = settings.ShowColliders;
			TargetElapsedTime = TimeSpan.FromMilliseconds(1000 / settings.MaxFPS);

			_graphics.ApplyChanges();
			GameManager.Update();
			base.Update(gameTime);
		}
		protected override void Draw(GameTime gameTime)
		{
			//ProjectSettings settings = Services.GetService<ProjectSettings>();
			
			TDebug debug = Services.GetService<TDebug>();
			debug.Update(gameTime);
			
			GraphicsDevice.Clear(Color.Black);
			ctx.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			
			ctx.DrawString(font, $"fps: {TDebug.FPS}", new Vector2(10, 10), Color.White);
			//foreach (Scene scene in Theatre.Scenes)
			//{
			//	if (scene.isVisible == VisibleState.Visible)
			//	foreach (Layout layout in scene.Objects)
			//	{
			//		if (layout.isVisible == VisibleState.Visible)
			//		foreach (Layer layer in layout.Objects)
			//		{
			//			if (layer.isVisible == VisibleState.Visible)
			//			foreach (IGameInstances instance in layer.Objects)
			//			{
			//				if (true)
			//				instance.Draw();
			//			}
			//		}
			//	}
			//}
			GameManager.Draw();
			ctx.End();
			base.Draw(gameTime);
		}
	}
}