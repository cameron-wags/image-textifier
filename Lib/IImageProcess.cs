using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


public interface IImageProcess
{
    string GetName();
    Image<Rgba32> RunProcess(Image<Rgba32> input);
}