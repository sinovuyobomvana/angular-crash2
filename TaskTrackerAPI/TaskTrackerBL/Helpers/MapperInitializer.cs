using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerBL.DTOs.GET;
using TaskTrackerBL.DTOs.POST;
using TaskTrackerDAL.Entities;

namespace TaskTrackerBL.Helpers
{
    public class MapperInitializer:Profile
    {
        public MapperInitializer()
        {
            CreateMap<TaskEntity, TaskDTO>().ReverseMap();
            CreateMap<TaskEntity, AddTaskDTO>().ReverseMap();
        }
    }
}
