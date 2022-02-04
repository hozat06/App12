using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace App1.Models
{
    public class Order
    {
        public DateTime Date { get; set; }
        public float Total { get; set; }
        public string Description { get; set; }
        public ObservableCollection<OrderLine> Lines { get; set; }

        public Order()
        {
            Lines = new ObservableCollection<OrderLine>();
        }

    }
}
