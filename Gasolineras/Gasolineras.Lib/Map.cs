namespace Gasolineras.Lib
{
    using System.Collections.Generic;
    using System.Drawing;

    public class Map
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public PointF Start { get; set; }
        public PointF End { get; set; }
        public PointF Stop { get; set; }

        public IList<Gasolinera> Gasolineras { get; protected set; }

      

        public Map(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Gasolineras = new List<Gasolinera>();
        }
    }
}
