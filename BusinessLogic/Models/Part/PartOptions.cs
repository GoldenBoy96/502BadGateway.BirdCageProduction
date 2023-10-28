using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Part
{
    public class PartOptions
    {
        public List<string> Materials { get; set; }
        public List<string> Shapes { get; set; }
        public List<string> Sizes { get; set; }
    }
}
