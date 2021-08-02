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

namespace GameEngineTK.Scripts
{
	public class PlayerScript : DxScript
	{
		public static GameObject Player;
		public static GameObject Prop;
		TextureHandler texture = new TextureHandler(@"\TestGame\Content\Knight.png");
		TextureHandler prop = new TextureHandler(@"\TestGame\Content\Prop.png");


		public override void Start()
		{
			Player = new GameObject();
			Player.AddComponent(new Animation());
			Player.GetComponent<Animation>().SpriteSheet = texture.ToTexture2D();
			Prop = new GameObject();
			Prop.AddComponent(new Sprite());
			Prop.GetComponent<Sprite>().Texture = prop;
		}

		public override void Update()
		{
			Transform pt = Player.GetComponent<Transform>();
			Transform prt = Prop.GetComponent<Transform>();

			pt.Width = 64 * 2;
			pt.Height = 64 * 2;

			prt.Width = 150;
			prt.Height = 150;

			Player.GetComponent<Animation>().FrameCount = 8;
			Player.GetComponent<Animation>().FrameSize = new Point(32, 32);
			Player.GetComponent<Animation>().AnimationSpeed = 1;

			Player.OriginPosition = new Vector2(32, 32);

			float speed = .5f;

			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				Player.Flip = SpriteEffects.None;
				pt.Velocity.X = speed * Time.deltaTime;
			}
			else
			if (Keyboard.GetState().IsKeyDown(Keys.A))
			{
				Player.Flip = SpriteEffects.FlipHorizontally;
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