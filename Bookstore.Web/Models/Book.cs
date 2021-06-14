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

        [Required]
        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [Required]
        public string Publisher { get; set; }
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}