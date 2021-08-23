using System;
using System.Collections.Generic;
using GameEngineTK.Core;
using GameEngineTK.Core.Prototypes.Interfaces;
using GameEngineTK.Core.Utils;
using GameEngineTK.Scripts;

namespace GameEngineTK
{
	public static class Program
	{
		static public List<IScriptableObject> scripts = new List<IScriptableObject>();
		[STAThread]
		static void Main()
		{
			using (var game = new GameEntry())
			{
				var config = ConfigReader.Parse("project");

				scripts.Add(new PlayerScript());
				scripts.Add(new CameraScript());
				scripts.Add(new CursorScript());

				game.Window.IsBorderless = true;
				game.Window.AllowAltF4 = true;
				game.IsMouseVisible = false;
				game.Window.AllowUserResizing = true;
				game.Window.Title = config.ContainsKey("title") ? config["title"] : "Unnamed Game";

				game.Run();
				//gameEngineApp.Run();
				
			}
		}
	}
}
