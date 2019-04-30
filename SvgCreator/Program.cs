using System;
using System.IO;
using System.Reflection;

namespace SvgCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\Users\Qiqete\Documents\Dev\Procedural-Svg-Drawings\test.svg";
            int width = 1000;
            int height = 1000;

            // Generate random points:
            Point[] points = new Point[100];
            Point[] pointsR = new Point[100];
            for (int i = 0; i < points.Length; i++) {
                //Random r = new Random();
                //int randomRadius = r.Next(100);
                points[i] = new Point();
                points[i] = new Point(
                    (int)(500 + ((100 + 150) * Math.Cos(2 * Math.PI / points.Length * i))),
                    (int)(500 + ((100 + 150) * Math.Sin(2 * Math.PI / points.Length * i))));
            }
            // Generate random points on a circular matrix
            for (int i = 0; i < pointsR.Length; i++)
            {
                Random r = new Random();
                int randomRadius = r.Next(200) + 150;
                pointsR[i] = new Point(
                    (int)(500 + (randomRadius * Math.Cos(2 * Math.PI / pointsR.Length * i + 2 * Math.PI / pointsR.Length / 2))),
                    (int)(500 + (randomRadius * Math.Sin(2 * Math.PI / pointsR.Length * i + 2 * Math.PI / pointsR.Length / 2))));
            }


            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(Utils.startOfSvg);

                writer.Write(Draw.StraightPath(points));
                writer.Write(Draw.StraightPath(pointsR, 1, "red"));

                writer.Write(Utils.endOfSvg);
            }
        }
    }
}
