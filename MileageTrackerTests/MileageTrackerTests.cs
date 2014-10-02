using System;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MileageTrackerTests
{
    [TestClass]
    public class MileageTrackerTests
    {
        [TestMethod]
        public void Given_I_Enter_2_Days_55_Mileage_Is_Returned()
        {
            var expectedMileage = new Mileage(55);

            var tracker = new MileageTracker(10000, 2);

            var actualMileage = tracker.GetMileageFromNumberOfDays();

            Assert.AreEqual(expectedMileage, actualMileage);
        }

        [TestMethod]
        public void Given_I_Enter_105_Days_2877_Mileage_Is_Returned()
        {
            var expectedMileage = new Mileage(2877);

            var tracker = new MileageTracker(10000, 105);

            var actualMileage = tracker.GetMileageFromNumberOfDays();

            Assert.AreEqual(expectedMileage, actualMileage);
        }
    }

    public class MileageTracker
    {
        private readonly DailyMileage _dailyMiles = new DailyMileage(0.0, 0);

        public MileageTracker(double allowedMileage, int numberOfDays)
        {
            _dailyMiles.Add(new DailyMileage(allowedMileage, numberOfDays));
        }


        public int GetMileageFromDate(DateTime dateTime)
        {
            return 100;
        }

        public Mileage GetMileageFromNumberOfDays()
        {
            return _dailyMiles.CalculateMileage();
        }
    }


    public class DailyMileage : Mileage
    {
        private int _daysElapsed = 0;

        public DailyMileage(double miles, int daysElapsed): base(miles)
        {
            _daysElapsed = daysElapsed;
        }

        private double CalculateDailyMileageRate()
        {
            return this._miles/365;
        }

        public DailyMileage Add(DailyMileage dMileage)
        {
            base.Add(dMileage);

            _daysElapsed += dMileage._daysElapsed;

            return this;
        }

        public Mileage CalculateMileage()
        {
            var dailyMileageRate = CalculateDailyMileageRate();

            return new Mileage(_daysElapsed*dailyMileageRate);
        }
    }
}
