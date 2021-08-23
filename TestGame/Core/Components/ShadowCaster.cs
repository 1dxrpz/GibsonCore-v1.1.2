using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Core.Components;
using Microsoft.Xna.Framework;
using Penumbra;

namespace GameEngineTK.Core.Components
{
	internal class ShadowCaster : ComponentBase
	{
		PenumbraComponent penumbra;
		Hull hull;

		Transform _t;

		public override void Init()
		{
			_t = ParentObject.GetComponent<Transform>();
			penumbra = ScriptManager.Services.GetService<PenumbraComponent>();
			hull = new Hull()
			{
			};

			hull.Points.Add(new Vector2(0, 0));
			hull.Points.Add(new Vector2(_t.Width, 0));
			hull.Points.Add(new Vector2(_t.Width, _t.Height));
			hull.Points.Add(new Vector2(0, _t.Height));
			hull.Origin = new Vector2(_t.Width, _t.Height) / 2;
			hull.Rotation = _t.Rotation;
			penumbra.Hulls.Add(hull);

		}
		public override void Update()
		{
			hull.Position = _t.ScreenPosition();
		}
	}
}
