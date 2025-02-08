﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public int PlaneFK { get; set; }
        public Plane Plane { get; set; }
        public ICollection<Passenger> Passengers { get; set; }


        public override string ToString()
        {
            return $"Departure : {Departure} - Destination: {Destination} - EffectiveArrival : {EffectiveArrival} - " +
                $"EstimatedDuration : {EstimatedDuration}";
        }
    }
}
