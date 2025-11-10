using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
                    Console.WriteLine("========== MOBILE PHONE STORE MANAGEMENT ==========");
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
                                Console.WriteLine("Which kind of product you want to add?");
                                Console.WriteLine("1.Mobile phone..");
                                Console.WriteLine("2.Mobile accessory..");
                                Console.Write("\nEnter your choice: ");
                                int input2 = int.Parse(Console.ReadLine());
                                switch (input2)
                                {
                                    case 1:
                                        Console.WriteLine("Enter phone details: ");
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
                                }
                                break;
                            case 3:
                                store.DisplayAllProducts();
                                store.CountProductsByType();
                                Console.WriteLine("");
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
