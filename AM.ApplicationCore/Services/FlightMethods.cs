using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight> {};

        public Action<Plane> FlightDetailsDel;

        public Func<string,double> DurationAverageDel;

        public FlightMethods()
        {

            //DurationAverageDel = DurationAverage;

            FlightDetailsDel = plane =>
            {
                var flightDetails = Flights.Where(f => f.Plane.Equals(plane))
                                       .Select(f => new { f.FlightDate, f.Destination });

                foreach (var detail in flightDetails)
                {
                    Console.WriteLine($"Destination: {detail.Destination}, Date: {detail.FlightDate}");
                }
            };
        
            DurationAverageDel = destination =>
            {
                var query = Flights.Where(flight => flight.Destination == destination)
                         .Select(flight => flight.EstimatedDuration);
                return query.Average();
            };
        }



        //public List<DateTime> GetFlightDates(string destination)
        //{
        //    List<DateTime> Flightdates = new List<DateTime> { };
        //    //for(int i = 0; i < Flights.Count; i++)
        //    //{
        //    //    if (Flights[i].Destination == destination)
        //    //    {
        //    //        Flightdates.Add(Flights[i].FlightDate);
        //    //    }
        //    //}
        //    foreach (Flight flight in Flights)
        //    {
        //        if (flight.Destination == destination)
        //        {
        //            Flightdates.Add(flight.FlightDate);
        //        }
        //    }
        //    return Flightdates;
        //}


        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> filteredFlights = new List<Flight> { };

            foreach (Flight flight in Flights)
            {
                switch (filterType)
                {
                    case "Destination":
                        if (flight.Destination == filterValue)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;
                    case "Departure":
                        if (flight.Departure == filterValue)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;
                    case "EffectiveArrival":
                        if (flight.EffectiveArrival.ToString() == filterValue)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;
                    case "EstimatedDuration":
                        if (flight.EstimatedDuration.ToString() == filterValue)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;
                    case "FlightDate":
                        if (flight.FlightDate.ToString() == filterValue)
                        {
                            filteredFlights.Add(flight);
                        }
                        break;
                   
                }
            }
            return filteredFlights;
        }


        public List<DateTime> GetFlightDates(string destination)
        {
            var flightDates = Flights.Where(flight => flight.Destination.Equals(destination))
                                     .Select(flight => flight.FlightDate)
                                     .ToList();
            return flightDates;

            //return Flights.Where(flight => flight.Destination.Equals(destination))
            //              .Select(flight => flight.FlightDate)
            //              .ToList();
        }



        public void ShowFlightDetails(Plane plane)
        {
            var flightDetails = Flights.Where(f => f.Plane.Equals(plane))
                                       .Select(f => new { f.FlightDate, f.Destination });

            foreach (var detail in flightDetails)
            {
                Console.WriteLine($"Destination: {detail.Destination}, Date: {detail.FlightDate}");
            }
        }


        public int ProgrammedFlightNumber(DateTime startDate)
        { 
            var query = from flight in Flights
                        where flight.FlightDate == startDate.AddDays(7)
                        select flight;
            return query.Count();
        }

        public double DurationAverage(string destination)
        {
            var query = Flights.Where (flight=>flight.Destination == destination)
                        .Select(flight=>flight.EstimatedDuration);
            return query.Average();
        }

        //public IList<Flight> OrderedDurationFlights()
        //{
        //    var query = Flights.OrderByDescending(flight => flight.EstimatedDuration);
        //    return query.ToList();
        //}

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            return from f in Flights orderby f.EstimatedDuration descending select f;
        }


        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            return flight.Passengers.OfType<Traveller>()
                   .OrderBy(p => p.BirthDate).Take(3).ToList();
                   
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query = Flights.GroupBy(flight => flight.Destination);
            foreach (var f in query)
            {
                Console.WriteLine("Destination : "+f.Key);
                foreach (var d in f)
                {
                    Console.WriteLine("Décollage : "+d.FlightDate );
                }
            }
            return query;

        }





    }
}
