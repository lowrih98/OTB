using System.Diagnostics;

namespace OTBAssessment
{
    class SearchService
    {
        public static List<FlightHotelPair> FindAllResults(SearchCriteria searchCriteria, List<FlightHotelPair> flightHotelPairs, Enums.ResultOrdering resultOrdering = Enums.ResultOrdering.PriceAscending)
        {
            var parsedDepartureCodes = ParseAirportCodes(searchCriteria.DepartingFrom);
            var parsedArrivalCodes = ParseAirportCodes(searchCriteria.TravellingTo);

            var results = flightHotelPairs.Where(p => parsedDepartureCodes.Contains(p.Flight.DepartingFrom)
                                                    && parsedArrivalCodes.Contains(p.Flight.ArrivingIn)
                                                    && p.Flight.DepatureDate == searchCriteria.DepatureDate
                                                    && p.Hotel.Nights == searchCriteria.NightsStaying)
                                                .ToList();

            switch(resultOrdering)
            {
                case Enums.ResultOrdering.PriceAscending:
                    results = results.OrderBy(r => r.TotalPrice).ToList();
                    break;
                case Enums.ResultOrdering.PriceDescending:
                    results = results.OrderByDescending(r => r.TotalPrice).ToList();
                    break;
                case Enums.ResultOrdering.HotelAlphabeticalAscending:
                    results = results.OrderBy(r => r.Hotel.Name).ToList();
                    break;
                case Enums.ResultOrdering.HotelAlphabeticalDescending:
                    results = results.OrderByDescending(r => r.Hotel.Name).ToList();
                    break;
                default:
                    throw new Exception($"Search entered with incorrect results ordering criteria {resultOrdering}.");
            }

            return results;
        }

        //for a use case where we haven't loaded the data before calling the method
        public static List<FlightHotelPair> FindAllResults(SearchCriteria searchCriteria, Enums.ResultOrdering resultOrdering = Enums.ResultOrdering.PriceAscending)
        {
            var hotelsJsonLocation = JsonFileImports.HotelsJson;
            var flightsJsonLocation = JsonFileImports.FlightsJson;
            var hotelsJsonExists = File.Exists(hotelsJsonLocation);
            var hotelsJsonIsJson = Path.GetExtension(hotelsJsonLocation) == ".json";

            var flightsJsonExists = File.Exists(flightsJsonLocation);
            var flightsJsonIsJson = Path.GetExtension(flightsJsonLocation) == ".json";

            if (!(hotelsJsonExists && hotelsJsonIsJson)) throw new Exception("Issue with finding hotels json file. Please investigate!");
            if (!(flightsJsonExists && flightsJsonIsJson)) throw new Exception("Issue with finding flights json file. Please investigate!");

            var hotels = JsonImporter.ImportHotels(hotelsJsonLocation);
            var flights = JsonImporter.ImportFlights(flightsJsonLocation);
            AirportsData.GetAllAirports(flights);

            var flightHotelPairs = FlightHotelMatchingService.MatchFlightsAndHotels(flights, hotels);

            return FindAllResults(searchCriteria, flightHotelPairs, resultOrdering);
        }

        private static List<string> ParseAirportCodes(string inputString)
        {
            var parsedCodes = new List<string>();

            if (inputString.Length == 3)
            {
                parsedCodes.Add(inputString);
            }
            else if (inputString == AirportsData.LondonAirportsSearch)
            {
                parsedCodes = AirportsData.LondonAirports;
            }
            else if (inputString == AirportsData.AllAirportsSearch)
            {
                parsedCodes = AirportsData.AllAirports;
            }
            else
            {
                throw new Exception($"Invalid aiport search criteria \"{inputString}\"");
            }

            return parsedCodes;
        }
    }
}
