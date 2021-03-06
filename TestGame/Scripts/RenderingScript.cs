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

			firstScene.Add("a");
			secondScene.Add("b");

			Layout l = new Layout();

			secondScene.Add(l);
			l.name = "c";

			secondScene.Add(firstScene["a"]);
			firstScene.Remove("a");

			secondScene["a"].SetOrder(0);
			secondScene["c"].SetOrder(1);

			Layout l1 = secondScene["c"];

			l1.Add("test");
			l1.Add("test1");

		}
		public void Update()
		{
			// Here's your Update code
		}
	}
}
