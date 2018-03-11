using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testAsp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Class1
    {
        [Required(ErrorMessage = "Id is req")]
        public int Id { get; set; }

        [Required(ErrorMessage = "col1 is req")]
        [MinLength(3, ErrorMessage = "Col1 is min 3 length")]
        [MaxLength(3, ErrorMessage = "Col1 is max 5 length")]
        public string Col1 { get; set; }
    }
}