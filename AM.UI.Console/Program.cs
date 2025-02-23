// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

//Console.WriteLine("Hello, World!");

//TP1
//Plane plane = new Plane();
//plane.Capacity = 100;
//plane.ManufactureDate = DateTime.Now;
//plane.PlaneType = PlaneType.Airbus;

//Plane plane2 = new Plane(200, DateTime.Now, PlaneType.Boeing);

//Plane plane3 = new Plane
//{
//    Capacity = 300,
//    ManufactureDate = new DateTime(2024,05,02),
//    PlaneType = PlaneType.Airbus
//};

//Console.WriteLine("Plane 1 : " + plane);
//Console.WriteLine("Plane 2 : " + plane2);
//Console.WriteLine("Plane 3 : " + plane3);

//Console.WriteLine(" ");

Passenger passenger = new Passenger
{
    FirstName = "Noussa",
    LastName = "Kaabi",
    EmailAddress = "nousseiba.kaabi@esprit.tn"
};

//Console.WriteLine("Passenger 1 : " + passenger.CheckProfile("Noussa", "Kaabi"));
//Console.WriteLine("Passenger 2 : " + passenger.CheckProfile("Noussa", "Kaabi", "nousseiba.kaabi@esprit.n"));
//Console.WriteLine(" ");

//passenger.PassengerType();
//Console.WriteLine(" ");

//Staff staff = new Staff();
//staff.PassengerType();
//Console.WriteLine(" ");

//Traveller traveller = new Traveller();
//traveller.PassengerType();
//Console.WriteLine(" ");



//TP2
FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;
//foreach (var flight in fm.GetFlightDates("Paris"))
//{
//    Console.WriteLine(flight);
//}

//foreach (var flight in fm.GetFlights("Destination", "Lisbonne"))
//{
//    Console.WriteLine(flight);
//}


//fm.ShowFlightDetails(TestData.BoingPlane);

Console.WriteLine("ProgrammedFlightNumber : " + fm.ProgrammedFlightNumber(new DateTime(2022, 02, 01, 21, 10, 10)));
Console.WriteLine("  ");

Console.WriteLine("DurationAverage : " + fm.DurationAverage("Paris"));
Console.WriteLine("  ");

Console.WriteLine("OrderedDurationFlights : ");
foreach (var flight in fm.OrderedDurationFlights())
{
    Console.WriteLine(flight);
}
Console.WriteLine("  ");
Console.WriteLine("SeniorTravellers : " );
foreach (var p in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(p.BirthDate);
}
Console.WriteLine("  ");

fm.DestinationGroupedFlights();

Console.WriteLine("  ");
Console.WriteLine("ShowFlightDetails : ");
fm.FlightDetailsDel(TestData.BoingPlane);

passenger.UpperFullName();