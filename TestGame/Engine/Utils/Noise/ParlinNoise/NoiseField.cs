using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameEngineTK.Engine;

namespace PerlinNoise {
    /// <summary>
    /// Noise fields are 2D arrays of noise values.
    /// </summary>
    public class NoiseField<T> {
        /// <summary>
        /// Gets the values for this noise.
        /// </summary>
        public T[,] Field { get; private set; }

        /// <summary>
        /// Gets the width of this Field
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the Height of this field.
        /// </summary>
        public int Height { get; private set; }

        public NoiseField(int width, int height) {
            Field = new T[width, height];

            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Flattens this field into a 1D array.  This will be Width * Height long.
        /// </summary>
        /// <returns></returns>
        public T[] Flatten() {
            T[] arr = new T[this.Width * this.Height];

			var a = this.Width;
			var b = this.Height;

			for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++) {
                    
                    arr[x + (y * this.Width)] = this.Field[x, y];
					
                }
            }

            return arr;
        }
    }
}
