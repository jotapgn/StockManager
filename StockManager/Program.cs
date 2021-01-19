using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace StockManager
{
    class Program
    {
        static List<IStorage> products = new List<IStorage>();
        enum Menu { ListProd = 1, AddProd, DeleteProd, ProdEntry, LeftProd, Exit }
        static void Main(string[] args)
        {
            Load();
            bool choosenExit = false;
            while (!choosenExit)
            {
                Console.WriteLine("=== Welcome to the Stock Manager ===");
                Console.WriteLine("Select one of the options below: ");
                Console.WriteLine("1- List Productsz\n2- Add Product\n3- Delete Product\n4- Entry Products\n5- Products Left\n6- Exit");
                int option = int.Parse(Console.ReadLine());
                if (option > 0 && option < 7)
                {
                    Menu options = (Menu)option;
                    switch (options)
                    {
                        case Menu.ListProd:
                            Display();
                            break;
                        case Menu.AddProd:
                            Register();
                            break;
                        case Menu.DeleteProd:
                            DeleteProduct();
                            break;
                        case Menu.ProdEntry:
                            Entry();
                            break;
                        case Menu.LeftProd:
                            Left();
                            break;
                        case Menu.Exit:
                            choosenExit = true;
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("ERROR!!!! Please enter a valid option");
                    Console.WriteLine("Press ENTER to return to the menu");
                    Console.ReadLine();
                }

                Console.Clear();
            }

        }

        static void Display()
        {
            Console.WriteLine("=== List of Products ===");
            int i = 0;
            foreach(IStorage product in products)
            {
                Console.WriteLine($"ID: {i}");
                product.Show();
                i++;
            }
            Console.ReadLine();
        }

        static void DeleteProduct()
        {
            Display();
            Console.WriteLine("Enter the id you want to remove: ");
            int id = int.Parse(Console.ReadLine());
            if(id >=0 && id < products.Count)
            {
                products.RemoveAt(id);
                Save();
            }
        }
        static void Entry()
        {
            Display();
            Console.WriteLine("Enter the id you want to add entry: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < products.Count)
            {
                products[id].AddEntry();
                Save();
            }
        }
        static void Left()
        {
            Display();
            Console.WriteLine("Enter the id you want to add output to: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < products.Count)
            {
                products[id].AddLeft();
                Save();
            }
        }
        static void Register()
        {
            Console.WriteLine("=== Product Registration: ===");
            Console.WriteLine("1-Physical Products\n2-Ebook\n3-Course");
            int ProdOption = int.Parse(Console.ReadLine());
            switch (ProdOption)
            {
                case 1:
                    PhyscProdRegister();
                    break;
                case 2:
                    EbookRegister();
                    break;
                case 3:
                    CourserRegister();
                    break;
            }

             void PhyscProdRegister()
            {
                Console.WriteLine("=== Registering Physical Product ===");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Price: ");
                float price = float.Parse(Console.ReadLine());
                Console.WriteLine("Delivery Cost: ");
                float shipping = float.Parse(Console.ReadLine());
                PhysicalProduct physcProd = new PhysicalProduct(name, price, shipping);
                products.Add(physcProd);
                Save();
            }

             void EbookRegister()
            {
                Console.WriteLine("=== Registering Ebook ===");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Price: ");
                float price = float.Parse(Console.ReadLine());
                Console.WriteLine("Author: ");
                string author = Console.ReadLine();
                Ebook ebk = new Ebook(name, price, author);
                products.Add(ebk);
                Save();

            }

             void CourserRegister()
            {
                Console.WriteLine("=== Registering Ebook ===");
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Price: ");
                float price = float.Parse(Console.ReadLine());
                Console.WriteLine("Author: ");
                string author = Console.ReadLine();
                Console.WriteLine("Slots: ");
                Course course = new Course(name, price, author);
                products.Add(course);
                Save();
            }
        }

        static void Save()
        {
            FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, products);
            stream.Close();
        }

        static void Load()
        {
            FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                products = (List<IStorage>)encoder.Deserialize(stream);

                if(products == null)
                {
                    products = new List<IStorage>();
                }
            }catch(Exception e)
            {
                products = new List<IStorage>();
            }

            stream.Close();
    
        }
    }
}
