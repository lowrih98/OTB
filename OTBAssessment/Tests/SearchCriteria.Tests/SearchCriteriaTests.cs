using Xunit;

namespace OTBAssessment.Tests
{
    public class SearchCriteriaTests
    {
        Flight sampleFlight;
        Hotel sampleHotel;
        List<FlightHotelPair> singleTestPair;

        public SearchCriteriaTests() 
        {
            sampleFlight = new Flight
            {
                Id = 1,
                Airline = "Lowri Air",
                DepartingFrom = "MAN",
                ArrivingIn = "CWL",
                Price = 50,
                DepatureDate = "2025-07-06"
            };
            sampleHotel = new Hotel
            {
                Id = 1,
                Name = "My Auntie's House",
                ArrivalDate = "2025-07-06",
                PricePerNight = 0,
                Airports = ["CWL"],
                Nights = 7
            };

            singleTestPair = FlightHotelMatchingService.MatchFlightsAndHotels([sampleFlight], [sampleHotel]);
        }

        [Fact]
        public void InvalidDepartureCode()
        {
            var searchCriteria = new SearchCriteria("AAA", "CWL", "2025-07-06", 7); 
            var results = SearchService.FindAllResults(searchCriteria, singleTestPair);
            Assert.Empty(results);
        }

        [Fact]
        public void InvalidArrivalCode()
        {
            var searchCriteria = new SearchCriteria("MAN", "ZZZ", "2025-07-06", 7);
            var results = SearchService.FindAllResults(searchCriteria, singleTestPair);
            Assert.Empty(results);
        }

        [Fact]
        public void CorrectSamplePairSearch()
        {
            var searchCriteria = new SearchCriteria("MAN", "CWL", "2025-07-06", 7);
            var results = SearchService.FindAllResults(searchCriteria, singleTestPair);
            Assert.Single(results);

            var firstResult = results[0];
            Assert.Equal(50, firstResult.TotalPrice);
            Assert.Equal(sampleFlight, firstResult.Flight);
            Assert.Equal(sampleHotel, firstResult.Hotel);
        }

        [Fact]
        public void ExampleTestCaseOne()
        {
            var searchCriteria = new SearchCriteria("MAN", "AGP", "2023-07-01", 7);
            var results = SearchService.FindAllResults(searchCriteria);
            Assert.Single(results);

            var firstResult = results[0];
            Assert.Equal(2, firstResult.Flight.Id);
            Assert.Equal(9, firstResult.Hotel.Id);
        }

        [Fact]
        public void ExampleTestCaseTwo()
        {
            var searchCriteria = new SearchCriteria("Any London Airport", "PMI", "2023-06-15", 10);
            var results = SearchService.FindAllResults(searchCriteria);
            Assert.Equal(4, results.Count);

            var firstResult = results[0];
            Assert.Equal(6, firstResult.Flight.Id);
            Assert.Equal(5, firstResult.Hotel.Id);
        }

        [Fact]
        public void ExampleTestCaseTwoButAlphabeticalOrdering()
        {
            var searchCriteria = new SearchCriteria("Any London Airport", "PMI", "2023-06-15", 10);
            var results = SearchService.FindAllResults(searchCriteria, Enums.ResultOrdering.HotelAlphabeticalAscending);
            Assert.Equal(4, results.Count);

            var firstResult = results[0];
            Assert.Equal(4, firstResult.Flight.Id);
            Assert.Equal(13, firstResult.Hotel.Id);
        }

        [Fact]
        public void ExampleTestCaseThree()
        {
            var searchCriteria = new SearchCriteria("Any Airport", "LPA", "2022-11-10", 14);
            var results = SearchService.FindAllResults(searchCriteria);
            Assert.Single(results);

            var firstResult = results[0];
            Assert.Equal(7, firstResult.Flight.Id);
            Assert.Equal(6, firstResult.Hotel.Id);
        }


    }
}
