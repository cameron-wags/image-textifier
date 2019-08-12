using System;
using System.Collections.Generic;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;


namespace Lib
{
    public class ProcessRunner
    {
        public List<IImageProcess> ToRun { get => _processes; }
        private List<IImageProcess> _processes;

        public ProcessRunner(params IImageProcess[] processes)
        {
            _processes = new List<IImageProcess>();

            foreach (var process in processes)
            {
                ToRun.Add(process);
            }
        }

        public Image<Rgba32> Run(Image<Rgba32> image)
        {
            var tempImage = image;
            foreach (var process in _processes)
            {
                tempImage = process.RunProcess(tempImage);
            }

            return tempImage;
        }

        public static Image<Rgba32> Run(Image<Rgba32> input, params IImageProcess[] processes)
        {
            var runner = new ProcessRunner(processes);

            return runner.Run(input);
        }
    }
}