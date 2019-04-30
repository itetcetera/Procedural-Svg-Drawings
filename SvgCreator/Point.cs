using System;
using System.Collections.Generic;
using System.Text;

namespace SvgCreator
{
    class Point
    {
        readonly int x;
        readonly int y;

        public int X => x;

        public int Y => y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {
            Random r = new Random();
            x = r.Next(1000);
            y = r.Next(1000);
            Console.WriteLine(x + "," + y);
        }
    }
}
