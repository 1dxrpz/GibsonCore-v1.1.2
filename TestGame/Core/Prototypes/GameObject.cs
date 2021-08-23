using GameEngineTK.Core.Components;
using GameEngineTK.Core.Prototypes;
using GameEngineTK.Core.Prototypes.Enums;
using GameEngineTK.Core.Prototypes.Interfaces;
using GameEngineTK.Core.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Core
{
	public class GameObject : ComponentHandler, IDisposable
	{
		public GameObject()
		{
			AddComponent(new Transform());
			AddComponent(new Renderer());
			
			this.EnsureDefaults();

		}

		public void EnsureDefaults()
		{
			var config = ConfigReader.Parse("project");
			if (config.ContainsKey("EnsureDefaults") && ConfigReader.GetBool(config, "EnsureDefaults"))
			{
				//ScriptManager.DefaultLayer.Add(this);
			}
		}


		#region TEST THIS OPTION FOR OPTIMISATION ISSUES
		public float Distance(GameObject obj)
		{
			return 1;
		}
		/*
		 * the fuck is this
		 */
		public float VDistance(GameObject obj)
		{
			Vector2 opos = obj.GetComponent<Transform>().Position;
			Vector2 pos = this.GetComponent<Transform>().Position;
			return Vector2.Distance(opos, pos);
		}
		#endregion



		public void Draw()
		{
			
		}

		public void Dispose()
		{
			
		}
	}
}