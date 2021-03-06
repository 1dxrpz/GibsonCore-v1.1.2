using System;
using System.Collections.Generic;
using System.Text;
using GameEngineTK.Engine.Prototypes.Interfaces;

namespace GameEngineTK.Engine.Rendering
{
	static public class Theatre
	{
		static private List<Scene> Objects = new List<Scene>();
		static public int ObjectsCount {
			get
			{
				return Objects.Count;
			}
		}
		static public List<Scene> GetObjects { get { return Objects; } }
		static public void Add(Scene instance)
		{
			if (instance.name == null)
			{
				instance.name = "Scene" + Objects.Count;
			}
			if (Objects.FindIndex(v => v.name == instance.name) != - 1)
				throw new Exception($"Scene {instance.name} already exists");
			Objects.Add(instance);
		}
		static public void Add(string name)
		{
			Scene t = new Scene();
			if (Objects.FindIndex(v => v.name == name) != -1)
				throw new ArgumentException($"Scene {name} already exists");
			t.name = name;
			Objects.Add(t);
		}
		static public void Remove(string name)
		{
			Objects.Remove(Objects.Find(v => v.name == name));
		}
		static public void Remove(Scene instance)
		{
			Objects.Remove(instance);
		}
		static public void Render()
		{

		}
		static public void InsertObject(int i, Scene l)
		{
			Objects.Remove(l);
			Objects.Insert(i, l);	
		}
	}
}
