using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Reponse
{
    public class PartItemReponse
    {
        public int PartItemId { get; set; }

        public int? Quantity { get; set; }

        public int? PartId { get; set; }

        public int? BirdCageId { get; set; }
    }
}
