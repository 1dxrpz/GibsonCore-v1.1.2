namespace GibsonCore.Interfaces
{
	public interface IDrawableObject : IComponentObject
	{
		public void Draw();
		public void Unload();
	}
}
