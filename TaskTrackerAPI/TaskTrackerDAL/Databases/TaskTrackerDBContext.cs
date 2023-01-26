using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerDAL.Entities;

namespace TaskTrackerDAL.Databases
{
    public class TaskTrackerDBContext: DbContext
    {
        public TaskTrackerDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
