
//the plan:
//create flights object
//create hotels object
//match appropriate hotels and flights
//create search that looks through these matches
//please see attached diagram https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi0.wp.com%2Ftimoelliott.com%2Fblog%2Fwp-content%2Fuploads%2F2023%2F05%2Fdrawing-an-owl-scaled.jpg%3Fssl%3D1&f=1&nofb=1&ipt=89c884ea03dae63ebbcd61465e609a0a382800e37756979a28dc54aec2b9c5e5

//making a note for future reference that all provided flights depart from either MAN, LTN or LGW
//and there are no flights connecting these, so i'm not going to worry about transfers
//kiss principle :)
using System.Diagnostics;

namespace OTBAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            var hotelsJsonLocation = Utilities.JsonFileImports.HotelsJson;
            var flightsJsonLocation = Utilities.JsonFileImports.FlightsJson;

            Debug.WriteLine("Hello, On The Beach!");
            var hotelsJsonExists = File.Exists(hotelsJsonLocation);
            var hotelsJsonIsJson = Path.GetExtension(hotelsJsonLocation) == ".json";

            var flightsJsonExists = File.Exists(flightsJsonLocation);
            var flightsJsonIsJson = Path.GetExtension(flightsJsonLocation) == ".json";

            if (!(hotelsJsonExists && hotelsJsonIsJson)) throw new Exception("Issue with finding hotels json file. Please investigate!");
            if (!(flightsJsonExists && flightsJsonIsJson)) throw new Exception("Issue with finding flights json file. Please investigate!");

            var hotels = JsonImporter.JsonImporter.ImportHotels(hotelsJsonLocation);
            var flights = JsonImporter.JsonImporter.ImportFlights(flightsJsonLocation);
            Utilities.AirportsData.GetAllDepartureAirports(flights);

            Debug.WriteLine($"Loaded data for {hotels.Count} hotels and {flights.Count} flights from {Utilities.AirportsData.AllDepatureAirports.Count} airports.");

            var flightHotelPairs = MatchingService.FlightHotelMatchingService.MatchFlightsAndHotels(flights, hotels);

            Debug.WriteLine($"Generated {flightHotelPairs.Count} pairs of compatible flights and hotels.");
        }
    }
}
