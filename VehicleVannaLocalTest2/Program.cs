using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace VehicleVannaLocalTest2
{
    class Program
    {
        static async Task Main(string[] args)
        {


            //menu
            string FirstName;
            string LastName;
            string Make;
            string Model;
            int Year;
            string Type;
            string BuyerEmail;
            double ListPrice;
            double PurchasePrice;

            Console.WriteLine("Enter a First Name: ");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter a Last Name: ");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter an email: ");
            BuyerEmail = Console.ReadLine();
            Console.WriteLine("Enter a vehicle type: ");
            Type = Console.ReadLine();
            Console.WriteLine("Enter a vehicle model: ");
            Model = Console.ReadLine();
            Console.WriteLine("Enter a vehicle make: ");
            Make = Console.ReadLine();
            Console.WriteLine("Enter a vehicle year: ");
            Year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a list price: ");
            ListPrice = Convert.ToDouble(Console.ReadLine());


            //FirstName = "Mac";
            //LastName = "Murph";
            //BuyerEmail = "macmurp";
            //Type = "Car";
            //Model = "testmodel";
            //Make = "testmake";
            //Year = 2000;
            //ListPrice = 20500.50;
            //automated entry for testing

            PurchasePrice = (ListPrice - (ListPrice * 0.085));
            //discount calculated


            Vehicle vehicle = new Vehicle(Make, Model, Year, ListPrice, PurchasePrice, FirstName, LastName, BuyerEmail, Type);
            //creation to pass to url

            //string url = "http://localhost:7071/api/RunVehicleVanna";
            //local string
            string url = "https://azurevehiclevanna220210228131318.azurewebsites.net/api/RunVehicleVanna?code=WzTKEnEAiWPpu2ZAy0I0MN7wEyoOpps7aK0hht4gAxFsZ8tuzb6V0g==";
            var client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(url, vehicle);
            Console.WriteLine(response);


        }
    }
}
