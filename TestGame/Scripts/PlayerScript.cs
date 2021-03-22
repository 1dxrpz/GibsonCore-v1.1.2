using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine;
using GameEngineTK.Engine.Components;
using GameEngineTK.Engine.Prototypes;
using GameEngineTK.Engine.Prototypes.Interfaces;
using GameEngineTK.Engine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngineTK.Scripts
{
	public class PlayerScript : IScriptManager
	{
		public static GameObject Player;
		TextureHandler texture = new TextureHandler(@"C:\Users\HP\source\repos\TestGame\TestGame\Content\player.png");
		TextureHandler light = new TextureHandler(@"C:\Users\HP\source\repos\TestGame\TestGame\Content\light_right_input.png");
		
		
		Color[] data;
		Texture2D tex;
		public void Start()
		{
			//Player = new GameObject(Content.Load<Texture2D>("player"), 32, 32);
			data = new Color[texture.Width * texture.Height];
			tex = new Texture2D(ScriptManager.graphicsDevice, texture.Width, texture.Height);
			Player = new GameObject();
			//Player.AddComponent(new BoxCollider());
			Player.AddComponent(new Sprite());
			//Player.AddComponent(new Renderer());
			Player.GetComponent<Sprite>().Texture = texture;
			//Console.WriteLine(1);
			Player.init();
		}

		public void Update()
		{
			//var a = Player.GetComponent<BoxCollider>();

			//Player.RotateTowardObject(CursorScript.Cursor);

			ScriptManager.Services.GetService<Debug>().AddDebugLine("dt: " + Time.deltaTime);

			Transform pt = Player.GetComponent<Transform>();

			pt.Width = 64;
			pt.Height = 64;

			Player.OriginPosition = new Vector2(32, 32);

			Console.WriteLine(pt.Width);

			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				Player.Flip = SpriteEffects.None;
				pt.Velocity.X = .25f * Time.deltaTime;
			}
			else
			if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				Player.Flip = SpriteEffects.FlipHorizontally;
				pt.Velocity.X = -.25f * Time.deltaTime;
			}
			else
				pt.Velocity.X = 0;

			if (Keyboard.GetState().IsKeyDown(Keys.S))
				pt.Velocity.Y = .25f * Time.deltaTime;
			else
			if (Keyboard.GetState().IsKeyDown(Keys.W))
				pt.Velocity.Y = -.25f * Time.deltaTime;
			else
				pt.Velocity.Y = 0;
			
			Player.Draw();
		}
	}
}