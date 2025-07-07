using Newtonsoft.Json;

namespace OTBAssessment
{
    class Flight
    {
        private int id { get; set; }
        private string airline { get; set; }
        private string from { get; set; }
        private string to { get; set; }
        private int price { get; set; }
        private string departureDate { get; set; }

        [JsonProperty("id")]
        public int Id
        {
            get { return id; }
            set
            {
                if (id > 0) throw new InvalidOperationException("Cannot change id once defined!");
                else id = value;
            }
        }
        [JsonProperty("airline")]
        public string Airline { get { return airline; } set { airline = value; } }
        [JsonProperty("from")]
        public string DepartingFrom { get { return from; } set { from = value; } }
        [JsonProperty("to")]
        public string ArrivingIn { get { return to; } set { to = value; } }
        [JsonProperty("price")]
        public int Price { get { return price; } set { price = value; } }
        [JsonProperty("departure_date")]
        public string DepatureDate { get { return departureDate; } set { departureDate = value; } }
    }
}
