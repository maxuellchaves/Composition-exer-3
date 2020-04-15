using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composition_obj_exer_3.Entities.Enums;
using System.Globalization;
namespace Composition_obj_exer_3.Entities
{
    class Order
    {
        public DateTime Moment{ get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem (OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach(OrderItem obj in Items)
            {
                sum += obj.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder os = new StringBuilder();
            os.AppendLine("Order moment: " + Moment);
            os.AppendLine("Order status: " + Status);
            os.AppendLine("Client: " + Client.Name + " (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") " + " - " + Client.Email);
            os.AppendLine("\nOrder items:");

            foreach(OrderItem item in Items)
            {
                os.AppendLine(item.ToString());
            }
            os.AppendLine("Total price: $" + Total().ToString("F2",CultureInfo.InvariantCulture));

            return os.ToString();

        }


    }
}
