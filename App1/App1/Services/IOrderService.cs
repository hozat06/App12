using App1.Models;

namespace App1.Services
{
    public interface IOrderService
    {
        Order Order { get; }
        void ShowDisplay();
        void Refresh(int? index);

        OrderPageType OrderPage { get; set; }
    }

    public enum OrderPageType
    {
        Normal,
        Ad
    }
}
