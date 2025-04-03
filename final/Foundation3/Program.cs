class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("200 Arthur Ashe Stadium", "Flushing", "NY", "USA");
        Address address2 = new Address("1 Tennis Blvd", "Palm Beach Gardens", "FL", "USA");
        Address address3 = new Address("78-200 Miles Ave", "Indian Wells", "CA", "USA");

        Event lecture = new Lecture(
            "The US Open",
            "A behind the scenes talk about the biggest tennis tournament in America.",
            "08/25/2025",
            "3:00 PM",
            address1,
            "Billie Jean King",
            300);

        Event reception = new Reception(
            "Meet the Pros",
            "An intimate reception with current and former American tennis stars.",
            "09/10/2025",
            "6:30 PM",
            address2,
            "rsvp@ustennisfanclub.com");

        Event outdoor = new OutdoorGathering(
            "Indian Wells Tennis Bash",
            "Outdoor tennis games, live matches, and food trucks for all ages.",
            "10/05/2025",
            "11:00 AM",
            address3,
            "Clear skies, 78°F");

        List<Event> events = new List<Event> { lecture, reception, outdoor };

        foreach (Event evt in events)
        {
            Console.WriteLine("---- Standard Details ----");
            Console.WriteLine(evt.GetStandardDetails());
            Console.WriteLine("\n---- Full Details ----");
            Console.WriteLine(evt.GetFullDetails());
            Console.WriteLine("\n---- Short Description ----");
            Console.WriteLine(evt.GetShortDescription());
            Console.WriteLine("\n-----------------------------\n");
        }
    }
}
