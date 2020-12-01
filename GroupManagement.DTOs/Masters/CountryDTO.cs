using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class CountryCreateDTO
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(2)]
        public string Alpha2Code { get; set; }
        [StringLength(3)]
        public string Alpha3Code { get; set; }
        [StringLength(3)]
        public string NumericCode { get; set; }
    }

    public class CountryUpdateDTO
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(2)]
        public string Alpha2Code { get; set; }
        [StringLength(3)]
        public string Alpha3Code { get; set; }
        [StringLength(3)]
        public string NumericCode { get; set; }
    }
}
