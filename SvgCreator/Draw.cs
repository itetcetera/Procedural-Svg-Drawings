using System;
using System.Collections.Generic;
using System.Text;

namespace SvgCreator
{
    class Draw
    {
        public static string DrawCircle(Point p)
        {
            return @"<circle r=""1.5"" cy = """ + p.Y + "\"" + " cx=\"" + p.X + @""" style=""fill:#000000;stroke:none"" id=""path27"" /> ";
        }
        public static string DrawCircle(Point p, double radius)
        {
            return @"<circle r="""+ radius + @""" cy = """ + p.Y + "\"" + " cx=\"" + p.X + @""" style=""fill:#000000;stroke:none"" id=""path27"" /> ";
        }

        public static string DrawLine(Point p1, Point p2)
        {
            return @"<path id = ""linefrom"" d = ""m " + p1.X + "," + p1.Y + " " + (p2.X-p1.X) + "," + (p2.Y-p1.Y) + @""" style=""fill: none; stroke:#000000;stroke-width:1px;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1"" />";
        }
        public static string DrawLine(Point p1, Point p2, double stroke)
        {
            return @"<path id = ""linefrom"" d = ""m " + p1.X + "," + p1.Y + " " + (p2.X - p1.X) + "," + (p2.Y - p1.Y) + @""" style=""fill: none; stroke:#000000;stroke-width:"+stroke+@"px;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1"" />";
        }

        public static string DrawLine(Point p1, Point p2, double stroke, string strokeColor)
        {
            return @"<path id = ""linefrom"" d = ""m " + p1.X + "," + p1.Y + " " + (p2.X - p1.X) + "," + (p2.Y - p1.Y) + @""" style=""fill: none; stroke:"+ strokeColor + @";stroke-width:" + stroke.ToString() + @"px;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1"" />";
        }

        public static string StraightPath(Point[] points) {
            String path = @"<path id = ""linefrom"" style=""fill:; stroke:#000000;stroke-width:1px;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1"" d=""";
            path += "m " + points[0].Y + "," + points[0].X + " ";
            for (int i = 1; i < points.Length; i++) {
                path += (points[i].Y - points[i-1].Y) + "," + (points[i].X - points[i-1].X) + " ";
            }
            return path + @"z"" />";
        }
        public static string StraightPath(Point[] points, int stroke, string strokeColor) {
            String path = @"<path id = ""linefrom"" style=""fill: red; stroke:" + strokeColor +@";stroke-width:"+ stroke +@"px;stroke-linecap:butt;stroke-linejoin:miter;stroke-opacity:1"" d=""";
            path += "m " + points[0].Y + "," + points[0].X + "l ";
            for (int i = 1; i < points.Length; i++) {
                path += (points[i].Y - points[i - 1].Y) + "," + (points[i].X - points[i - 1].X) + " ";
            }
            return path + @""" />";
        }

    }
}
