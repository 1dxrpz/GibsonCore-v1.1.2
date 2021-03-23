using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;


namespace GameEngineTK.Engine.Utils
{
	public class TextureHandler
	{
		public int Width;
		public int Height;
		Bitmap texture_bmp;
		public TextureHandler()
		{
			texture_bmp = new Bitmap(this.Width, this.Height);
			this.Width = texture_bmp.Width;
			this.Height = texture_bmp.Height;
		}
		public TextureHandler(string path)
		{
			texture_bmp = new Bitmap(@"..\..\..\.." + path);
			this.Width = texture_bmp.Width;
			this.Height = texture_bmp.Height;
		}
		public Microsoft.Xna.Framework.Color GetPixel(int x, int y)
		{
			byte R = this.texture_bmp.GetPixel(x, y).R;
			byte G = this.texture_bmp.GetPixel(x, y).G;
			byte B = this.texture_bmp.GetPixel(x, y).B;
			byte A = this.texture_bmp.GetPixel(x, y).A;
			return new Microsoft.Xna.Framework.Color(R, G, B, A);
		}
		public Microsoft.Xna.Framework.Graphics.Texture2D ToTexture2D()
		{
			var _t = new Microsoft.Xna.Framework.Graphics.Texture2D(ScriptManager.graphicsDevice, this.Width, this.Height);
			var _data = new Microsoft.Xna.Framework.Color[this.Width * this.Height];
			for (int y = 0; y < this.Height; y++)
				for (int x = 0; x < this.Width; x++)
					_data[y * this.Width + x] = this.GetPixel(x, y);
			_t.SetData(_data);
			return _t;
		}
	}
}
