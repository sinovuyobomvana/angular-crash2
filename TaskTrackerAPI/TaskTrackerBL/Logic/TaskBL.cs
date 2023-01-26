using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerBL.DTOs.GET;
using TaskTrackerBL.DTOs.POST;
using TaskTrackerBL.DTOs.PUT;
using TaskTrackerDAL.Entities;
using TaskTrackerDAL.Functions.IServices;

namespace TaskTrackerBL.Logic
{
    public class TaskBL
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public TaskBL(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<IList<TaskDTO>> GetTasks()
        {
            var tasks = await _unityOfWork.Tasks.GetAll();

            if (tasks is null) throw new Exception("No Tasks Found");
            var results = _mapper.Map<IList<TaskDTO>>(tasks);

            return results;
        }

        public async Task<TaskDTO> GetTask(Guid id)
        {
            var task =  await _unityOfWork.Tasks.Get(q => q.Id == id);

            if (task == null) throw new Exception("Task Not Found");
            var result = _mapper.Map<TaskDTO>(task);

            return result;
        }

        public async Task AddTask(AddTaskDTO taskDTO)
        {
            if (taskDTO is null) throw new Exception("Invalid Task");

            var task = _mapper.Map<TaskEntity>(taskDTO);
            await _unityOfWork.Tasks.Insert(task);
            await _unityOfWork.Save();
        }

        public async Task UpdateTask(Guid id, UpdateTaskDTO taskDTO)
        {
            var task = await _unityOfWork.Tasks.Get(q => q.Id == id);

            if (task is null) throw new Exception("Task Not Found");

            _mapper.Map(taskDTO, task);
            _unityOfWork.Tasks.Update(task);
            await _unityOfWork.Save();
        }

        public async Task DeleteTask(Guid id)
        {
            var task = await _unityOfWork.Tasks.Get(q => q.Id == id);

            if (task is null) throw new Exception("Task Not Found");

            await _unityOfWork.Tasks.Delete(id);
            await _unityOfWork.Save();
        }

    }
}
