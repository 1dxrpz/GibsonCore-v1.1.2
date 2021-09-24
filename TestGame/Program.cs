using System;
using System.Collections.Generic;
using GameEngineTK.Scripts;

using GibsonCore.Core;
using GibsonCore.Interfaces;
using GibsonCore.Utils;

namespace GameEngineTK
{
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			using (var game = new GameEntry())
			{
				game.Execute<PlayerScript>();
				game.Execute<CameraScript>();
				game.Execute<CursorScript>();
				
				game.Window.IsBorderless = true;
				game.Window.AllowAltF4 = true;
				game.IsMouseVisible = true;
				game.Window.AllowUserResizing = true;

				game.Run();
				//gameEngineApp.Run();
				
			}
		}
	}
}
