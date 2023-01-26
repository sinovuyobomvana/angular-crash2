using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerDAL.Databases;
using TaskTrackerDAL.Entities;
using TaskTrackerDAL.Functions.IServices;
using TaskTrackerDAL.Util.Functions.IServices;
using TaskTrackerDAL.Util.Functions.Services;

namespace TaskTrackerDAL.Functions.Services
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly TaskTrackerDBContext _context;
        private IGenericService<TaskEntity> _tasks;

        public UnityOfWork(TaskTrackerDBContext context)
        {
            _context = context;
        }

        public IGenericService<TaskEntity> Tasks => _tasks ??= new GenericService<TaskEntity>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
