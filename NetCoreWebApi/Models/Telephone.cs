using NetCoreWebApi.Extensions.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreWebApi.Models
{
    public class Telephone
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public string Number { get; set; }

        public TelephoneType Type { get; set; }

    }

}
