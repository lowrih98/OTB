namespace OTBAssessment
{
    class SearchCriteria
    {
        public SearchCriteria(string departingFrom, string travellingTo, string departureDate, int nightsStaying, Enums.ResultOrdering resultOrdering = Enums.ResultOrdering.PriceAscending) 
        {
            _departingFrom = departingFrom;
            _travellingTo = travellingTo;
            _departureDate = departureDate;
            _nightsStaying = nightsStaying;
            _resultOrdering = resultOrdering;
        }

        private string _departingFrom { get; set; }
        private string _travellingTo { get; set; }
        private string _departureDate { get; set; }
        private int _nightsStaying { get; set; }
        private Enums.ResultOrdering _resultOrdering { get; set; }

        public string DepartingFrom { get { return _departingFrom; }  }
        public string TravellingTo { get { return _travellingTo; } }
        public string DepatureDate { get { return _departureDate; } }
        public int NightsStaying { get { return _nightsStaying; } }
        public Enums.ResultOrdering ResultOrdering { get { return _resultOrdering; } }
    }
}
