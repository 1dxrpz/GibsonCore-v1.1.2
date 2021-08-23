using System;
using GameEngineTK.Core.Prototypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using tainicom.Aether.Physics2D.Dynamics;
using VelcroPhysics.Collision.ContactSystem;

namespace GameEngineTK.Core.Components
{
	internal class Physics : DrawableBase
	{
		public Action<Body> OnCollision;
		public BodyType BodyType
		{
			get => _bodyType;
			set {
				_bodyType = value;
				_body.BodyType = value;
				_body.ResetDynamics();
			}
		}
		private BodyType _bodyType = BodyType.Dynamic;
		private Transform transform;

		private Body _body;
		private Fixture _fixture;
		Texture2D texture;
		public override void Init()
		{
			transform = ParentObject.GetComponent<Transform>();
			texture = new Texture2D(ScriptManager.graphicsDevice, 1, 1);
			Color[] data = new Color[1] { new Color(255, 0, 0, 100) };
			texture.SetData(data);

			_body = GameWorld.World.CreateBody(
				new tainicom.Aether.Physics2D.Common.Vector2(transform.Position.X, transform.Position.Y),
				transform.Rotation,
				_bodyType
				);

			_fixture = _body.CreateRectangle(
				transform.Width,
				transform.Height,
				1f,
				new tainicom.Aether.Physics2D.Common.Vector2(0, 0)
			);
			_fixture.Restitution = 0.3f;
			_fixture.Friction = 0.5f;


			ParentObject.GetComponent<Transform>().PositionChanged += this.MatchPosition;
			_body.OnCollision += this.Collided;
		}

		private bool Collided(Fixture sender, Fixture other, tainicom.Aether.Physics2D.Dynamics.Contacts.Contact contact)
		{
			OnCollision?.Invoke(other.Body);
			return true;
		}

		private void MatchPosition(Vector2 position)
		{
			
		}

		public override void Update()
		{
			transform.Position = new Vector2(_body.Position.X, _body.Position.Y);
			transform.Rotation = (_body.Rotation);
		}
		public void ApplyForce(Vector2 force)
		{
			_body.ApplyLinearImpulse(new tainicom.Aether.Physics2D.Common.Vector2(force.X, force.Y) * 1000f);
		}

		public override void Draw()
		{
			ScriptManager.ctx.Draw(
				texture,
				new Rectangle(
					transform.ScreenPosition().ToPoint(),
					new Point(transform.Width, transform.Height)),
					new Rectangle(0, 0, transform.Width, transform.Height),
					Color.White,
					(_body.Rotation),
					new Vector2(transform.Width, transform.Height) / 2f,
					SpriteEffects.None,
					0
				);
		}

		public override void EnableChanged(bool state)
		{

		}
		
	}
}
