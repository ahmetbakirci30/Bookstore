using System;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Web.Models.Base
{
    public abstract class ModelBase
    {
        public int Id { get; set; }

        [Display(Name = "Addition Date")]
        public DateTime AddedDate { get; set; }

        public ModelBase()
        {
            AddedDate = DateTime.Now;
        }
    }
}