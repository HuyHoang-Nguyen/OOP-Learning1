using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOOP1
{
    internal class StoreManager
    {        
    private List<Product> products;

        public StoreManager()
        {
            products = new List<Product>();
        }

        // Them san pham
        public void AddProduct(Product product)
        {
            if (products.Any(p => p.productId == product.productId))
                throw new Exception("San pham co ma nay da ton tai..");
            products.Add(product);
            Console.WriteLine($"Da them san pham: {product.ProductName}");
        }

        // Xoa san pham theo ma
        public void RemoveProduct(string productId)
        {
            var product = products.FirstOrDefault(p => p.productId == productId);
            if (product == null)
            {
                Console.WriteLine("Khong tim thay san pham co ma nay..");
                return;
            }
            products.Remove(product);
            Console.WriteLine($"Da xoa san pham co ma: {productId}");
        }

        // Tim san pham theo ma
        public Product SearchByProductId(string productId)
        {
            var product = products.FirstOrDefault(p => p.productId == productId);
            if (product == null)
                Console.WriteLine("Khong tim thay san pham co ma nay..");
            return product;
        }

        //Tim theo hang san xuat
        public List<Product.MobilePhone> SearchPhoneByManufacturer(string manufacturer)
        {
            var product = products.OfType<Product.MobilePhone>().Where(p => p.Manufacturer == manufacturer).ToList();

            if (!product.Any())
                Console.WriteLine("Khong tim thay san pham co hang san xuat nay..");

            return product;
        }

        // Hien thi toan bo san pham
        public void DisplayAllProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Danh sach san pham rong...");
                return;
            }

            Console.WriteLine("\nDANH SACH SAN PHAM:");
            foreach (var p in products)
            {
                p.DisplayInfo();
                p.CalculateProfit();
                p.CalculateDisount();
                Console.WriteLine("-----------------------------------");
            }
        }

        // Dem so luong theo loai san pham
        public void CountProductsByType()
        {
            int countPhone = products.OfType<Product.MobilePhone>().Count();
            int countAccessory = products.OfType<Product.Accessory>().Count();

            Console.WriteLine($"\nSo dien thoai: {countPhone}");
            Console.WriteLine($"So phu kien: {countAccessory}");
        }
    }

    //chuong trinh chinh
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StoreManager store = new StoreManager();

                // Tao san pham
                var phone1 = new Product.MobilePhone("IP16", "iPhone 16", "Apple", 80000, 16, 8000000, 8700000, 24);
                var phone2 = new Product.MobilePhone("SSS24", "Samsung S24", "Samsung", 7800, 18, 5600000, 6200000, 51);
                var phone3 = new Product.MobilePhone("SS18", "Samsung 18", "Samsung", 500, 6, 3200000, 3600000, 16);
                var accessory1 = new Product.Accessory("TNB01", "Tai nghe Bluetooth", "Tai nghe", "Nhua", 200000, 260000, 150);
                //var accessory2 = new Product.Accessory("TNB01", "Bluetooth Headphone", "Tai nghe", "Nhua", 400000, 500000, 200);

                // Them vao danh sach
                store.AddProduct(phone1);
                store.AddProduct(phone2);
                store.AddProduct(phone3);
                store.AddProduct(accessory1);
                //store.AddProduct(accessory2);

                // Hien thi danh sach
                store.DisplayAllProducts();
                store.CountProductsByType();

                //Tim kiem san pham
                Console.WriteLine("\nTim san pham co ma 'SSS24':");
                var found = store.SearchByProductId("SSS24");
                found.DisplayInfo();

                //Tim kiem san pham theo hang san xuat
                Console.WriteLine("\nTim kiem san pham co hang san xuat: Samsung");
                var found1 = store.SearchPhoneByManufacturer("Samsung");
                if (found1.Any())
                {
                    foreach (var item in found1)
                    {
                        item.DisplayInfo();
                    }

                    // Xoa san pham
                    Console.WriteLine("\nXoa san pham co ma IP16");
                    store.RemoveProduct("IP16");
                    Console.WriteLine("Xoa san pham co ma IP01");
                    store.RemoveProduct("IP01");

                    // Hien thi lai danh sach
                    store.DisplayAllProducts();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          
        }   
    }
}
