using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gasolineras.Test
{
    using System.Collections;

    using Gasolineras.Lib;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KataTest
    {
        private const int DistanceStartStop = 200;
        private const int DistanceGas = 5; 
        private const int NumberOfGas = 10;

        [TestMethod]
        public void Can_Add_Ten_Gas_Station_With_Distance_Of_Five()
        {
            var builder = MapBuilder.Create();
            for (var i = 0; i < NumberOfGas; i++)
            {
                builder.AddGasolineraWithMinDistance(DistanceGas);
            }

            var gCount = builder.Map.Gasolineras.Count();

            Assert.AreEqual(gCount, NumberOfGas);
        }

        [TestMethod]
        public void Can_Locate_Start_And_End_With_Distance_Of_TwoThousand()
        {

            var builder = MapBuilder.Create().SetStarAndEndWithMinimumDistance(DistanceStartStop);
           

            var distance = GeoHelper.GetDistanceBetweenPoints(builder.Map.Start, builder.Map.End);

            Assert.IsTrue(distance - DistanceStartStop > 0);
        }

        [TestMethod]
        public void Can_Set_Car_Stop_Point()
        {
            var builder = MapBuilder.Create()
                                    .SetStarAndEndWithMinimumDistance(DistanceStartStop)
                                    .SetStopPoint();


          

           Assert.IsNotNull(builder.Map.Stop);
        }

        [TestMethod]
        public void Can_Find_Nearest_Gas_Stop()
        {
            var builder = MapBuilder.Create()
                                    .SetStarAndEndWithMinimumDistance(DistanceStartStop)
                                    .SetStopPoint();

            for (var i = 0; i < NumberOfGas; i++)
            {
                builder.AddGasolineraWithMinDistance(DistanceGas);
            }

            var gas = builder.FindNearestGasStop();


            Assert.IsNotNull(gas);
        }

    }
}
