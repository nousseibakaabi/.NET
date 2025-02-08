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




    }
}
