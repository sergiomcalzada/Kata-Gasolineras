using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gasolineras.Lib
{
    using System.Drawing;

    public class Gasolinera
    {
        public PointF Location { get; protected set; }

         public Gasolinera(float x, float y) : this(new PointF(x, y))
         {
           
         }

         public Gasolinera(PointF p)
         {
             this.Location = p;
         }
    }
}
