//using OpenCvSharp;
// using OpenCvSharp.CPlusPlus;
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
                Console.WriteLine("Hey");
                //using (var cap = CvCapture.FromFile(@"00026.MTS"))
                //using (var cvWindow = new CvWindow("output"))
                //{
                //    var size = new Size(9, 9);
                //    while (CvWindow.WaitKey(10) < 0)
                //    {
                //        using (IplImage imgSrc = cap.QueryFrame()) 
                //        using (IplImage imgSmall = new IplImage(new Size(640, 480), BitDepth.U8, 1))
                //        using (IplImage imgGray = new IplImage(imgSmall.Size, BitDepth.U8, 1)) 
                //        {
                //            cvWindow.ShowImage(imgSrc);
                //            Cv.Resize(imgSrc, imgSmall);
                //            Cv.CvtColor(imgSmall, imgGray, ColorConversion.BgrToGray);
                //            Cv.Smooth(imgGray, imgGray, SmoothType.Gaussian, 9);
                //            using (CvMemStorage storage = new CvMemStorage())
                //            {
                //                CvSeq<CvCircleSegment> seq = imgGray.HoughCircles(storage, HoughCirclesMethod.Gradient, 1, 100, 150, 55, 0, 0);
                //                foreach (CvCircleSegment item in seq)
                //                {
                //                    imgGray.Circle(item.Center, (int)item.Radius, CvColor.Red, 3);
                //                }
                //                cvWindow.ShowImage(imgGray);
                //            } 
                //        }
                //    }
                //}
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
