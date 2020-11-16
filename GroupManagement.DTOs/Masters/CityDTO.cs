using System;
using System.Collections.Generic;
using System.Text;

namespace GroupManagement.DTOs
{
    public class CityDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IATACode { get; set; }
        public int? CountryID { get; set; }
        public virtual CountryDTO Country { get; set; }
    }
}
