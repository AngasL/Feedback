using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Feedback.Models
{
    public class Student
    {
        [Key]
        public virtual int StudentId { get; set; }
        public virtual string Name { get; set; }
        public virtual Grade Grade { get; set; }
    }
}