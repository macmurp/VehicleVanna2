using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleVannaLocalTest2
{
    public enum VehicleType
    {
        Car,
        SportsCar,
        Truck,
        Motorcycle,
        MotorHome
    }
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double ListPrice { get; set; }
        public double PurchasePrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BuyerEmail { get; set; }
        public VehicleType vehicleType { get; set; }
        public Vehicle(string make, string model, int year, double listprice, double purchaseprice, string first, string last, string buyeremail, string type)
        {
            Make = make;
            Model = model;
            Year = year;
            ListPrice = listprice;
            PurchasePrice = purchaseprice;
            FirstName = first;
            LastName = last;
            BuyerEmail = buyeremail;

            Enum.TryParse(type, out VehicleType v);
            vehicleType = v;
            //use string to set enum, if string doesn't match any option it defaults to Car
        }
    }
}
