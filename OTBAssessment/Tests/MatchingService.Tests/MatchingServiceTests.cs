using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTBAssessment.Objects;
using Xunit;

namespace OTBAssessment.MatchingService.Tests
{
    public class MatchingServiceTests
    {
        [Fact]
        public void OneCorrectMatch()
        {
            var flight = new Flight
            {
                Id = 1,
                Airline = "Lowri Air",
                DepartingFrom = "MAN",
                ArrivingIn = "CWL",
                Price = 50,
                DepatureDate = "2025-07-06"
            };
            var hotel = new Hotel
            {
                Id = 1,
                Name = "My Auntie's House",
                ArrivalDate = "2025-07-06",
                PricePerNight = 0,
                Airports = [ "CWL" ],
                Nights = 7
            };

            var testPair = FlightHotelMatchingService.MatchFlightsAndHotels([flight], [hotel]);
            Assert.NotNull(testPair);
            Assert.Equal(50, testPair.First().Price);
        }

        [Fact]
        public void OneIncorrectMatch_WrongAirport()
        {
            var flight = new Flight
            {
                Id = 1,
                Airline = "Lowri Air",
                DepartingFrom = "MAN",
                ArrivingIn = "EMA",
                Price = 50,
                DepatureDate = "2025-07-06"
            };
            var hotel = new Hotel
            {
                Id = 1,
                Name = "My Auntie's House",
                ArrivalDate = "2025-07-06",
                PricePerNight = 0,
                Airports = ["CWL"],
                Nights = 7
            };

            var testPair = FlightHotelMatchingService.MatchFlightsAndHotels([flight], [hotel]);
            Assert.Empty(testPair);
        }

        [Fact]
        public void OneIncorrectMatch_WrongDate()
        {
            var flight = new Flight
            {
                Id = 1,
                Airline = "Lowri Air",
                DepartingFrom = "MAN",
                ArrivingIn = "CWL",
                Price = 50,
                DepatureDate = "2025-07-06"
            };
            var hotel = new Hotel
            {
                Id = 1,
                Name = "My Auntie's House",
                ArrivalDate = "2025-07-07",
                PricePerNight = 0,
                Airports = ["CWL"],
                Nights = 7
            };

            var testPair = FlightHotelMatchingService.MatchFlightsAndHotels([flight], [hotel]);
            Assert.Empty(testPair);
        }

    }
}
