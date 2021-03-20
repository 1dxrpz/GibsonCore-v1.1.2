using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine.Rendering
{
	public class Scene : RenderingInstance
	{
		public Scene(string name = null)
		{
			Theatre.Scenes.Add(this);
			Parent = null;
			if (name is null)
				Name = $"Unnamed Scene {Theatre.Scenes.Count}";
			else if (Theatre.Scenes.FindIndex(v => v.Name == name) != -1)
				throw new Exception($"Scene with name '{name}' already exists;");
			else Name = name;
		}

		public RenderingInstance Parent = null;
		public List<Layout> Children = new List<Layout>();

		public Layout childtype;
	}
}