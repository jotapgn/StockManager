using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager
{
    [System.Serializable]
    class Course : Product, IStorage
    {
        
        public string author;
        public int slots;

        public Course(string name, float price, string author)
        {
            this.name = name;
            this.price = price;
            this.author = author;
        }

        public void AddEntry()
        {
            Console.WriteLine($"Add slots in the course {name}");
            Console.WriteLine("Enter the number of course vacancies you want to add: ");
            int entry = int.Parse(Console.ReadLine());
            slots += entry;
            Console.WriteLine("Entry registered");
            Console.ReadLine();
        }

        public void AddLeft()
        {
            Console.WriteLine($"Add slots left in the course {name}");
            Console.WriteLine("Enter the number of course vacancies you want to removes: ");
            int entry = int.Parse(Console.ReadLine());
            slots -= entry;
            Console.WriteLine("Left registered");
            Console.ReadLine();

        }

        public void Show()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Price: ${price}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Slots left: {slots}");
            Console.WriteLine("=================================");
        }
    }
}
