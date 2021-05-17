using Bookstore.Web.Models.Base;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Web.Models
{
    public class Book : ModelBase
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        [NotMapped]
        public IFormFile Image { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}