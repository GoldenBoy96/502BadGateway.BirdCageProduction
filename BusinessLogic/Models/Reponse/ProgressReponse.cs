using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Reponse
{
    public class ProgressReponse
    {
        public int ProgressId { get; set; }

        public int ProgressNum { get; set; }

        public DateTime? StartDay { get; set; }

        public DateTime? EndDay { get; set; }

        public int? StatusId { get; set; }

        public int? OrderDetailId { get; set; }

        public int? AccountId { get; set; }
    }
}
