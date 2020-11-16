using System;
using System.Collections.Generic;
using System.Text;

namespace GroupManagement.DTOs
{
    public class CountryDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string NumericCode { get; set; }
        public IList<CityDTO> Cities { get; set; }
    }
}
