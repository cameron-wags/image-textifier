using SixLabors.ImageSharp;

using Lib;


namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var imageName = "flower.jpg";

            using (var inputImage = Image.Load("../input/" + imageName))
            {
                var imageResult = ProcessRunner.Run(inputImage,
                    new MosaicProcess(14, 21)
                    );

                using (var outputImage = imageResult.Clone())
                {
                    outputImage.Save("../output/" + imageName);
                }
            }
        }
    }
}
