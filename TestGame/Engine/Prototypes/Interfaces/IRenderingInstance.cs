using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngineTK.Engine.Prototypes.Interfaces
{
	public interface IRenderingInstance<T>
	{
		[Obsolete("Use DObjects instead;")]
		List<T> Objects { get; }
		//Dictionary<string, T> DObjects { get; }
		//public string name { get; set; }
		public IRenderingInstance<T> parent { get; set; }
		public bool IsVisible { get; set; }
		public void Add(T instance);
		public void Add(string name);
		public T this[int i] { get; set; }
		public T this[string name] { get; set; }
		public void Remove(T instance);
		public void SetOrder();
		public void Render();
	}
}
