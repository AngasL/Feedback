using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feedback.Models
{
    public class Category
    {
        [Key]
        public virtual int CatetoryId { get; set; }
        public virtual string Description { get; set; }
    }
}