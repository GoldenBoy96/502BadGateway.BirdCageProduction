using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Reponse
{
    public class OrderReponse
    {
        public int OrderId { get; set; }

        public DateTime? DayCreated { get; set; }

        public decimal? TotalPrice { get; set; }

        public int? StatusId { get; set; }

        public string? Address { get; set; }

        public int? AccountId { get; set; }

        public int? CustomerId { get; set; }

        public  List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
