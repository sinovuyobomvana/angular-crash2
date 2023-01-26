﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerDAL.Entities
{
    public class TaskEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string DayAndTime { get; set; }
        public bool? Reminder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public TaskEntity(string name, string dayAndTime, bool? reminder, DateTime createdAt, DateTime modifiedAt)
        {
            Name = name;
            DayAndTime = dayAndTime;
            Reminder = reminder;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
        }
    }
}
