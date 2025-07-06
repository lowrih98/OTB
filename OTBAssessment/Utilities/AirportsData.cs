using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OTBAssessment.Objects;

namespace OTBAssessment.Utilities
{
    class AirportsData
    {
        public static List<string> LondonAirports = ["LTN", "LGW"];
        public static List<string> AllDepatureAirports;

        public static void GetAllDepartureAirports(List<Flight> flights)
        {
            AllDepatureAirports = flights.Select(f => f.DepartingFrom).Distinct().ToList();
        }
    }
}
