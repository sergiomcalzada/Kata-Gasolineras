using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gasolineras.Lib
{
    using System.Drawing;

    public class GeoHelper
    {
        private static readonly Random Random = new Random((int)DateTime.Now.Ticks); 

        public static double GetDistanceBetweenPoints(PointF p, PointF q)
        {
            var a = p.X - q.X;
            var b = p.Y - q.Y;
            var distance = Math.Sqrt(a * a + b * b);
            return distance;
        }

        public static PointF GetRandomPoint(double min, double max)
        {
            var x = (float)Random.NextDouble(min, max);
            var y = (float)Random.NextDouble(min, max);
            return new PointF(x, y);
        }

        public static PointF GetRandomPointInLine(PointF start, PointF end)
        {
            var t = Random.NextDouble(0, 1);
            var x = (float)((1 - t) * start.X + t * end.X);
            var y = (float)((1 - t) * start.Y + t * end.Y);

            return new PointF(x, y);
        }
    }
}
