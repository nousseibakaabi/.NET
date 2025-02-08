using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public string TelNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return $"BirthDate {BirthDate} - EmailAddress: {EmailAddress} - FirstName{FirstName} - " +
                $"LastName{LastName}";
        }

        public Passenger() { }

        public Passenger(DateTime birthDate, string emailAddress, string firstName, string lastName, string passportNumber, string telNumber)
        {
            BirthDate = birthDate;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
            PassportNumber = passportNumber;
            TelNumber = telNumber;
        }

        //public bool CheckProfile(string firstname , string lastname) { 
        //    return FirstName == firstname && LastName == lastname; 
        //}

        //public bool CheckProfile(string firstname, string lastname , string email)
        //{
        //    return FirstName == firstname && LastName == lastname && EmailAddress ==email;
        //}


        public bool CheckProfile(string firstname, string lastname, string email=null)
        {
            if(email != null)
            return FirstName == firstname && LastName == lastname && EmailAddress == email;
            else return FirstName == firstname && LastName == lastname;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I'm Passenger");
        }

    }
}
