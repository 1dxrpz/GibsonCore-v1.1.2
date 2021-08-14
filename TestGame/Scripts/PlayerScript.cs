using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GameEngineTK.Engine;
using GameEngineTK.Engine.Components;
using GameEngineTK.Engine.Prototypes;
using GameEngineTK.Engine.Prototypes.Enums;
using GameEngineTK.Engine.Prototypes.Interfaces;
using GameEngineTK.Engine.Rendering;
using GameEngineTK.Engine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VelcroPhysics.Dynamics;

namespace GameEngineTK.Scripts
{
	public class PlayerScript : DxScript
	{
		public static GameObject Player;
		public GameObject[] Props = new GameObject[10];
		Texture2D texture;
		Texture2D prop;

		Transform pt;
		public override void Start()
		{
			texture = Game1.contentManager.Load<Texture2D>("Knight");
			prop = Game1.contentManager.Load<Texture2D>("Prop");
			Player = new GameObject();
			Player.AddComponent(new Animation());
			Player.AddComponent(new Physics());
			Player.GetComponent<Physics>().BodyType = BodyType.Dynamic;
			
			Player.GetComponent<Animation>().SpriteSheet = texture;
			for (int i = 0; i < 10; i++)
			{
				for (int a = 0; a < 10; a++)
				{
					Props[i] = new GameObject();
					Props[i].AddComponent(new Sprite());
					Props[i].GetComponent<Sprite>().Texture = prop;

					Props[i].GetComponent<Transform>().Width = 150;
					Props[i].GetComponent<Transform>().Height = 150;
					Props[i].GetComponent<Transform>().Position = new Vector2(a * 150, i * 150);
					Props[i].GetComponent<Sprite>().OriginPosition = new Vector2(i * -10, 0);
				}
			}
			
			pt = Player.GetComponent<Transform>();
			pt.Width = 64 * 2;
			pt.Height = 64 * 2;

			Player.GetComponent<Animation>().FrameCount = 8;
			Player.GetComponent<Animation>().FrameSize = new Point(32, 32);
			Player.GetComponent<Animation>().AnimationSpeed = 1;
			Player.GetComponent<Animation>().OriginPosition = new Vector2(32, 32);
		}

		public override void Update()
		{
			float speed = .5f;

			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				pt.Velocity.X = speed * Time.deltaTime;
			}
			else
			if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				pt.Velocity.X = -speed * Time.deltaTime;
			}
			else
				pt.Velocity.X = 0;

			if (Keyboard.GetState().IsKeyDown(Keys.S))
				pt.Velocity.Y = speed * Time.deltaTime;
			else
			if (Keyboard.GetState().IsKeyDown(Keys.W))
				pt.Velocity.Y = -speed * Time.deltaTime;
			else
				pt.Velocity.Y = 0;
			
		}
	}
}