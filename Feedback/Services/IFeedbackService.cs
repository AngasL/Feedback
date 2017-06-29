using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback.Services
{
    public interface IFeedbackService
    {
        IEnumerable<Feedback.Models.Feedback> GetAllFeedbacks();
    }
}
