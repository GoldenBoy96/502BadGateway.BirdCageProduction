using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Reponse
{
    public class OrderDetailReponse
    {
        public int OrderDetailId { get; set; }

        public int? Quantity { get; set; }

        public int? BirdCageId { get; set; }

        public int? OrderId { get; set; }
    }
}
