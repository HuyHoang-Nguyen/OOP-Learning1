
using System;
class Product
#region bai 1
{
    private string ProductId;
    public string ProductName { get; set; }
    private decimal ImportPrice;
    private decimal SalePrice;
    private int StockQuantity;
    public decimal Profit => SalePrice - ImportPrice;

    public string productId
    {
        get => ProductId;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Ma san pham khong duoc rong..");
            ProductId = value;
        }
    }
    public decimal importPrice

    {
        get => ImportPrice;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(importPrice), "Gia nhap vao phai lon hon 0..");
            }
            ImportPrice = value;
        }

    }

    public decimal salePrice
    {
        get => SalePrice;
        set
        {
            if (value <= 0)
                throw new ArgumentException(nameof(salePrice), "Gia ban ra phai lon hon 0..");
            SalePrice = value;
        }
    }
    public int stockQuantity
    {
        get => StockQuantity;
        set
        {
            if (value < 0)
                throw new ArgumentException(nameof(stockQuantity), "Hang ton kho phai lon hon hoac bang 0..");
            StockQuantity = value;
        }
    }
    public Product()
    {
        productId = "DF01";
        ProductName = "San pham";
        importPrice = 1;
        salePrice = 1;
        stockQuantity = 0;
    }
    public Product(string proId, string proName, decimal impoPrice, decimal salePri, int stockQuan)
    {
        productId = proId;
        ProductName = proName;
        importPrice = impoPrice;
        salePrice = salePri;
        stockQuantity = stockQuan;
    }
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Ma san pham: {productId} Ten san pham: {ProductName} Gia nhap vao: {importPrice} Gia ban ra: {salePrice} So luong ton kho: {stockQuantity} ");
    }
    public void CalculateProfit()
    {
        Console.WriteLine("Loi nhuan la: " + Profit);
    }
    public virtual void CalculateDisount()
    {
        Console.WriteLine("Giam gia: 0%");
    }

    public virtual decimal CalculateInventoryValue()
    {
        decimal stockValue = importPrice * stockQuantity;
        return stockValue;
    }


    //public static void main(string[] args)
    //{
    //    try
    //    {
    //        var item2 = new Product("ip16", "iphone16", 4000000, 4600000, 24);
    //        item2.DisplayInfo();
    //        item2.CalculateProfit();


    //    }
    //    catch (ArgumentException ex)
    //    {
    //        Console.WriteLine(ex.Message);
    //    }
    //}
    #endregion

    #region bai 2
    public class MobilePhone : Product
    {
        public string Manufacturer { get; set; }
        public int BatteryCapacity { get; set; }
        public int WarrantyPeroid { get; set; }

        public MobilePhone() : base()
        {
            Manufacturer = "Hang san suat";
            BatteryCapacity = 1;
            WarrantyPeroid = 1;
        }

        public MobilePhone(string proId, string proName, string manufacturer, int batteryCap, int warrantPer, decimal impoPrice, decimal salePri, int stockQuan)
            : base(proId, proName, impoPrice, salePri, stockQuan)
        {
            Manufacturer = manufacturer;
            BatteryCapacity = batteryCap;
            WarrantyPeroid = warrantPer;
        }

        public override void DisplayInfo()
        {

            Console.WriteLine($" Ten san pham: {ProductName} Hang san xuat: {Manufacturer} Dung luong pin: {BatteryCapacity}mAh Thoi gian bao hanh: {WarrantyPeroid} thang Gia nhap vao: {importPrice} Gia ban ra: {salePrice} So luong ton kho: {stockQuantity} ");
        }
        public override void CalculateDisount()
        {
            if (stockQuantity > 50)

            {
                Console.WriteLine("Giam gia: 10%");
            }
            else
            {
                Console.WriteLine("Giam gia: 0%");
            }
        }
    }
        //public static void Main(string[] args)
        //{
        //    try
        //    {
        //        var Item2 = new MobilePhone("SS18", "Samsung 18", "Samsung", 3800, 18, 6000000, 6600000, 50);
        //        Item2.DisplayInfo();
        //        Item2.CalculateProfit();
        //        Item2.CalculateDisount();
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //}
        public class Accessory : Product
        {
            public string AccessoryType { get; set; }
            public string Material { get; set; }


            public Accessory() : base()
            {
                AccessoryType = "Loai phu kien.";
                Material = "Chat lieu cua phu kien";
            }
            public Accessory(string proId, string proName, string accessType, string material, decimal impoPrice, decimal salePri, int stockQuan)
                : base(proId, proName, impoPrice, salePri, stockQuan)
            {
                AccessoryType = accessType;
                Material = material;
            }
            public override void DisplayInfo()
            {
                Console.WriteLine($"Ma san pham: {productId} Ten san pham: {ProductName} Loai phu kien: {AccessoryType} Chat lieu: {Material} Gia nhap vao: {importPrice} Gia ban ra: {salePrice} So luong ton kho: {stockQuantity} ");
            }
            public override void CalculateDisount()
            {
                if (stockQuantity > 100)
                {
                    Console.WriteLine("Giam gia: 5%");
            }
                else
                {
                    Console.WriteLine("Giam gia: 0%");
                }

            }
            //public static void Main(string[] args)
            //{
            //    try
            //    {
            //        var Item1 = new Accessory("TN21", "Tai nghe Bluetooth", "Tai nghe", "Nhua", 500000, 600000, 110);
            //        Item1.DisplayInfo();
            //        Item1.CalculateProfit();
            //        Item1.CalculateDisount();
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            #endregion
        }
    }
