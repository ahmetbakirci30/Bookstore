using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Web.Models.Base
{
    public abstract class ModelBase
    {
        public ModelBase()
            => AddedDate = DateTime.UtcNow;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; }
    }
}