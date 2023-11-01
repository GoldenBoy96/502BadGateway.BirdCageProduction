using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.PartItem
{
    public class PartItemPageModel
    {
        public int PartItemId { get; set; }
        public int? Quantity { get; set; } 
        public string? Code { get; set; }
        public int? BirdCageId { get; set; } 
    }
}
