using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feedback.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Category Category { get; set; }
        public virtual int Mark { get; set; }
    }
}