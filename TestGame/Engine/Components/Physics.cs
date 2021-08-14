using VelcroPhysics.Dynamics;
using VelcroPhysics.Factories;
using VelcroPhysics.Utilities;

namespace GameEngineTK.Engine.Components
{
	internal class Physics : ComponentBase
	{
		public BodyType BodyType
		{
			get => _bodyType;
			set {
				_bodyType = value;
				GenerateBody();
			}
		}

		private BodyType _bodyType = BodyType.Dynamic;
		private Body _body;
		private Transform transform;

		private void GenerateBody()
		{
			_body = BodyFactory.CreateRectangle(
				TWorld.World,
				transform.Width,
				transform.Height,
				1f,
				ConvertUnits.ToSimUnits(transform.Position),
				0f,
				_bodyType,
				this
			);
		}

		public override void Init()
		{
			transform = ParentObject.GetComponent<Transform>();
			this.GenerateBody();
		}
		public override void Update()
		{
			transform.Position = ConvertUnits.ToDisplayUnits(_body.Position);
			transform.Rotation = ConvertUnits.ToDisplayUnits(_body.Rotation);
		}
	}
}
