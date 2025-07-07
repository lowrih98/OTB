using Xunit;
using OTBAssessment;

namespace OTBAssessment.Tests
{
    public class JsonImporterTests
    {
        [Fact]
        public void HotelsJsonExists()
        {
            var hotelsJsonExists = File.Exists(JsonFileImports.HotelsJson);
            var hotelsJsonExtension = Path.GetExtension(JsonFileImports.HotelsJson);

            Assert.True(hotelsJsonExists);
            Assert.Equal(".json", hotelsJsonExtension);
        }

        [Fact]
        public void FlightsJsonExists()
        {
            var flightsJsonExists = File.Exists(JsonFileImports.FlightsJson);
            var flightsJsonExtension = Path.GetExtension(JsonFileImports.FlightsJson);

            Assert.True(flightsJsonExists);
            Assert.Equal(".json", flightsJsonExtension);
        }

        [Fact]
        public void HotelsJsonLoadsCorrectly()
        {
            var hotels = JsonImporter.ImportHotels(JsonFileImports.HotelsJson);

            //correct number of results
            Assert.Equal(13, hotels.Count());
            //and in order
            for(var i = 0; i < hotels.Count(); i++) Assert.Equal(i+1, hotels[i].Id);

            //random data picked from json
            Assert.Equal("Iberostar Grand Portals Nous", hotels[0].Name);
            Assert.Equal("Sol Katmandu Park & Resort", hotels[3].Name);
            Assert.Equal("Boutique Hotel Cordial La Peregrina", hotels[7].Name);
            Assert.Equal("2022-11-05", hotels[1].ArrivalDate);
            Assert.Equal("2022-09-10", hotels[6].ArrivalDate);
            Assert.Equal("2023-10-16", hotels[10].ArrivalDate);
            Assert.Equal(60, hotels[4].PricePerNight);
            Assert.Equal(75, hotels[5].PricePerNight);
            Assert.Equal(45, hotels[9].PricePerNight);
            Assert.Contains("PMI", hotels[2].Airports);
            Assert.Single(hotels[2].Airports);
            Assert.Contains("AGP", hotels[11].Airports);
            Assert.Single(hotels[11].Airports);
            Assert.Equal(7, hotels[8].Nights);
            Assert.Equal(10, hotels[12].Nights);
        }

        [Fact]
        public void FlightsJsonLoadsCorrectly()
        {
            var flights = JsonImporter.ImportFlights(JsonFileImports.FlightsJson);

            //correct number of results
            Assert.Equal(12, flights.Count());
            //and in order
            for (var i = 0; i < flights.Count(); i++) Assert.Equal(i + 1, flights[i].Id);

            //random data picked from json
            //yes these are largely in the same order as the above unit test
            Assert.Equal("First Class Air", flights[0].Airline);
            Assert.Equal("Trans American Airlines", flights[3].Airline);
            Assert.Equal("MAN", flights[1].DepartingFrom);
            Assert.Equal("MAN", flights[6].DepartingFrom);
            Assert.Equal("LGW", flights[10].DepartingFrom);
            Assert.Equal("PMI", flights[4].ArrivingIn);
            Assert.Equal("PMI", flights[5].ArrivingIn);
            Assert.Equal("AGP", flights[9].ArrivingIn);
            Assert.Equal(170, flights[2].Price);
            Assert.Equal(202, flights[11].Price);
            Assert.Equal("2023-11-10", flights[7].DepatureDate);
            Assert.Equal("2023-04-11", flights[8].DepatureDate); // my 25th birthday!
        }
    }
}
