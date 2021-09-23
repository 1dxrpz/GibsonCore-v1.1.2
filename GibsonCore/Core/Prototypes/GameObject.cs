using GibsonCore.Abstract;
using GibsonCore.Components;
using GibsonCore.Utils;
using Microsoft.Xna.Framework;

namespace GibsonCore.Core
{
	public class GameObject : ComponentHandler
	{
		
		public GameObject()
		{
			Scene = GameEntry.scene;
			AddComponent(new Transform());
			AddComponent(new Renderer());
			
			this.EnsureDefaults();
			sceneManager = ScriptManager.Services.GetService<SceneManager>();
			sceneManager.SceneChanged += CheckScene;
		}

		private void CheckScene()
		{
			
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

		
	}
}