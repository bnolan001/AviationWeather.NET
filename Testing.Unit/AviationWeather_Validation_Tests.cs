using BNolan.AviationWx.NET;
using BNolan.AviationWx.NET.Connectors;
using BNolan.AviationWx.NET.Models.Enums;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Testing.Unit
{
    public class AviationWeather_Validation_Tests
    {
        public AviationWeather _aviationWeather;

        [SetUp]
        public void Setup()
        {
            var connector = new Mock<IConnector>();
            connector.Setup(conn => conn.GetAsync(String.Empty)).Returns(Task.FromResult(""));
            _aviationWeather = new AviationWeather(ParserType.CSV, connector.Object);
        }

        #region GetForecastsInBox

        [Test]
        public void GetForecastsInBox_InValid_MinLat()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInBoxAsync(0, 0, 0, -91, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetForecastsInBox_InValid_MaxLat()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInBoxAsync(0, 0, 91, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetForecastsInBox_InValid_MinLon()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInBoxAsync(0, -181, 0, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetForecastsInBox_InValid_MaxLon()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInBoxAsync(181, 0, 0, 0, 0).Wait();
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
                _aviationWeather.GetForecastsInRadialAsync(0, 0, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetForecastsInRadial_InValid_Lat()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInRadialAsync(0, -91, 1, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetForecastsInRadial_InValid_Lon()
        {
            Action a = () =>
            {
                _aviationWeather.GetForecastsInRadialAsync(181, 0, 1, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion GetForecastsInRange

        #region GetStationsInBoxAsync

        [Test]
        public void GetStationsInBoxAsync_InValid_One_MinLat()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(-91, 0, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetStationsInBoxAsync_InValid_One_MaxLat()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(91, 0, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }
        [Test]
        public void GetStationsInBoxAsync_InValid_Two_MinLat()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(0, 0, -91, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetStationsInBoxAsync_InValid_Two_MaxLat()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(0, 0, 91, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetStationsInBoxAsync_InValid_One_MinLon()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(0, -181, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetStationsInBoxAsync_InValid_One_MaxLon()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(0, 181, 0, 0).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetStationsInBoxAsync_InValid_Two_MinLon()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(0, 0, 0, -181).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetStationsInBoxAsync_InValid_Two_MaxLon()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(0, 0, 0, 181).Wait();
            };

            a.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetStationsInBoxAsync_Valid_MinLat()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(0, 0, 0, -90).Wait();
            };

            a.Should().NotThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetStationsInBoxAsync_Valid_MaxLat()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(0, 0, 90, 0).Wait();
            };

            a.Should().NotThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetStationsInBoxAsync_Valid_MinLon()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(0, -180, 0, 0).Wait();
            };

            a.Should().NotThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void GetStationsInBoxAsync_Valid_MaxLon()
        {
            Action a = () =>
            {
                _aviationWeather.GetStationsInBoxAsync(18, 0, 0, 0).Wait();
            };

            a.Should().NotThrow<ArgumentOutOfRangeException>();
        }

        #endregion GetStationInfoInBox
    }
}
