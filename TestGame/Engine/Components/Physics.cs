using GameEngineTK.Engine.Prototypes.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Factories;
using VelcroPhysics.Utilities;

namespace GameEngineTK.Engine
{
	public class Physics : IComponentManager
	{
		private World world;
		public Body body;
		public BodyType bodyType;
		
		private GameObject parent;
		public Vector2 Velocity = new Vector2();
		public Vector2 Acceleration = new Vector2();
		

		public Vector2 Position { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public Vector2 Size = Vector2.One;
		public Vector2 Origin;
		public Physics(World w, BodyType bt, Vector2 size)
		{
			world = w;
			bodyType = bt;
			Size = size;
		}

		public GameObject Parent
		{
			get
			{
				return parent;
			}

			set
			{
				parent = value;
			}
		}
		public void init()
		{
			Transform _t = parent.GetComponent<Transform>();
			
			Origin = Size / 2;
			body = BodyFactory.CreateRectangle(
				world,
				ConvertUnits.ToSimUnits(Size.X),
				ConvertUnits.ToSimUnits(Size.Y),
				ConvertUnits.ToSimUnits(100f),
				ConvertUnits.ToSimUnits(_t.Position),
				0f,
				bodyType,
				this
			);
			
		}
		public void Update()
		{
			
			Transform _t = parent.GetComponent<Transform>();

			_t.Position = ConvertUnits.ToDisplayUnits(body.Position);
			_t.Rotation = (body.Rotation);
			ScriptManager.ctx.Draw(
				BoxCollider.ColliderRenderTexture,
				new Rectangle(
					(int)(ConvertUnits.ToDisplayUnits(body.Position).ScreenPosition().X),
					(int)(ConvertUnits.ToDisplayUnits(body.Position).ScreenPosition().Y),
					(int) (Size.X), (int) (Size.Y)
				), null, Color.White, body.Rotation, Origin, SpriteEffects.None, 0f);
		}


	}
}
