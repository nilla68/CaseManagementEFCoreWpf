using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Model
{
    internal class Address
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(20)]
        public string Postcode { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        public List<Customer> Customers { get; set; }
    }
}