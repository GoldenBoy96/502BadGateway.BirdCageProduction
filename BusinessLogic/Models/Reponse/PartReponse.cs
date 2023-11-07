using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Reponse
{
    public class PartReponse
    {
        public int PartId { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public string? Shape { get; set; }

        public string? Material { get; set; }

        public string? Size { get; set; }

        public int ColorId { get; set; } = 0;

        public double? Cost { get; set; }
    }
}
