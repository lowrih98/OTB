
//the plan:
//create flights object
//create hotels object
//match appropriate hotels and flights
//create search that looks through these matches
//please see attached diagram https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fi0.wp.com%2Ftimoelliott.com%2Fblog%2Fwp-content%2Fuploads%2F2023%2F05%2Fdrawing-an-owl-scaled.jpg%3Fssl%3D1&f=1&nofb=1&ipt=89c884ea03dae63ebbcd61465e609a0a382800e37756979a28dc54aec2b9c5e5

//making a note for future reference that all provided flights depart from either MAN, LTN or LGW
//and there are no flights connecting these, so i'm not going to worry about transfers
//kiss principle :)
namespace OTBAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, On The Beach!");
            var hotelsJsonExists = File.Exists(Utilities.JsonFileImports.HotelsJson);
            var hotelsJsonIsJson = Path.GetExtension(Utilities.JsonFileImports.HotelsJson) == ".json";

            var flightsJsonExists = File.Exists(Utilities.JsonFileImports.FlightsJson);
            var flightsJsonIsJson = Path.GetExtension(Utilities.JsonFileImports.FlightsJson) == ".json";

            if (!(hotelsJsonExists && hotelsJsonIsJson)) throw new Exception("Issue with finding hotels json file. Please investigate!");
            if (!(flightsJsonExists && flightsJsonIsJson)) throw new Exception("Issue with finding flights json file. Please investigate!");
        }
    }
}
