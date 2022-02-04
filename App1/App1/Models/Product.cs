using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace App1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
