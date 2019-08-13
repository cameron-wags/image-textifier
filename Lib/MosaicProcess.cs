using System.Linq;
using System;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


namespace Lib
{
    public class MosaicProcess : ImageProcess, IImageProcess, IDisposable
    {
        private int _horizontal_tile_size;
        private int _vertical_tile_size;

        private int _horizontal_tile_count;
        private int _vertical_tile_count;

        private Image<Rgba32> _image;

        public MosaicProcess(int horizontalTileSize, int verticalTileSize)
        {
            _horizontal_tile_size = horizontalTileSize;
            _vertical_tile_size = verticalTileSize;
        }

        public override Image<Rgba32> RunProcess(Image<Rgba32> input)
        {
            _image = input;
            _horizontal_tile_count = _image.Width / _horizontal_tile_size;
            _vertical_tile_count = _image.Height / _vertical_tile_size;

            // This is so much cooler than a nested for loop, just look at how lame it is 
            Enumerable.Range(0, _horizontal_tile_count).ToList()                 // for (int h = 0; h < _horizontal_tile_count; h++)
            .ForEach((horizontalIndex) =>                                        // {
            {                                                                    //     for (int v = 0; v < _horizontal_tile_count; v++)
                Enumerable.Range(0, _vertical_tile_count).ToList()               //     {
                .ForEach((verticalIndex) =>                                      //         var color = AggregateTile(h, v);
                {                                                                //         WriteTile(h, v, color);
                    var color = AggregateTile(horizontalIndex, verticalIndex);   //     }
                    WriteTile(horizontalIndex, verticalIndex, color);            // }
                });
            });

            return _image;
        }

        /// <summary>
        /// Aggregates a region of the input image into a single color.
        /// </summary>
        /// <param name="horizontalIndex"></param>
        /// <param name="verticalIndex"></param>
        /// <returns>Color value</returns>
        private Rgba32 AggregateTile(int horizontalIndex, int verticalIndex)
        {
            //TODO: come up with some strategy to aggregate the tile's pixels instead of just gradienting

            var r = (byte)Convert.ToInt32((double)horizontalIndex / _horizontal_tile_count * 255);
            var g = (byte)0;
            var b = (byte)Convert.ToInt32((double)verticalIndex / _vertical_tile_count * 255);
            var a = (byte)255;

            return new Rgba32(r, g, b, a);
        }

        /// <summary>
        /// Writes a color to the specified tile.
        /// </summary>
        /// <param name="horizontalIndex"></param>
        /// <param name="verticalIndex"></param>
        /// <param name="value"></param>
        private void WriteTile(int horizontalIndex, int verticalIndex, Rgba32 value)
        {
            int xStart = horizontalIndex * _horizontal_tile_size;
            int xFinish = xStart + _horizontal_tile_size;
            int yStart = verticalIndex * _vertical_tile_size;
            int yFinish = yStart + _vertical_tile_size;

            for (int x = xStart; x < xFinish && x < _image.Width; x++)
            {
                for (int y = yStart; y < yFinish && y < _image.Height; y++)
                {
                    _image[x, y] = value;
                }
            }
        }

        public void Dispose()
        {
            _image.Dispose();
        }
    }
}