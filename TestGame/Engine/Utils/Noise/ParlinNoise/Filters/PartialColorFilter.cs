using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PerlinNoise.Filters
{
	public class PartialColorFilter : INoiseFilter<float, Color>
	{
        public struct ColorPair
        {
            public float Start;
            public float End;
            public Color Color;

            public ColorPair(float start, float end, Color color)
            {
                this.Start = start;
                this.End = end;
                this.Color = color;
            }

            public bool InRange(float val)
            {
                return val < End && val >= Start;
            }

            public override string ToString()
            {
                return Color + "[" + Start + ", " + End + ")";
            }
        }
        public List<ColorPair> Colors { get; private set; }
        public PartialColorFilter()
        {
            Colors = new List<ColorPair>();
        }
        public NoiseField<Color> Filter(NoiseField<float> field)
        {
            NoiseField<Color> result = new NoiseField<Color>(field.Width, field.Height);

            for (int x = 0; x < field.Width; x++)
            {
                for (int y = 0; y < field.Height; y++)
                {
                    float fieldValue = field.Field[x, y];

                    foreach (ColorPair pair in Colors)
                    {
                        if (pair.InRange(fieldValue))
                        {
                            result.Field[x, y] =
                                new Color((int)(pair.Color.R),
                                          (int)(pair.Color.G),
                                          (int)(pair.Color.B)
                                );
                        }
                    }
                }
            }

            return result;
        }
        public void AddColorPoint(float start, float end, Color color)
        {
            ColorPair pair = new ColorPair(start, end, color);

            Colors.Add(pair);
        }
    }
}