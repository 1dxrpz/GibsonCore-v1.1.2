using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Scene scene = new Scene();

			scene.Add(new Layout());
			scene.Add(new Layout());
			scene.Add(new Layout());
			scene.Add(new Layout());

			scene[0].name = "1";

			scene.debug();
		}
	}
	class Layout
	{
		public Scene parent;
		public int Order;
		private string pname;
		public string name { get
			{
				return pname;
			}
			set
			{
				pname = value;
			}
		}
	}
	class Scene
	{
		private List<Layout> list = new List<Layout>();
		public void debug()
		{
			foreach (var s in list)
				Console.WriteLine($"type: {s}, name: {s.name}");
		}
		public void Add(Layout l)
		{
			if (l.name == null)
			{
				l.name = "Layout" + list.Count;
			}
			l.parent = this;
			list.Add(l);
		}
		public void Add(string n)
		{
			Layout t = new Layout();
			t.name = n;
			t.parent = this;
			list.Add(t);
		}
		public Layout this[int i]
		{
			get
			{
				return list[i];
			}
			set
			{
				if (value.name == null)
					value.name = "Layer" + i;
				list[i] = value;
			}
		}
		public Layout this[string n]
		{
			get
			{
				return list.Find(v => v.name == n);
			}
			set
			{
				list[list.FindIndex(v => v.name == n)] = value;
			}
		}
	}
}
