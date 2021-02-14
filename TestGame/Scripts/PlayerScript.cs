using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngineTK.Scripts
{
	public class PlayerScript : Script
	{
		public static GameObject Player;
		TextureHandler texture = new TextureHandler(@"C:\Users\HP\source\repos\TestGame\TestGame\Content\player.png");
		public override void Start()
		{
			//Player = new GameObject(Content.Load<Texture2D>("player"), 32, 32);

			Color[] data = new Color[texture.Width * texture.Height];
			Texture2D tex = new Texture2D(Script.graphicsDevice, texture.Width, texture.Height);
			for (int x = 0; x < texture.Width; x++)
				for (int y = 0; y < texture.Height; y++)
				{
					data[texture.Width * y + x] = new Color(texture.GetPixel(x, y).R, texture.GetPixel(x, y).G, texture.GetPixel(x, y).B, texture.GetPixel(x, y).alpha);
				}
			tex.SetData(data);

			Player = new GameObject(tex, 32, 32);
			Player.AddComponent(new BoxCollider());
		}

		public override void Update()
		{
			Player.Width = 64;
			Player.Height = 64;

			//Player.RotateTowardObject(CursorScript.Cursor);

			Transform pt = Player.GetComponent<Transform>();

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