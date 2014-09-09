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
                Console.WriteLine("Hey");
                using (var cap = CvCapture.FromFile(@"00026.MTS"))
                using (var cvWindow = new CvWindow("output"))
                {
                    var size = new Size(9, 9);
                    while (CvWindow.WaitKey(10) < 0)
                    {
                        using (IplImage imgSrc = cap.QueryFrame())
                        {
                            if (imgSrc == null) break;
                            using (IplImage imgSmall = new IplImage(new Size(720, 360), imgSrc.Depth, imgSrc.NChannels))
                            using (IplImage imgGray = new IplImage(imgSmall.Size, BitDepth.U8, 1))
                            {
                                //            cvWindow.ShowImage(imgSrc);
                                Cv.Resize(imgSrc, imgSmall);
                                // cvWindow.ShowImage(imgSmall);
                                Cv.CvtColor(imgSmall, imgGray, ColorConversion.BgrToGray);
                                // cvWindow.ShowImage(imgGray);
                                Cv.Smooth(imgGray, imgGray, SmoothType.Gaussian, 9);
                                cvWindow.ShowImage(imgGray);
                                CvWindow.WaitKey(10);
                                bool found = false; 
                                using (CvMemStorage storage = new CvMemStorage())
                                {
                                    CvSeq<CvCircleSegment> seq = imgGray.HoughCircles(storage, HoughCirclesMethod.Gradient, 1, 100, 50, 45, 3, 100);
                                    foreach (CvCircleSegment item in seq)
                                    {
                                        imgSmall.Circle(item.Center, (int)item.Radius, CvColor.Red, 3);
                                        found = true; 
                                    }
                                }
                                cvWindow.ShowImage(imgSmall);
                                if (found) { CvWindow.WaitKey(500); }
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
