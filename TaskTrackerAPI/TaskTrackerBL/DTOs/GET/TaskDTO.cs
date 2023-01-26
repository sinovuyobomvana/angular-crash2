using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerBL.DTOs.POST;

namespace TaskTrackerBL.DTOs.GET
{
    public class TaskDTO : AddTaskDTO
    { 
        public Guid Id { get; set; }

    }
}
