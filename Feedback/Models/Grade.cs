﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Feedback.Models
{
    public class Grade
    {
        [Key]
        public virtual int GradeId { get; set; }
        public virtual string Name { get; set; }

    }
}