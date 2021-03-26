using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using Penumbra;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Utilities;

namespace GameEngineTK.Scripts
{
	public class PlayerScript : IScriptManager
	{
		public static GameObject Player;
		public static GameObject Prop;
		public static GameObject Ground;
		public static GameObject Planet;
		TextureHandler texture = new TextureHandler(@"\TestGame\Content\Knight.png");
		TextureHandler prop = new TextureHandler(@"\TestGame\Content\Prop.png");
		TextureHandler ground = new TextureHandler(@"\TestGame\Content\ground.png");
		TextureHandler planet = new TextureHandler(@"\TestGame\Content\buffered.png");

		World world;
		public void Start()
		{
			Player = new GameObject();
			Player.AddComponent(new AnimatedSprite());
			ConvertUnits.SetDisplayUnitToSimUnitRatio(100f);
			world = new World(new Vector2(0, 10));
			//Player.AddComponent(new Physics(world, BodyType.Dynamic, new Vector2(32, 32)));
			Animation playerAn = Player.GetComponent<AnimatedSprite>().animation;
			playerAn.SpriteSheet = texture.ToTexture2D();
			

			Prop = new GameObject();
			Prop.AddComponent(new Sprite());
			Prop.GetComponent<Sprite>().Texture = prop;
			Prop.MoveTo(0);

			Ground = new GameObject();
			Ground.AddComponent(new Sprite());
			Ground.GetComponent<Sprite>().Texture = ground;
			Ground.GetComponent<Transform>().Position = new Vector2(0, 200);
			Player.GetComponent<Transform>().Position = new Vector2(0, 0);
			//Ground.AddComponent(new Physics(world, BodyType.Static, new Vector2(32, 32)));

			Planet = new GameObject();
			Planet.AddComponent(new BufferedAnimatedSprite());
			BufferedAnimation planetAn = Planet.GetComponent<BufferedAnimatedSprite>().animation;
			planetAn.SpriteSheet = planet.ToTexture2D();
			
		}
		bool test = false;
		public void Update()
		{
			world.Step(Time.deltaTime / 1000 / 2);
			ScriptManager.Services.GetService<Debug>().AddDebugLine("dt: " + Time.deltaTime);

			Transform pt = Player.GetComponent<Transform>();
			Transform prt = Prop.GetComponent<Transform>();

			//Player.GetComponent<Renderer>().Origin = Vector2.Zero;



			prt.Width = 150;
			prt.Height = 150;

			Ground.GetComponent<Transform>().Width = 94 * 2;
			Ground.GetComponent<Transform>().Height = 32 * 2;

			Player.GetComponent<Transform>().Width = 80;
			Player.GetComponent<Transform>().Height = 80;

			Planet.GetComponent<Transform>().Width = 280;
			Planet.GetComponent<Transform>().Height = 280;

			Animation playerAn = Player.GetComponent<AnimatedSprite>().animation;

			playerAn.FrameCount = 8;
			playerAn.FrameSize = new Point(32, 32);
			playerAn.AnimationSpeed = 1;

			BufferedAnimation planetAn = Planet.GetComponent<BufferedAnimatedSprite>().animation;

			planetAn.FrameCount = 100;
			planetAn.FrameSize = new Point(100, 100);
			planetAn.AnimationSpeed = 1;
			planetAn.FrameDepth = 10;


			/*
			if (Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				Player.GetComponent<Physics>().body.ApplyForce(new Vector2(-2f, 0f));
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				Player.GetComponent<Physics>().body.ApplyLinearImpulse(ConvertUnits.ToSimUnits(new Vector2(2f, 0f)));
			}
			if (Keyboard.GetState().IsKeyDown(Keys.Space))
			{
				Player.GetComponent<Physics>().body.ApplyLinearImpulse(ConvertUnits.ToSimUnits(new Vector2(0f, -5f)));
			}
			*/
			//ScriptManager.DefaultLayer.Objects = ScriptManager.DefaultLayer.Objects.ToList<IGameInstances>().OrderBy(a => ((GameObject)a).GetComponent<Transform>().Position.Y).ToList();
			Player.GetComponent<Renderer>().Origin = new Vector2(40, 0);

			float speed = .25f;

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