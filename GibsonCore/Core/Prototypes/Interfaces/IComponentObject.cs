using GibsonCore.Abstract;

namespace GibsonCore.Interfaces
{
	public interface IComponentObject
	{
		public bool Enabled { get; set; }
		public ComponentHandler ParentObject { get; set; }
		public void Init();
		public void Update();
		public void EnableChanged(bool state);
	}
}
