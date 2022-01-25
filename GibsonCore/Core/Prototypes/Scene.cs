using GibsonCore.Abstract;
using System;

namespace GibsonCore.Core
{
	public class Scene
	{
		private bool _enabled = false;
		public bool IsEnabled
		{
			get => _enabled;
			set
			{
				EnableChanged?.Invoke(value);
				_enabled = value;
			}
		}
		public Action SceneUpdate;
		public Action SceneDraw;
		public Action<bool> EnableChanged;

		public Scene()
		{
			//SceneManager a = ScriptManager.Services.GetService<SceneManager>();
			//a.Add(this);
		}
	}
}
