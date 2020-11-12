using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GroupManagement.Models.Masters
{
    [Table("Cities")]
    public partial class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IATACode { get; set; }
        public int? CountryID { get; set; }
        public virtual Country Country { get; set; }
    }
}
