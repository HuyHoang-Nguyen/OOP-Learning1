using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        //Tim kiem san pham trong khoang gia
        public List<Product> SearchByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var product = products.OfType<Product>().Where(p => p.salePrice >= minPrice && p.salePrice <= maxPrice).ToList();
            if (!product.Any())
                Console.WriteLine("Khong tim thay san pham trong khoang gia nay");

            return product;
        }

        //Tim top N san pham co loi nhuan cao nhat
        public List<Product> GetTopProfitProducts(int top)
        {
            var product = products.OrderByDescending(p => p.Profit).Take(top).ToList();
            if (!product.Any())
                Console.WriteLine("Khong tim thay thong tin..");
            return product;
        }

        //Tinh gia tri hang ton kho
        public decimal CalculateInventoryValue()
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.CalculateInventoryValue();
            }
               return total;
        }
        //class Program
        //{
        //    static void Main(string[] args)
        //    {
        //        try
        //        {
        //            StoreManager store = new StoreManager();

        //            // Tao san pham
        //            var phone1 = new Product.MobilePhone("IP16", "iPhone 16", "Apple", 8000, 16, 8000000, 8700000, 24);
        //            var phone2 = new Product.MobilePhone("SSS24", "Samsung S24", "Samsung", 7800, 18, 5600000, 6200000, 51);
        //            var phone3 = new Product.MobilePhone("SS18", "Samsung 18", "Samsung", 5000, 6, 3200000, 3600000, 16);
        //            var accessory1 = new Product.Accessory("TNB01", "Tai nghe Bluetooth", "Tai nghe", "Nhua", 200000, 260000, 150);
        //            //var accessory2 = new Product.Accessory("TNB01", "Bluetooth Headphone", "Tai nghe", "Nhua", 400000, 500000, 200);

        //            // Them vao danh sach
        //            store.AddProduct(phone1);
        //            store.AddProduct(phone2);
        //            store.AddProduct(phone3);
        //            store.AddProduct(accessory1);
        //            //store.AddProduct(accessory2);

        //            // Hien thi danh sach
        //            store.DisplayAllProducts();
        //            store.CountProductsByType();

        //            //Tim kiem san pham theo ma
        //            Console.WriteLine("\nTim san pham co ma 'SSS24':");
        //            var found = store.SearchByProductId("SSS24");
        //            found.DisplayInfo();

        //            //Tim kiem san pham theo hang san xuat
        //            Console.WriteLine("\nTim kiem san pham co hang san xuat: Samsung");
        //            var found1 = store.SearchPhoneByManufacturer("Samsung");
        //            if (found1.Any())
        //            {
        //                foreach (var item in found1)
        //                {
        //                    item.DisplayInfo();
        //                    Console.WriteLine("-------------------");
        //                }

        //                //Tim kiem san pham theo khoang gia
        //                decimal min = 3000000;
        //                decimal max = 9000000;
        //                Console.WriteLine($"\nTim kiem san pham co gia tu: {min} - {max}");
        //                var found2 = store.SearchByPriceRange(min, max);
        //                if (found2.Any())
        //                {
        //                    foreach (var item in found2)
        //                    {
        //                        item.DisplayInfo();
        //                        Console.WriteLine("------------------");
        //                    }
        //                }

        //                //Hien thi top san pham co doanh thu cao nhat
        //                int top = 3;
        //                Console.WriteLine($"\nTop {top} san pham co loi nhuan cao nhat: ");
        //                var found3 = store.GetTopProfitProducts(top);
        //                if (found3.Any())
        //                {
        //                    foreach (var item in found3)
        //                    {
        //                        item.DisplayInfo();
        //                        item.CalculateProfit();
        //                        Console.WriteLine("------------------");
        //                    }
        //                }

        //                // Xoa san pham
        //                Console.WriteLine("\nXoa san pham co ma IP16");
        //                store.RemoveProduct("IP16");
        //                Console.WriteLine("Xoa san pham co ma IP01");
        //                store.RemoveProduct("IP01");

        //                // Hien thi lai danh sach
        //                store.DisplayAllProducts();
        //            }
        //        }

        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}
    }
}
