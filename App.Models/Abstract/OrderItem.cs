namespace App.Models.Abstract
{
    public struct OrderItem
    {
        public string Name { get; set; }
        public OrderType OrderType { get; set; }

        public static OrderItem Create(string name, OrderType orderType)
        {
            return new OrderItem
            {
                Name = name,
                OrderType =  orderType
            };
        }
        
    }
}
