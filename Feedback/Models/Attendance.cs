using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Feedback.Models
{
    public class Attendance
    {
        [Key]
        public virtual int AttendenceId { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual DateTime ArravalTime { get; set; }
        public virtual DateTime LeavingTime { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("Grade")]
        public int  GradeId { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}