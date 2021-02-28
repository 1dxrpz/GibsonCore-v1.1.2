using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Scripts
{
	class CursorScript : IScriptManager
	{
		public static GameObject Cursor;
		ButtonState click = Mouse.GetState().LeftButton;
		int b = 0;
		public void Start()
		{
			Script.Services.GetService<ProjectSettings>().ShowColliders = false;
			Cursor = new GameObject(Script.Content.Load<Texture2D>("CursorSpriteSheet"), 32, 42);
			Cursor.AddComponent(new Animation(Cursor.Texture, 32, 42));
			Cursor.GetComponent<Transform>().Parallax = new Vector2(0, 0);
		}

		public void Update()
		{
			if (Mouse.GetState().LeftButton != click)
			{
				if (Mouse.GetState().LeftButton != ButtonState.Released)
					b++;
				click = Mouse.GetState().LeftButton;
			}
			Cursor.GetComponent<Animation>().CurrentFrame = Mouse.GetState().LeftButton == ButtonState.Pressed ? 1 : 0;
			Cursor.GetComponent<Animation>().FrameCount = 2;
			Cursor.GetComponent<Animation>().FrameSize = new Point(16, 21);
			Cursor.GetComponent<Transform>().Position = Mouse.GetState().Position.ToVector2();
			Cursor.GetComponent<Transform>().Parallax = new Vector2(0, 0);
			Cursor.Draw();
		}
		
	}
}
