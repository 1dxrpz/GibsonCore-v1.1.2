using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine.Prototypes.Interfaces
{
	public interface IRenderingInstance<C>
	{
		public List<C> GetObjects { get; }
		public void Add(C instance);
		public void Add(string name);
		public C this[int i] { get; set; }
		public C this[string name] { get; set; }
		public void Remove(C instance);
		public void Remove(string name);
		public void Remove();
		public void SetOrder(int i);
		public void Render();
		public void InsertObject(int i, C l);
	}
}
