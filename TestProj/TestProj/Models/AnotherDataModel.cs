using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace TestProj.Models
{
    public class AnotherDataModel
    {
        public Int32 Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public Int32 OrderId { get; set; }
        public String DomenUrl { get; set; }
        public String CustomerName { get; set; }
        public Decimal TotalCost { get; set; }
        public String Status { get; set; }
        public String Method { get; set; }
        public String CompanyName { get; set; }
    }    
}
