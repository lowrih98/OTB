﻿using Newtonsoft.Json;

namespace OTBAssessment
{
    class JsonImporter
    {
        public static List<Hotel> ImportHotels(string jsonFile)
        {
            var rawJsonData = File.ReadAllText(jsonFile);
            var hotelsList = JsonConvert.DeserializeObject<List<Hotel>>(rawJsonData);
            return hotelsList;
        }

        public static List<Flight> ImportFlights(string jsonFile)
        {
            var rawJsonData = File.ReadAllText(jsonFile);
            var flightsList = JsonConvert.DeserializeObject<List<Flight>>(rawJsonData);
            return flightsList;
        }

    }
}
