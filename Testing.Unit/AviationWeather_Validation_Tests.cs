using BNolan.AviationWx.NET;
using BNolan.AviationWx.NET.Models.Constants;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Testing.Unit
{
    public class AviationWeather_Validation_Tests
    {
        public AviationWeather _aviationWeather;

        [SetUp]
        public void Setup()
        {
            _aviationWeather = new AviationWeather(ParserType.XML);
        }

        #region GetForecastsInBox

        [Test]
        public void GetForecastsInBox_InValid_MinLat()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInBox(0, 0, 0, -91, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetForecastsInBox_InValid_MaxLat()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInBox(0, 0, 91, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetForecastsInBox_InValid_MinLon()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInBox(0, -181, 0, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetForecastsInBox_InValid_MaxLon()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInBox(181, 0, 0, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion GetForecastsInBox

        #region GetForecastsInRange

        [Test]
        public void GetForecastsInRadial_InValid_Radial()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInRadial(0, 0, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetForecastsInRadial_InValid_Lat()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInRadial(0, -91, 1, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetForecastsInRadial_InValid_Lon()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInRadial(181, 0, 1, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion GetForecastsInRange
    }
}
