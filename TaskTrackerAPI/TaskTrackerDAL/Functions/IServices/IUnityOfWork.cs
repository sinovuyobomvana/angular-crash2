using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerDAL.Entities;
using TaskTrackerDAL.Util.Functions.IServices;

namespace TaskTrackerDAL.Functions.IServices
{
    public interface IUnityOfWork: IDisposable
    {
        IGenericService<TaskEntity> Tasks { get; }

        Task Save();

    }
}
