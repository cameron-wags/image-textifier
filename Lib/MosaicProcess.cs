using System;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;

namespace Lib
{
    public class MosaicProcess : ImageProcess, IImageProcess
    {
        private int _horizontal_tile_size;
        private int _vertical_tile_size;

        public MosaicProcess(int horizontalTileSize, int verticalTileSize)
        {
            _horizontal_tile_size = horizontalTileSize;
            _vertical_tile_size = verticalTileSize;
        }

        public override Image<Rgba32> RunProcess(Image<Rgba32> input)
        {
            throw new NotImplementedException();
        }
    }
}