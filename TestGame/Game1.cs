using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using GameEngineTK.Engine;
using GameEngineTK.Engine.Rendering;
using System.Runtime.InteropServices;

namespace GameEngineTK
{
	
	public class Game1 : Game
	{
		[DllImport("kernel32.dll")]
		private static extern bool AllocConsole();

		GameManager GameManager;

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
			AllocConsole();
			GameManager = new GameManager();
			Window.Position = Point.Zero;
			base.Initialize();
			Services.AddService<ProjectSettings>(new ProjectSettings());
			Services.AddService<TDebug>(new TDebug());
			ScriptManager.Services = Services;
			ScriptManager.Content = Content;
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
			//font = Content.Load<SpriteFont>("Arial");
			GameManager.Init();
		}
		protected override void LoadContent()
		{
			//BoxCollider.ColliderRenderTexture = Content.Load<Texture2D>("SolidWall");

			ctx = new SpriteBatch(GraphicsDevice);
			font = Content.Load<SpriteFont>("font");
		}
		protected override void Update(GameTime gameTime)
		{
			ProjectSettings settings = Services.GetService<ProjectSettings>();
			_graphics.PreferredBackBufferHeight = settings.WindowHeight;
			_graphics.PreferredBackBufferWidth = settings.WindowWidth;
			_graphics.SynchronizeWithVerticalRetrace = settings.VSync;
			base.IsFixedTimeStep = settings.FixedTS;
			//BoxCollider.RenderColisionMask = settings.ShowColliders;
			TargetElapsedTime = TimeSpan.FromMilliseconds(1000 / settings.MaxFPS);

			GameManager.Update();

			_graphics.ApplyChanges();
			base.Update(gameTime);
		}
		protected override void Draw(GameTime gameTime)
		{
			//ProjectSettings settings = Services.GetService<ProjectSettings>();
			
			TDebug debug = Services.GetService<TDebug>();
			debug.Update(gameTime);
			//Console.WriteLine(debug.FPS);

			GraphicsDevice.Clear(Color.Black);
			ctx.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp);
			Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

			//if (false)//debug.Enabled)
			//{
			//	var config = ConfigReader.Parse("project");
			//	ctx.DrawString(font, "Project name: " + (config.ContainsKey("name") ? config["name"] : "Unnamed Project"), new Vector2(10, 10), Color.Gray);
			//	ctx.DrawString(font, "Author: " + (config.ContainsKey("author") ? config["author"] : "Unknown author"), new Vector2(10, 25), Color.Gray);
			//	ctx.DrawString(font, "Version: " + (config.ContainsKey("version") ? "v.1.00" : config["version"]), new Vector2(10, 40), Color.Gray);
			//	ctx.DrawString(font, " - Debug.Text\n[scope]: message " + debug.text, new Vector2(10, 60), Color.White);
			//}

			GameManager.Draw();
			ctx.DrawString(font, TDebug.FPS.ToString(), new Vector2(10, 10), Color.White);
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
			ctx.End();
			base.Draw(gameTime);

		}
	}
}