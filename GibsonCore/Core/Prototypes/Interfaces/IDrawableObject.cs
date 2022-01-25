using System;

namespace GibsonCore.Interfaces
{
	public interface IDrawableObject : IComponentObject
	{
		public void Draw();
		public void Unload();
	}
	#region Delete this
	[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class CustomDescriptionAttribute : Attribute
	{
		public string Description { get; private set; }

		public CustomDescriptionAttribute(string description)
		{
			Description = description;
		}
	}
	#endregion
}
