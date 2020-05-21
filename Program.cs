using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClientDatabase
{
    public class Client
    {
        public string Fname;
        public string Lname;
        public string DesiredLocation;
        public int HoursWorked;
        
        public Client(string Fname, string Lname, string Location, int HoursWorked)
        {
            this.Fname = Fname;
            this.Lname = Lname;
            this.DesiredLocation = Location;
            this.HoursWorked = HoursWorked;
        }
    }

    public class HomeBuyer : Client
    {
        public float MaxPricePoint;

        public HomeBuyer(string Fname, string Lname, string DesiredLocation, int HoursWorked, float MaxPrice) : base(Fname, Lname, DesiredLocation, HoursWorked)
        {
            base.Fname = Fname;
            base.Lname = Lname;
            base.DesiredLocation = DesiredLocation;
            base.HoursWorked = HoursWorked;
            this.MaxPricePoint = MaxPrice;
        }

    }

    public class Renter : Client
    {
        public float MaxMonthlyRent;

        public Renter(string Fname, string Lname, string DesiredLocation, int HoursWorked, float MaxMonthlyRent) : base(Fname, Lname, DesiredLocation, HoursWorked)
        {
            base.Fname = Fname;
            base.Lname = Lname;
            base.DesiredLocation = DesiredLocation;
            base.HoursWorked = HoursWorked;
            this.MaxMonthlyRent = MaxMonthlyRent;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
