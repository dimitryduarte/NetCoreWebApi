using System;
using System.ComponentModel.DataAnnotations;

namespace NetCoreWebApi.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string Linkedin { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

    }
}
