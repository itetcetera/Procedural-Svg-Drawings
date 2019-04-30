using System;
using System.IO;
using System.Reflection;

namespace SvgCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\Qiqete\\Documents\\Dev\\csharp\\SvgCreator\\test.svg";
            int width = 1000;
            int height = 1000;

            // Generate random points:
            Point[] points = new Point[100];
            Point[] pointsR = new Point[100];
            for (int i = 0; i < points.Length; i++)
            {
                //points[i] = new Point();
                points[i] = new Point(
                    (int)(500 + (250 * Math.Cos(2 * Math.PI / points.Length * i))),
                    (int)(500 + (250 * Math.Sin(2 * Math.PI / points.Length * i))));
            }
            // Generate random points on a circular matrix
            for (int i = 0; i < pointsR.Length; i++)
            {
                Random r = new Random();
                int randomRadius = r.Next(200) + 150;
                pointsR[i] = new Point(
                    (int)(500 + (randomRadius * Math.Cos(2 * Math.PI / points.Length * i + 2 * Math.PI / points.Length / 2))),
                    (int)(500 + (randomRadius * Math.Sin(2 * Math.PI / points.Length * i + 2 * Math.PI / points.Length / 2))));
            }


            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.Write(Utils.startOfSvg);
                // Todo: Write here every path
                for (int i = 0; i < points.Length; i++)
                {
                    
                    //writer.WriteLine(Draw.DrawCircle(points[i]));
                    if(i != points.Length - 1)
                    {
                        //Random r = new Random();
                        writer.WriteLine(Draw.DrawLine(points[i], pointsR[i], 1.5));
                        writer.WriteLine(Draw.DrawLine(pointsR[i], points[i+1], 1.5));
                    }
                    else
                    { 
                        writer.WriteLine(Draw.DrawLine(points[i], pointsR[i], 1.5));
                        writer.WriteLine(Draw.DrawLine(pointsR[i], points[0], 1.5));
                    }
                }
                writer.Write(Utils.endOfSvg);
            }
        }
    }
}
