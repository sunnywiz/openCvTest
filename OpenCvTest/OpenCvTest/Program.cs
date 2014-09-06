using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCvTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var cap = CvCapture.FromFile(@"00026.MTS"))
                using (var cvWindow = new CvWindow("output"))
                {
                    cvWindow.Resize(1280, 720); 
                    while (CvWindow.WaitKey(1) < 0)
                    {
                        Console.Write(".");
                        using (var src = cap.QueryFrame())
                        {
                            if (src == null) break;
                            using (var gray = new IplImage(src.Size, BitDepth.U8, 1))
                            using (var canny = new IplImage(src.Size, BitDepth.U8, 1))
                            {
                                src.CvtColor(gray, ColorConversion.BgrToGray);
                                Cv.Canny(gray, canny, 50, 50, ApertureSize.Size3);
                                cvWindow.Image = canny;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Done");
            }

        }
    }
}
