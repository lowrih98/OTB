using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTBAssessment.Objects;

namespace OTBAssessment.MatchingService
{
    class FlightHotelMatchingService
    {
        public static List<FlightHotelPair> MatchFlightsAndHotels(List<Flight> flights, List<Hotel> hotels)
        {
            var pairs = new List<FlightHotelPair>();
            //is this foreach the most efficient way to do this? could i filter by airports or dates?
            //revisit
            foreach (var flight in flights)
            {
                var relevantHotels = hotels.Where(h => h.ArrivalDate == flight.DepatureDate && h.Airports.Contains(flight.ArrivingIn));
                foreach(var hotel in relevantHotels)
                {
                    pairs.Add(new FlightHotelPair
                    {
                        Flight = flight,
                        Hotel = hotel,
                    });
                }
            }
            return pairs;
        }
    }
}
