using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class CityCreateDTO
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(3)]
        public string IATACode { get; set; }
        [Required]
        public int? CountryID { get; set; }
    }

    public class CityUpdateDTO
    {
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(3)]
        public string IATACode { get; set; }
        [Required]
        public int? CountryID { get; set; }
    }
}
