
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;

namespace Lib
{
    public class NothingProcess : ImageProcess, IImageProcess
    {
        public override Image<Rgba32> RunProcess(Image<Rgba32> input)
        {
            return input;
        }
    }
}