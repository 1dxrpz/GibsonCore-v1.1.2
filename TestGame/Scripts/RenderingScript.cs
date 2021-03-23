using System;
using GameEngineTK.Engine;
using GameEngineTK.Engine.Prototypes.Interfaces;
using GameEngineTK.Engine.Rendering;

namespace GameEngineTK.Scripts
{
	class RenderingScript : IScriptManager
	{
		public void Start()
		{
			Scene firstScene = new Scene();
			Scene secondScene = new Scene();
			Scene thirdScene = new Scene();

			Layout layerf = new Layout();
			secondScene.Add(layerf);

			Layer a = new Layer("first");
			layerf.Add(a);
			layerf.Remove();

			//firstScene.Add(secondScene);

		}
		public void Update()
		{
			// Here's your Update code
		}
	}
}
