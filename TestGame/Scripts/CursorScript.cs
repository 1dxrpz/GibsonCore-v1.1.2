using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngineTK.Scripts
{
	class CursorScript : Script
	{
		public static GameObject Cursor;

		public override void Start()
		{
			Services.GetService<ProjectSettings>().ShowColliders = false;
			Cursor = new GameObject(Content.Load<Texture2D>("CursorSpriteSheet"), 32, 42);
			Cursor.AddComponent(new Animation(Cursor.Texture, 32, 42));
			Cursor.GetComponent<Transform>().Parallax = new Vector2(0, 0);			
		}

		public override void Update()
		{
			Cursor.GetComponent<Animation>().CurrentFrame = Mouse.GetState().LeftButton == ButtonState.Pressed ? 1 : 0;
			Cursor.GetComponent<Animation>().FrameCount = 2;
			Cursor.GetComponent<Animation>().FrameSize = new Point(16, 21);
			Cursor.GetComponent<Transform>().Position = Mouse.GetState().Position.ToVector2();
			Cursor.GetComponent<Transform>().Parallax = new Vector2(0, 0);
			Cursor.Draw();
		}
		
	}
}
