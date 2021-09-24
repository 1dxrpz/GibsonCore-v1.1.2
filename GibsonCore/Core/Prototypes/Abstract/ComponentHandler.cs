using System;
using System.Collections.Generic;
using GibsonCore.Components;
using GibsonCore.Core;
using GibsonCore.Interfaces;
using Microsoft.Xna.Framework;

namespace GibsonCore.Abstract
{
	public abstract class ComponentHandler : ObjectParametrs, IDisposable
	{
		public readonly Dictionary<Type, IComponentObject> Components = new Dictionary<Type, IComponentObject>();
		protected GameServiceContainer Services = ScriptManager.Services;
		public SceneManager sceneManager;

		private Scene _scene = GameEntry.scene;

		public Scene Scene
		{
			get => _scene;
			set
			{
				foreach (var item in Components)
				{
					try
					{
						_scene.SceneDraw -= ((IDrawableObject)item.Value).Draw;
						value.SceneDraw += ((IDrawableObject)item.Value).Draw;
					}
					catch
					{

					}
					_scene.EnableChanged -= item.Value.EnableChanged;
					value.EnableChanged += item.Value.EnableChanged;

					_scene.SceneUpdate -= item.Value.Update;
					value.SceneUpdate += item.Value.Update;
					_scene = value;
				}
			}
		}

		public void AddComponent(IComponentObject c)
		{
			c.ParentObject = this;
			Components.Add(c.GetType(), c);

			c.Init();
		}
		public void AddComponent(IDrawableObject c)
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
