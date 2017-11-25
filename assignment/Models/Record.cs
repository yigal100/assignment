using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class Record
    {
        public EconomicVariable EconomicVariable { get; set; }
        public Industry Industry { get; set; }
        public PartnerCountry PartnerCountry { get; set; }
        public DeclaringCountry DeclaringCountry { get; set; }
        public int Year { get; set; }
        public Unit Unit { get; set; }
        public PowerCode PowerCode { get; set; }
        public int? Value { get; set; }

    }
}
