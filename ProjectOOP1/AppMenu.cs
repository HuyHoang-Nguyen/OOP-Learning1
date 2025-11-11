using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace ProjectOOP1
{
    internal class AppMenu
    {
        public static void Main(string[] args)
        {
            bool run = true;
            StoreManager store = new StoreManager();
            while (run)
            {
                try
                {
                    Console.WriteLine("\n========== MOBILE PHONE STORE MANAGEMENT ==========");
                    Console.WriteLine("1.Add new product");
                    Console.WriteLine("2.Remove product");
                    Console.WriteLine("3.Display all product");
                    Console.WriteLine("4.Search product");
                    Console.WriteLine("5.Statistics and reports");
                    Console.WriteLine("6.Create sales invoice");
                    Console.WriteLine("7.Display invoice history");
                    Console.WriteLine("0.Exit");
                    Console.WriteLine("===================================================");
                    Console.Write("Enter your choice: ");
                    {
                        int input1 = int.Parse(Console.ReadLine());
                        switch (input1)
                        {
                            case 1:
                                Console.WriteLine("\nWhich kind of product you want to add?");
                                Console.WriteLine("1.Mobile phone..");
                                Console.WriteLine("2.Mobile accessory..");
                                Console.Write("\nEnter your choice: ");
                                int input2 = int.Parse(Console.ReadLine());
                                switch (input2)
                                {
                                    case 1:
                                        Console.WriteLine("Enter phone details..");
                                        try
                                        {
                                            var phone = new Product.MobilePhone();
                                            Console.Write("Id: ");
                                            phone.productId = Console.ReadLine();
                                            Console.Write("Name: ");
                                            phone.ProductName = Console.ReadLine();
                                            Console.Write("Manufacturer: ");
                                            phone.Manufacturer = Console.ReadLine();
                                            Console.Write("Battery capacity: ");
                                            phone.BatteryCapacity = int.Parse(Console.ReadLine());
                                            Console.Write("Warranty peroid: ");
                                            phone.WarrantyPeroid = int.Parse(Console.ReadLine());
                                            Console.Write("Import price: ");
                                            phone.importPrice = decimal.Parse(Console.ReadLine());
                                            Console.Write("Sale price: ");
                                            phone.salePrice = decimal.Parse(Console.ReadLine());
                                            Console.Write("Stock quantity: ");
                                            phone.stockQuantity = int.Parse(Console.ReadLine());
                                            Console.WriteLine("");
                                            store.AddProduct(phone);
                                        }
                                        catch (ArgumentException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                        break;

                                        case 2:
                                        Console.WriteLine("Enter accessory details..");
                                        try 
                                        {
                                            var accessory = new Product.Accessory();
                                            Console.Write("Id: ");
                                            accessory.productId = Console.ReadLine();
                                            Console.Write("Name: ");
                                            accessory.ProductName = Console.ReadLine();
                                            Console.Write("Accessory type: ");
                                            accessory.AccessoryType = Console.ReadLine();
                                            Console.Write("Material: ");
                                            accessory.Material = Console.ReadLine();
                                            Console.Write("Import price: ");
                                            accessory.importPrice = decimal.Parse(Console.ReadLine());
                                            Console.Write("Sale price: ");
                                            accessory.salePrice = decimal.Parse(Console.ReadLine());
                                            Console.Write("Stock quantity: ");
                                            accessory.stockQuantity = int.Parse(Console.ReadLine());
                                            Console.WriteLine("");
                                            store.AddProduct(accessory);
                                        }
                                        catch (ArgumentException ex)
                                        { 
                                            Console.WriteLine(ex.Message); 
                                        } 
                                        break;
                                }
                                break;
                            case 2:
                                Console.Write("Enter product Id: ");
                                string input3 = Console.ReadLine();
                                try
                                {
                                    store.RemoveProduct(input3);
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);                                
                                }
                                break;
                            case 3:
                                store.DisplayAllProducts();
                                store.CountProductsByType();
                                Console.WriteLine("");
                                break;
                            case 4:
                                Console.WriteLine("Choose search method..");
                                Console.WriteLine("1.Id");
                                Console.WriteLine("2.Manufacturer");
                                Console.WriteLine("3.Price range");
                                Console.Write("\nEnter your choice: ");

                                int input4 = int.Parse(Console.ReadLine());
                                switch (input4)
                                {
                                    case 1:
                                        Console.Write("Enter product Id: ");
                                        var search = store.SearchByProductId(Console.ReadLine());
                                        search.DisplayInfo();
                                        break;

                                    case 2:
                                        Console.Write("Enter manufacturer: ");
                                        var search1 = store.SearchPhoneByManufacturer(Console.ReadLine());
                                        if (search1.Any())
                                        {
                                            foreach (var item in search1)
                                            {
                                                item.DisplayInfo();
                                                Console.WriteLine("");
                                            }
                                        }
                                        break;
                                    case 3:
                                        Console.Write("Enter min price: ");
                                        int min = int.Parse(Console.ReadLine());
                                        Console.Write("Enter max price: ");
                                        int max = int.Parse(Console.ReadLine());
                                        var search2 = store.SearchByPriceRange(min, max);
                                        if (search2.Any())
                                        {
                                            foreach (var item in search2)
                                            {
                                                item.DisplayInfo();
                                                Console.WriteLine("");
                                            }
                                        }
                                        break;
                                    }
                                break;

                            case 5:
                                Console.WriteLine("Enter option..");
                                Console.WriteLine("1.Total inventory value");
                                Console.WriteLine("2.Top profit product");

                                Console.Write("\nEnter your choice: ");
                                int input5 = int.Parse(Console.ReadLine());
                                switch (input5)
                                {
                                    case 1: 
                                        decimal totalStockValue = 

                                    case 2:
                                        Console.Write("Top: ");
                                        int top = int.Parse(Console.ReadLine());
                                        var search1 = store.GetTopProfitProducts(top);
                                        if (search1.Any())
                                        {
                                            foreach (var item in search1)
                                            {
                                                item.DisplayInfo();
                                                Console.WriteLine("");
                                            }
                                        }
                                        break;
                                }
                                break;
                            case 0:
                                Console.WriteLine("Ending program...");
                                run = false;
                                break;
                            default:
                                Console.WriteLine("Please choose a valid option..");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error :{ex.Message}");
                }
            }
        }
    }
}
