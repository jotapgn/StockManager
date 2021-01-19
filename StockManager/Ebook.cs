using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    [System.Serializable]
    class Ebook : Product, IStorage
    {
        public string author;
        private int sales;

        public Ebook(string name, float price, string author)
        {
            this.name = name;
            this.price = price;
            this.author = author;
        }

        public void AddEntry()
        {
            Console.WriteLine("Ebooks don´t have entry");
        }

        public void AddLeft()
        {
            Console.WriteLine($"Add sales in the ebook {name}");
            Console.WriteLine("Type the qnt of sales you want registered: ");
            int entry = int.Parse(Console.ReadLine());
            sales += entry;
            Console.WriteLine("Sales registered");
            Console.ReadLine();

        }

        public void Show()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Price: ${price}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Sale {sales}");
            Console.WriteLine("===================================");
        }
    }
}
