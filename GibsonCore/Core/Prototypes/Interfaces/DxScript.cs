using GibsonCore.Abstract;
using GibsonCore.Core;

namespace GibsonCore.Interfaces
{
	public class DxScript : IScriptableObject
	{
		public SceneManager SceneManager;
		public DxScript()
		{
			GameManager.InitEvent += Start;
			GameManager.UpdateEvent += Update;
		}
		public virtual void Start() { }
		public virtual void Update() { }
	}
}
