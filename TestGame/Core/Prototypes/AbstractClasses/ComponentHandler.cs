using System;
using System.Collections.Generic;
using GameEngineTK.Core.Components;
using GameEngineTK.Core.Prototypes.Interfaces;
using Microsoft.Xna.Framework;

namespace GameEngineTK.Core.Prototypes
{
	public abstract class ComponentHandler : ObjectParametrs, IDisposable
	{
		public readonly Dictionary<Type, IComponentObject> Components = new Dictionary<Type, IComponentObject>();
		protected GameServiceContainer Services = ScriptManager.Services;
		public void AddComponent(IComponentObject c)
		{
			c.ParentObject = this;
			Components.Add(c.GetType(), c);
			c.Init();
		}
		public void RemoveComponent(IComponentObject c)
		{
			Components.Remove(c.GetType());
		}

		public T GetComponent<T>()
		{
			return (T)Components[typeof(T)];
		}
		public bool HasComponent<T>()
		{
			return Components.ContainsKey(typeof(T));
		}

		public void Dispose()
		{
			
		}
	}
}
