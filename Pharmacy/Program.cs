using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    public class PharmacyData
    {
        private string medicineName;
        private double price;
        private int quantity;
        private string dateExpired;
        public string MedicineName 
        {
            get 
            {
                return medicineName; 
            }
            set
            {
                medicineName = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }
        public string DateExpired
        {
            get
            {
                return dateExpired;
            }
            set
            {
                if (value.Length<4) 
                {
                    throw new ArgumentNullException("Not valid input for expiration date"); 
                }
                dateExpired = value;

            }
            

        }
        public PharmacyData(string medicineName, double price)
        {
            this.MedicineName = medicineName;
            this.Price = price;
            this.Quantity = 0;
            this.DateExpired = "Not entered";
        }
        public PharmacyData(string medicineName, double price, int quantity,string dateExpired)
        {
            this.quantity=quantity;
            this.dateExpired=dateExpired;
            this.MedicineName=medicineName;
            this.Price = price;
        }
        public void Print()
        {
            Console.WriteLine("Name: "+this.medicineName);
            Console.WriteLine("Price: " + this.price);
            Console.WriteLine("Quantity: " + this.quantity);
            Console.WriteLine("Date Expired: " + this.dateExpired);
            Console.WriteLine();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PharmacyData analgin = new PharmacyData("Analgin", 2.5);
                analgin.Print();
                Console.Write("Enter count of medicine: ");
                int n = int.Parse(Console.ReadLine());
                List<PharmacyData> list = new List<PharmacyData>();
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{i + 1} Enter medicine name: ");
                    string name = Console.ReadLine();
                    Console.Write($"{i + 1} Enter price: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write($"{i + 1} Enter quantity: ");
                    int quantity = int.Parse(Console.ReadLine());
                    Console.Write($"{i + 1} Enter date of expiration: ");
                    string date = Console.ReadLine();
                    list.Add(new PharmacyData(name, price, quantity, date));
                }
                list.ForEach(x => x.Print());
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                //ako cenata e nad 5lv
                list.Where(x => x.Price > 5).ToList().ForEach(x => x.Print());
                //po srok na godnost
                Console.ForegroundColor = ConsoleColor.Cyan;
                list=list.OrderBy(x => x.DateExpired).ToList();
                list[0].Print();

                //sortira po ime
                Console.ForegroundColor = ConsoleColor.White;
                list.OrderBy(x => x.MedicineName).ToList().ForEach(x => x.Print());
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
