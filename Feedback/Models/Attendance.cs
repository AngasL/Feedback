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
        public virtual Student Student { get; set; }
        public virtual DateTime ArravalTime { get; set; }
        public virtual DateTime LeavingTime { get; set; }
        public virtual Teacher RecordedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
    }
}