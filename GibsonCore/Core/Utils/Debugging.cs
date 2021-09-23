using GibsonCore.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Dynamics;

namespace GibsonCore.Utils
{
	public static class GameWorld
	{
		static public Camera CurrentCamera;
		static public Vector2 ScreenPosition(Vector2 pos) => pos - CurrentCamera.Position;
		static public Vector2 WorldPosition(Vector2 pos) => pos + CurrentCamera.Position;
		static public World World;
		static public Vector2 WorldGravity;
	}
	public static class Time
	{
		public static float deltaTime;
	}
	public class ProjectSettings
	{
		public int MaxFPS = 900;
		public int WindowHeight = 1080;
		public int WindowWidth = 1920;
		public bool VSync = false;
		public bool FixedTS = true;
		public bool ShowColliders = true;
	}
	public class Frames
	{
		static public double FPS;
		private double frames = 0;
		private double elapsed = 0;
		private double last = 0;
		private double now = 0;
		public double msgFrequency = .2f;
		public void Update(GameTime gameTime)
		{
			now = gameTime.TotalGameTime.TotalSeconds;
			elapsed = (double)(now - last);
			FPS = Math.Round(frames / elapsed);
			if (elapsed > msgFrequency)
			{
				elapsed = 0;
				frames = 0;
				last = now;
			}
			frames++;
		}
	}
}