﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public string Function { get; set; }
        public double Salary { get; set; }
        public DateTime EmployementDate { get; set; }
        public override string ToString()
        {
            return $"Function: {Function} - Salary : {Salary} - EmployementDate : {EmployementDate}";
        }



        public override void PassengerType()
        {   
            base.PassengerType();
            Console.WriteLine("I'm a staff member ");
        }
    }


}
