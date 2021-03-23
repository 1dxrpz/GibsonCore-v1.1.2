using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	/// <summary>
	/// Static theatre contains scenes
	/// </summary>
	static public class Theatre
	{
		static public List<Scene> Scenes = new List<Scene>();
		static public void Add(Scene scene)
		{
			if (Scenes.Contains(scene))
				throw new Exception($"Scene with name {scene.name} already exists.");
			else
				Scenes.Add(scene);
		}
		static public void Remove(Scene scene)
		{
			Scenes.Remove(scene);
		}
	}
}
