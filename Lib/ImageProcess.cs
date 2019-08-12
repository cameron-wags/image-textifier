
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;

namespace Lib
{
    public abstract class ImageProcess : IImageProcess
    {
        public static readonly string Name = "Do Nothing";

        public string GetName()
        {
            return Name;
        }

        public virtual Image<Rgba32> RunProcess(Image<Rgba32> input)
        {
            return input;
        }
    }
}