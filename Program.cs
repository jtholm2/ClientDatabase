using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public void PrintFullName()
        {
            Console.WriteLine(this.Fname + " " + this.Lname);
        }

        public void PrintHoursWorked()
        {
            Console.WriteLine("You have worked " + this.HoursWorked + " for " + this.Fname + " " + this.Lname);
        }

        public string GetLastName()
        {
            return this.Lname;
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

        public void InsertIntoHomeBuyersTable()
        {
            SqlConnection conn = new SqlConnection("Data Source={insert DB url here}; Initial Catalog={insert db name here}; User ID={insert username here}; Password={insert password here}");
            conn.Open();
            string query = String.Format("INSERT INTO [insert table name here] (Fname,Lname,DesiredLocation,HoursWorked,MaxPricePoint) VALUES({0},{1},{2},{3},{4})", base.Fname, base.Lname, base.DesiredLocation, base.HoursWorked, this.MaxPricePoint);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateHoursWorked(int hours)
        {
            SqlConnection conn = new SqlConnection("Data Source={insert DB url here}; Initial Catalog={insert db name here}; User ID={insert username here}; Password={insert password here}");
            conn.Open();
            base.HoursWorked += hours;
            string query = String.Format("UPDATE [insert table name here] SET HoursWorked = {0} WHERE Lname = {1}", base.HoursWorked, base.Lname);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
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

        public void InsertIntoRentersTable()
        {
            SqlConnection conn = new SqlConnection("Data Source={insert DB url here}; Initial Catalog={insert db name here}; User ID={insert username here}; Password={insert password here}");
            conn.Open();
            string query = String.Format("INSERT INTO [insert table name here] (Fname,Lname,DesiredLocation,HoursWorked,MaxMonthlyRent) VALUES({0},{1},{2},{3},{4})", base.Fname, base.Lname, base.DesiredLocation, base.HoursWorked, this.MaxMonthlyRent);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateHoursWorked(int hours)
        {
            SqlConnection conn = new SqlConnection("Data Source={insert DB url here}; Initial Catalog={insert db name here}; User ID={insert username here}; Password={insert password here}");
            conn.Open();
            base.HoursWorked += hours;
            string query = String.Format("UPDATE [insert table name here] SET HoursWorked = {0} WHERE Lname = {1}", base.HoursWorked, base.Lname);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }

    class UserInterface
    {
        private List<Client> clients;

        public UserInterface()
        {
            this.clients = new List<Client>();
        }
        public void start()
        {
            Console.WriteLine("Hello! What would you like to do today?");
            while (true)
            {
                Console.WriteLine("Please enter the number corresponding to your selection");
                Console.WriteLine("1. Enter a new client\n2. Update hours worked for a client\n3. Exit the program");
                string selection = Console.ReadLine();
                if (selection.Equals("3"))
                {
                    break;
                }
                else if (selection.Equals("1"))
                {
                    Console.WriteLine("Is your client a:\n   1. Home buyer\n   2. Renter");
                    string userChoice = Console.ReadLine();
                    if (userChoice.Equals("1"))
                    {
                        Console.WriteLine("Enter their first name: ");
                        string FName = Console.ReadLine();
                        Console.WriteLine("Enter their second name: ");
                        string Lname = Console.ReadLine();
                        Console.WriteLine("Enter their desired location: ");
                        string location = Console.ReadLine();
                        Console.WriteLine("Enter number of hours worked so far: ");
                        int hours = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter their max price point: ");
                        float maxPrice = float.Parse(Console.ReadLine());
                        HomeBuyer test = new HomeBuyer(FName, Lname, location, hours, maxPrice);
                        this.clients.Add(test);
                        test.InsertIntoHomeBuyersTable();
                    }
                    else if (userChoice.Equals("2"))
                    {
                        Console.WriteLine("Enter their first name: ");
                        string FName = Console.ReadLine();
                        Console.WriteLine("Enter their second name: ");
                        string Lname = Console.ReadLine();
                        Console.WriteLine("Enter their desired location: ");
                        string location = Console.ReadLine();
                        Console.WriteLine("Enter number of hours worked so far: ");
                        int hours = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter their max monthly rent payment: ");
                        float maxRent = float.Parse(Console.ReadLine());
                        Renter test = new Renter(FName, Lname, location, hours, maxRent);
                        this.clients.Add(test);
                        test.InsertIntoRentersTable();
                    }
                }

                else if (selection.Equals("2"))
                {
                    Console.WriteLine("Enter the last name of the client you would like to add hours worked to: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter the number of hours worked since last update: ");
                    int hours = int.Parse(Console.ReadLine());
                    Console.WriteLine("Is your client wanting to buy or rent?");
                    string choice = Console.ReadLine();
                    if (choice.Equals("buy"))
                    {
                        foreach (HomeBuyer c in this.clients)
                        {
                            if (c.GetLastName().Equals(name))
                            {
                                c.UpdateHoursWorked(hours);
                                break;
                            }
                        }
                    }
                    else if (choice.Equals("rent"))
                    {
                        foreach(Renter r in this.clients)
                        {
                            r.UpdateHoursWorked(hours);
                        }
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface start = new UserInterface();
            start.start();
        }
    }
}
