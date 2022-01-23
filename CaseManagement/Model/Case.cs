using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagement.Model
{
    internal class Case
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Headline { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [StringLength(100)]
        public string Administrator { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
