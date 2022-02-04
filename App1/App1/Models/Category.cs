using System.Collections.Generic;

namespace App1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get => Data.GetCategoryProducts(this.Id); }

        public override string ToString()
        {
            return Name;
        }
    }
}
