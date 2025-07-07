using Newtonsoft.Json;

namespace OTBAssessment
{
    class Hotel
    {
        private int id {  get; set; }
        private string name { get; set; }
        private string arrivalDate { get; set; }
        private int pricePerNight { get; set; }
        private List<string> airports { get; set; }
        private int nights { get; set; }

        private int totalPrice { get; set; }

        [JsonProperty("id")]
        public int Id { get { return id; }
            set 
            {
                if (id > 0) throw new InvalidOperationException("Cannot change id once defined!");
                else id = value;
            } 
        }
        [JsonProperty("name")]
        public string Name { get { return name; } set { name = value; } }
        [JsonProperty("arrival_date")]
        public string ArrivalDate { get { return arrivalDate; } set { arrivalDate = value; } }
        [JsonProperty("price_per_night")]
        public int PricePerNight { get { return pricePerNight; } 
            set { 
                pricePerNight = value;
                UpdateTotalPrice();
            } 
        }
        [JsonProperty("local_airports")]
        public List<string> Airports { get { return airports; } set { airports = value;  } }
        [JsonProperty("nights")]
        public int Nights { get { return nights; } 
            set { 
                nights = value;
                UpdateTotalPrice();
            } 
        }

        public int TotalPrice { get { return totalPrice; } }
        public void UpdateTotalPrice()
        {
            totalPrice = pricePerNight * nights;
        }
    }
}
