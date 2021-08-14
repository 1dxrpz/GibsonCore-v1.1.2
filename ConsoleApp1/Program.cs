using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
	interface IComp
	{

	}
	class TestComp1 : IComp { }
	class TestComp2 : IComp { }
	class TestComp3 : IComp { }
	class TestComp4 : IComp { }

	abstract class ComponentHandler
	{
		public Dictionary<Type, IComp> Comps = new Dictionary<Type, IComp>();

		public void AddComponent(IComp c)
		{
			Comps.Add(c.GetType(), c);
		}
		public T FGetComponent<T>()
		{
			return (T)Comps[typeof(T)];
		}
	}

	class GObject : ComponentHandler
	{
		
		
	}

	class Program
	{
		static void Main(string[] args)
		{
			GObject gObject = new GObject();
			gObject.AddComponent(new TestComp1());
			gObject.AddComponent(new TestComp2());
			gObject.AddComponent(new TestComp3());
			gObject.AddComponent(new TestComp4());

			Debug.WriteLine("Hello world");

			Console.WriteLine(gObject.FGetComponent<TestComp1>());
		}
	}
}
