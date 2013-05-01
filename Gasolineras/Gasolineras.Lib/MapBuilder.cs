using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gasolineras.Lib
{
    using System.Drawing;

    public class MapBuilder
    {
         
        private const int DefaultMapWith = 1000;
        private const int DefaultMapHeight = 1000;
        private const int MaxFindRetry = 20;

        public Map Map { get; set; }

        private MapBuilder()
            : this(DefaultMapWith, DefaultMapHeight)
        {    
        }

        private MapBuilder(int width, int height)
        {
            this.Map = new Map(width, height);
        }

     
        public static  MapBuilder Create()
        {
            return new MapBuilder();
        }

        public MapBuilder AddGasolineraWithMinDistance(float distance)
        {
            for (var i = 0; i < MaxFindRetry; i++)
            {
                var gasolinera = this.GetRandomGasolinera();
                var isValidGasolinera = this.IsValidGasolinera(gasolinera, distance);
                if (isValidGasolinera) 
                {
                    this.AddGasolinera(gasolinera);
                    return this;
                }
                
            }
           
            throw new ArgumentException(string.Format("Can't find a gas station in {0} attemps with {1} distance", MaxFindRetry, distance));
        }

        public MapBuilder SetStarAndEndWithMinimumDistance(int distance)
        {
            var star = GeoHelper.GetRandomPoint(0, this.Map.Width);
            for (var i = 0; i < MaxFindRetry; i++)
            {
                var end = GeoHelper.GetRandomPoint(0, this.Map.Width);
                var isValidPoint = this.IsValidPoint(star, end, distance);
                if (isValidPoint)
                {
                    this.Map.Start = star;
                    this.Map.End = end;
                    return this;
                }

            }

            throw new ArgumentException(string.Format("Can't find random points in {0} attemps with {1} distance", MaxFindRetry, distance));
        }

        public MapBuilder SetStopPoint()
        {
            var stop = GeoHelper.GetRandomPointInLine(this.Map.Start, this.Map.End);
            this.Map.Stop = stop;
            return this;
        }   

        public Gasolinera FindNearestGasStop()
        {
           var distCalc =  this.Map.Gasolineras.Select( x => new { g = x, distance = GeoHelper.GetDistanceBetweenPoints(x.Location, this.Map.Stop) }).ToList();

            var minDist = distCalc.Min(x => x.distance);

            return distCalc.SingleOrDefault(x => x.distance == minDist).g;
        }

        private Gasolinera GetRandomGasolinera()
        {

            var point = GeoHelper.GetRandomPoint(0, this.Map.Width);
            var gasolinera = new Gasolinera(point);   
            return gasolinera;
        }


        private void AddGasolinera(Gasolinera gasolinera)
        {
            this.Map.Gasolineras.Add(gasolinera);
        }   

        private bool IsValidGasolinera(Gasolinera gasolinera, float distance)
        {
            return this.Map.Gasolineras.All(x => GeoHelper.GetDistanceBetweenPoints(gasolinera.Location, x.Location) > distance);
        }

        private bool IsValidPoint(PointF star, PointF end, int distance)
        {
            return GeoHelper.GetDistanceBetweenPoints(star, end) > distance;
        }

        
    }
}
