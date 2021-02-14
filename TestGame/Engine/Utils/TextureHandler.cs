using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameEngineTK.Engine
{
	class ColorAdapter
	{
		public byte R;
		public byte G;
		public byte B;
		public byte alpha;
		public ColorAdapter(byte _r, byte _g, byte _b, byte _a = 1)
		{
			this.R = _r;
			this.G = _g;
			this.B = _b;
			this.alpha = _a;
		}
		public override string ToString()
		{
			return "{" + $"{this.R}, {this.G}, {this.B}, {this.alpha}" + "}";
		}
	}
	class TextureHandler
	{
		public int Width;
		public int Height;
		Bitmap texture_bmp;
		public TextureHandler(string path)
		{
			texture_bmp = new Bitmap(path);
			this.Width = texture_bmp.Width;
			this.Height = texture_bmp.Height;
		}
		public ColorAdapter GetPixel(int x, int y)
		{
			Color _clr = texture_bmp.GetPixel(x, y);
			return new ColorAdapter(_clr.R, _clr.G, _clr.B, _clr.A);
		}
	}
}
