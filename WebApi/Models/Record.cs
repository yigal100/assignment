using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    [Table("records")]
    public class Record
    {
        public string EconomicVariableId { get; set; }
        public string IndustryId { get; set; }
        public string PartnerCountryId { get; set; }
        public string DeclaringCountryId { get; set; }
        public int Year { get; set; }
        public string UnitId { get; set; }
        public int PowerCodeId { get; set; }
        public int? Value { get; set; }


        // navigational properties
        public EconomicVariable EconomicVariable { get; set; }
        public Industry Industry { get; set; }
        public PartnerCountry PartnerCountry { get; set; }
        public DeclaringCountry DeclaringCountry { get; set; }
        public Unit Unit { get; set; }
        public PowerCode PowerCode { get; set; }
    }
}
