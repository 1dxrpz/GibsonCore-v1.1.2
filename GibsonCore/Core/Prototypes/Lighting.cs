using GibsonCore.Abstract;
using Microsoft.Xna.Framework;
using Penumbra;

namespace GibsonCore.Core
{
	public class Lighting : ComponentHandler
	{
		public bool Enabled = false;
		public Color AmbientColor = Color.Black;
		public bool Visible = false;
		PenumbraComponent penumbra;
		public Lighting()
		{
			penumbra = Services.GetService<PenumbraComponent>();
		}
		public void ApplyLighting()
		{
			penumbra.AmbientColor = AmbientColor;
			penumbra.Visible = Enabled;
			penumbra.Enabled = Enabled;
		}
		
		public void AddLightSource(Light light)
		{
			penumbra.Lights.Add(light);
		}
	}
}
