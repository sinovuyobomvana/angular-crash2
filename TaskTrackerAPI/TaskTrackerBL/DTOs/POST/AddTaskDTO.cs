using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerBL.DTOs.POST
{
    public class AddTaskDTO
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string DayAndTime { get; set; }

        public bool? Reminder { get; set; }

    }
}
