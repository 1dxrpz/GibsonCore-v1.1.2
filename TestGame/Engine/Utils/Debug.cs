using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine
{
	public static class World
	{
		static public Vector2 ScreenPosition(Vector2 pos)
		{
			return pos - Camera.Position;
		}
		static public Vector2 WorldPosition(Vector2 pos)
		{
			return pos + Camera.Position;
		}    
	}
	public static class Time
	{
		public static float deltaTime;
	}
	public class ProjectSettings
	{
		public int MaxFPS = 80;
		public int WindowHeight = 1080;
		public int WindowWidth = 1920;
		public bool VSync = false;
		public bool FixedTS = false;
		public bool ShowColliders = true;
	}
	public class Debug
	{
		public bool Enabled = true;
		public string FPS;
		private double frames = 0;
		private double updates = 0;
		private double elapsed = 0;
		private double last = 0;
		private double now = 0;
		public double msgFrequency = .2f;
		public string msg = "";
		public void Update(GameTime gameTime)
		{
			now = gameTime.TotalGameTime.TotalSeconds;
			elapsed = (double)(now - last);
			if (elapsed > msgFrequency)
			{
				msg = " Fps: " + (frames / elapsed).ToString()
					+ "\n Elapsed time: " + elapsed.ToString()
					+ "\n Updates: " + updates.ToString()
					+ "\n Frames: " + frames.ToString()
					+ "\n Update frequency: " + msgFrequency.ToString();
				//Console.WriteLine(msg);
				elapsed = 0;
				frames = 0;
				updates = 0;
				last = now;
			}
			updates++;
			frames++;
			FPS = msg;
		}
		public string text = "";
	}
}