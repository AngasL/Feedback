using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feedback.Models
{
    public class Course
    {
        [Key]
        public virtual int CourseId { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}