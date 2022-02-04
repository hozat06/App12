using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App1.Models
{
    public static class Data
    {
        public static Category BurgerCategory { get; } = new Category() { Name = "Burgerler", Id = 1 };
        public static Category CitirCategory { get; } = new Category() { Name = "Çıtır Lezzetler", Id = 2 };
        public static Category IcecekCategory { get; } = new Category() { Name = "İçecekler", Id = 3 };
        public static Category SosCategory { get; } = new Category() { Name = "Soslar", Id = 4 };
        private static List<Category> Categories { get; set; } = new List<Category>()
        {
            BurgerCategory, CitirCategory, IcecekCategory, SosCategory
        };

        private static List<Product> Products { get; set; } = new List<Product>()
        {
            new Product() { Id=1, Category = BurgerCategory, Price = 44.99f, Name = "Whopper"},
            new Product() { Id=2, Category = BurgerCategory, Price = 49.99f, Name = "Rodeo Whopper"},
            new Product() { Id=3, Category = BurgerCategory, Price = 53.99f, Name = "Double Whopper"},
            new Product() { Id=4, Category = BurgerCategory, Price = 32.99f, Name = "Whopper Jr."},
            new Product() { Id=5, Category = BurgerCategory, Price = 37.99f, Name = "Big King"},
            new Product() { Id=6, Category = BurgerCategory, Price = 56.99f, Name = "Texas Smokehouse Burger"},
            new Product() { Id=7, Category = BurgerCategory, Price = 29.99f, Name = "Kids Hamburger"},

            new Product() { Id=8, Category = CitirCategory, Price = 9.99f, Name = "Patates (Küçük)"},
            new Product() { Id=9, Category = CitirCategory, Price = 11.99f, Name = "Patates (Büyük)"},
            new Product() { Id=10, Category = CitirCategory, Price = 14.99f, Name = "Chicken Tenders (4'lü)"},
            new Product() { Id=11, Category = CitirCategory, Price = 16.99f, Name = "Çıtır Peynir (4'lü)"},
            new Product() { Id=12, Category = CitirCategory, Price = 17.99f, Name = "BK King Nuggets (6'lı)"},
            new Product() { Id=13, Category = CitirCategory, Price = 12.99f, Name = "Soğan Halkası (8'li)"},

            new Product() { Id=14, Category = IcecekCategory, Price = 9.99f, Name = "Coca-Cola (33cl)"},
            new Product() { Id=15, Category = IcecekCategory, Price = 9.99f, Name = "Fanta (33cl)"},
            new Product() { Id=16, Category = IcecekCategory, Price = 9.99f, Name = "Sprite (33cl)"},
            new Product() { Id=17, Category = IcecekCategory, Price = 9.99f, Name = "Fuse Tea Limon (33cl)"},
            new Product() { Id=18, Category = IcecekCategory, Price = 9.99f, Name = "Fuse Tea Şeftali (33cl)"},
            new Product() { Id=19, Category = IcecekCategory, Price = 9.99f, Name = "Ayran (300ml)"},

            new Product() { Id=20, Category = SosCategory, Price = 2.00f, Name = "Zeytinyağı & Limon Sosu"},
            new Product() { Id=21, Category = SosCategory, Price = 2.00f, Name = "Ketçap"},
            new Product() { Id=22, Category = SosCategory, Price = 2.00f, Name = "Mayonez"},
            new Product() { Id=23, Category = SosCategory, Price = 2.00f, Name = "Acı Sos"},
            new Product() { Id=24, Category = SosCategory, Price = 2.00f, Name = "Barbekü Sos"},
            new Product() { Id=25, Category = SosCategory, Price = 2.00f, Name = "Ranch Sos"},
        };

        public static List<Category> GetCategories()
        {
            return Categories;
        }

        public static Category GetCategory(int id)
        {
            return Categories.FirstOrDefault(x => x.Id == id);
        }

        public static List<Product> GetAllProducts()
        {
            return Products;
        }

        public static List<Product> GetCategoryProducts(int categoryId)
        {
            return Products.Where(x => x.Category.Id == categoryId).ToList();
        }

        public static Product GetProduct(int id)
        {
            return Products.FirstOrDefault(x => x.Id == id);
        }
    }
}
