using System;

using SixLabors.ImageSharp;

using Lib;


namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var imageName = "flower.jpg";

            using (var inputImage = Image.Load("../inputs/" + imageName))
            {
                var imageResult = ProcessRunner.Run(inputImage,
                    new NothingProcess());

                using (var outputImage = imageResult.Clone())
                {
                    outputImage.Save("../outputs/" + imageName);
                }
            }
        }
    }
}
