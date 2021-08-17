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
using tainicom.Aether.Physics2D.Dynamics;

namespace GameEngineTK.Scripts
{
	public class PlayerScript : DxScript
	{
		public static GameObject Player;
		public static GameObject Ground;
		Texture2D _texture;
		Texture2D _groundTexture;

		Transform pt;
		public override void Start()
		{
			_texture = Game1.contentManager.Load<Texture2D>("Knight");
			_groundTexture = Game1.contentManager.Load<Texture2D>("frame");

			Player = new GameObject();
			Ground = new GameObject();

			Player.AddComponent(new Animation());
			
			pt = Player.GetComponent<Transform>();
			pt.Width = 64 * 2;
			pt.Height = 64 * 2;
			Ground.AddComponent(new Sprite());
			Ground.GetComponent<Transform>().Width = 500;
			Ground.GetComponent<Transform>().Height = 100;
			Ground.GetComponent<Sprite>().Texture = _groundTexture;
			Player.GetComponent<Transform>().Position = new Vector2(0, -20);

			Player.GetComponent<Animation>().SpriteSheet = _texture;

			Player.GetComponent<Animation>().FrameCount = 8;
			Player.GetComponent<Animation>().FrameSize = new Point(32, 32);
			Player.GetComponent<Animation>().AnimationSpeed = 1;
			//Player.GetComponent<Animation>().OriginPosition = new Vector2(32, 32);

			Ground.AddComponent(new Physics());
			Ground.GetComponent<Physics>().BodyType = BodyType.Static;
			Player.AddComponent(new Physics());
			Player.GetComponent<Physics>().BodyType = BodyType.Dynamic;
			Ground.GetComponent<Sprite>().OriginPosition = new Vector2(32, 30);
			//Player.GetComponent<Physics>().OnCollision += collide;
		}

		private void collide(Body obj)
		{
			//obj.ApplyLinearImpulse(new Vector2(0, 10f));
		}

		public override void Update()
		{
			
			float speed = 100f;

			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				Player.GetComponent<Physics>().ApplyForce(new Vector2(1000f, 0));
			}
			
		}
	}
}