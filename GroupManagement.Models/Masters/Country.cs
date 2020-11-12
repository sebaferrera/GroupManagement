using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GroupManagement.Models.Masters
{
    [Table("Countries")]
    public partial class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string NumericCode { get; set; }
        public IList<City> Cities { get; set; }
    }
}
