namespace WebApplication1.Models
{
    public class Order
    {
        public int OrderId { get; set; }//номер заказа(очевидно)
        public string User { get; set; } // имя фамилия покупателя
        public string Address { get; set; } // адрес покупателя
        public string ContactPhone { get; set; } // контактный телефон покупателя
        public int ItemId { get; set; } // ссылка на связанную модель в бд
        public Phone Phone { get; set; }// образец товара
    }
}