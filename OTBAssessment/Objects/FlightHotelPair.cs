namespace OTBAssessment
{
    class FlightHotelPair
    {
        private Flight flight { get; set; }
        private Hotel hotel { get; set; }
        private int totalPrice { get; set; }

        public Hotel Hotel { get { return hotel; } set {
                if(flight != null) VerifyAirportAndDate(value, flight);
                hotel = value;
                if (flight != null) UpdatePrice();
            } 
        }
        public Flight Flight { get { return flight; } set {
                if(hotel != null) VerifyAirportAndDate(hotel, value);
                flight = value;
                if (hotel != null) UpdatePrice();
            }
        }
        public int TotalPrice { get { return totalPrice; } }

        private void UpdatePrice()
        {
            totalPrice = flight.Price + hotel.TotalPrice;
        }
        private void VerifyAirportAndDate(Hotel hotel, Flight flight)
        {
            if (!hotel.Airports.Contains(flight.ArrivingIn)) throw new Exception($"Attempted to generate a Flight-Hotel pair with incompatible airports: Hotel {hotel.Id} ({hotel.Airports}) Flight {flight.Id} ({flight.ArrivingIn})");
            if (hotel.ArrivalDate != flight.DepatureDate) throw new Exception($"Attempted to generate a Flight-Hotel pair with incompatible dates: Hotel {hotel.Id} ({hotel.ArrivalDate}) Flight {flight.Id} ({flight.DepatureDate})");
        }

    }
}
