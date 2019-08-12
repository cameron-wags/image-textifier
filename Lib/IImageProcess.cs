using System.IO;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;


public interface IImageProcess
{
    string GetName();
    Image<Rgba32> RunProcess(Image<Rgba32> input);
}