using App1.Models;
using App1.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static MainPageViewModel _this;

        #region Categories
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories 
        { 
            get => categories;
            set
            {
                if (categories != value)
                    categories = value;
                OnPropertyChanged(nameof(Categories));
            } 
        }
        #endregion

        #region Products
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                if (products != value)
                    products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        #endregion

        #region Orders
        private Order order;
        public Order Order
        {
            get => order;
            set
            {
                if (order != value)
                    order = value;
                OnPropertyChanged(nameof(Order));
            }
        }
        #endregion

        #region ProductGridColumns
        private int productGridColumns;
        public int ProductGridColumns
        {
            get => productGridColumns;
            set
            {
                if (productGridColumns != value)
                    productGridColumns = value;
                OnPropertyChanged(nameof(ProductGridColumns));
            }
        }
        #endregion

        #region Total
        private float total => order == null ? 0 : order.Lines.Sum(x => x.Total);
        public float Total
        {
            get => total;
            set
            {
                OnPropertyChanged(nameof(Total));
            }
        }
        #endregion

        public ICommand OrderProductRemoveCommand { get; set; }
        public ICommand CategorySelectedCommand { get; set; }
        public ICommand ProductSelectedCommand { get; set; }

        public IOrderService orderService;

        public MainPageViewModel()
        {
            _this = this;

            if (DeviceDisplay.MainDisplayInfo.Width>=1024)
                productGridColumns = 6;
            else if (DeviceDisplay.MainDisplayInfo.Width >= 768)
                productGridColumns = 2;
            else 
                productGridColumns = 1;

            categories = new ObservableCollection<Category>(Data.GetCategories());
            products = new ObservableCollection<Product>();

            CategorySelectedCommand = new Command<Category>((category) => CategorySelect(category));
            ProductSelectedCommand = new Command<Product>((product) => AddOrder(product));
            OrderProductRemoveCommand = new Command<OrderLine>((line) => RemoveOrder(line));

            CategorySelect(Data.BurgerCategory);

            orderService = DependencyService.Get<IOrderService>();
            orderService.OrderPage = OrderPageType.Ad;
            orderService.ShowDisplay();
        }

        private void AddOrder(Product product)
        {
            if (order == null)
            {
                order = new Order();
            }

            int index;
            if (order.Lines.Where(x=> x.Product.Id == product.Id).FirstOrDefault() is OrderLine orderLine)
            {
                index = order.Lines.IndexOf(orderLine);
                orderLine.Quantity++;
                orderLine.Total = orderLine.Price * orderLine.Quantity;
                order.Lines[index]= orderLine;
            }
            else
            {
                order.Lines.Add(new OrderLine
                {
                    Price = product.Price,
                    Quantity = 1,
                    Total = product.Price,
                    Product = product,
                });
                index = order.Lines.Count() - 1;
            }

            OnPropertyChanged(nameof(Order));
            OnPropertyChanged(nameof(Total));

            orderService.Refresh(index);
        }
        private void RemoveOrder(OrderLine orderLine)
        {
            int index = order.Lines.IndexOf(orderLine);

            order.Lines.Remove(orderLine);
            OnPropertyChanged(nameof(Order));
            OnPropertyChanged(nameof(Total));

            orderService.Refresh(index);
        }

        private void CategorySelect(Category category)
        {
            products.Clear();
            foreach (Product product in category.Products) 
                products.Add(product);

            OnPropertyChanged(nameof(Categories));
            OnPropertyChanged(nameof(Products));
            OnPropertyChanged(nameof(ProductGridColumns));
        }
    }
}
