using System.Collections.Generic;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;


namespace Lib
{
    public class ProcessRunner
    {
        public List<IImageProcess> ToRun { get; } = new List<IImageProcess>();

        public ProcessRunner(params IImageProcess[] processes)
        {
            ToRun.AddRange(processes);
        }

        public Image<Rgba32> Run(Image<Rgba32> image)
        {
            var tempImage = image;

            ToRun.ForEach((process) =>
            {
                tempImage = process.RunProcess(tempImage);
            });

            return tempImage;
        }

        public static Image<Rgba32> Run(Image<Rgba32> input, params IImageProcess[] processes)
        {
            var runner = new ProcessRunner(processes);

            return runner.Run(input);
        }
    }
}