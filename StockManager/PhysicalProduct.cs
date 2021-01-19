using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    [System.Serializable]
    class PhysicalProduct : Product, IStorage
    {
        public float shipping;
        private int stock;

        public PhysicalProduct( string name, float price, float shipping)
        {
            this.name = name;
            this.price = price;
            this.shipping = shipping;
        }

        public void AddEntry()
        {
            Console.WriteLine($"Add entry in the storage of the product {name}");
            Console.WriteLine("Type the qnt of you want entry");
            int entry = int.Parse(Console.ReadLine());
            stock += entry;
            Console.WriteLine("Entry registered");
            Console.ReadLine();
        }

        public void AddLeft()
        {
            Console.WriteLine($"Add left in the storage of the product {name}");
            Console.WriteLine("Type the qnt of you want remove");
            int entry = int.Parse(Console.ReadLine());
            stock -= entry;
            Console.WriteLine("Left registered");
            Console.ReadLine();


        }

        public void Show()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Price: ${price}");
            Console.WriteLine($"Delivery cost: ${shipping}");
            Console.WriteLine($"Stock: {stock}");
            Console.WriteLine("=========================================");
        }
    }
}
