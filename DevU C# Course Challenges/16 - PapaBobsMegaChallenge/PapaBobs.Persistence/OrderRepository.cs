using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PapaBobs.Persistence
{
    public class OrderRepository
    {
        public static void CreateOrder(DTO.OrderDTO orderDTO)
        {
            var db = new PapaBobsDbEntities();

            var order = convertToEntity(orderDTO);
            db.Orders.Add(order);
            db.SaveChanges();
        }

        private static Order convertToEntity(DTO.OrderDTO orderDTO)
        {
            var order = new Order();

            order.OrderId = orderDTO.OrderId;
            order.Size = orderDTO.Size;
            order.Crust = orderDTO.Crust;
            order.Sausage = orderDTO.Sausage;
            order.Pepperoni = orderDTO.Pepperoni;
            order.Onions = orderDTO.Onions;
            order.Green_Peppers = orderDTO.Green_Peppers;
            order.Name = orderDTO.Name;
            order.Address = orderDTO.Address;
            order.Phone = orderDTO.Phone;
            order.ZipCode = orderDTO.ZipCode;
            order.TotalCost = orderDTO.TotalCost;
            order.PaymentType = orderDTO.PaymentType;
            order.Completed = orderDTO.Completed;

            return order;
        }

        public static void CompleteOrder(Guid orderId)
        {
            var db = new PapaBobsDbEntities();

            var order = db.Orders.FirstOrDefault(p => p.OrderId == orderId);
            order.Completed = true;
            db.SaveChanges();
        }

        public static List<DTO.OrderDTO> GetOrders()
        {
            var db = new PapaBobsDbEntities();
            var orders = db.Orders.Where(p => p.Completed == false).ToList();
            var ordersDTO = convertToDTO(orders);
            return ordersDTO;
        }

        private static List<DTO.OrderDTO> convertToDTO(List<Order> orders)
        {
            var ordersDTO = new List<DTO.OrderDTO>();

            foreach (var order in orders)
            {
                var orderDTO = new DTO.OrderDTO();
                orderDTO.OrderId = order.OrderId;
                orderDTO.Size = order.Size;
                orderDTO.Crust = order.Crust;
                orderDTO.Name = order.Name;
                orderDTO.Address = order.Address;
                orderDTO.ZipCode = order.ZipCode;
                orderDTO.Phone = order.Phone;
                orderDTO.Sausage = order.Sausage;
                orderDTO.Pepperoni = order.Pepperoni;
                orderDTO.Onions = order.Onions;
                orderDTO.Green_Peppers = order.Green_Peppers;
                orderDTO.PaymentType = order.PaymentType;
                orderDTO.Completed = order.Completed;
                orderDTO.TotalCost = order.TotalCost;

                ordersDTO.Add(orderDTO);
            }
            return ordersDTO;
        }
    }
}
