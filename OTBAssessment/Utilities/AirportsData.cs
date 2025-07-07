namespace OTBAssessment
{
    class AirportsData
    {
        public static List<string> LondonAirports = ["LTN", "LGW"];
        public static List<string> AllAirports;

        public static string LondonAirportsSearch = "Any London Airport";
        public static string AllAirportsSearch = "Any Airport";

        public static void GetAllAirports(List<Flight> flights)
        {
            AllAirports = flights.Select(f => f.DepartingFrom).Distinct().
                                    Concat(flights.Select(f => f.ArrivingIn).Distinct())
                                    .ToList();
        }
    }
}
