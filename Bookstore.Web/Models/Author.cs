using Bookstore.Web.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Web.Models
{
    public class Author : ModelBase
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}