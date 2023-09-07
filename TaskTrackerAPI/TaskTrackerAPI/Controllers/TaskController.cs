using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTrackerBL.DTOs.GET;
using TaskTrackerBL.DTOs.POST;
using TaskTrackerBL.DTOs.PUT;
using TaskTrackerBL.Logic;
using TaskTrackerDAL.Entities;
using TaskTrackerDAL.Functions.IServices;

namespace TaskTrackerAPI.Controllers
{
    public class TaskController : BaseAPIController
    {
        private readonly TaskBL BL;
        private readonly IUnityOfWork _unityOfWork;
        private readonly ILogger<TaskEntity> _logger;
        private readonly IMapper _mapper;

        public TaskController(IUnityOfWork unityOfWork, ILogger<TaskEntity> logger, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _logger = logger;
            _mapper = mapper;

            BL = new TaskBL(_unityOfWork, _mapper);
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
                var tasks = await BL.GetTasks();
                return Ok(tasks);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
                var tasks = await BL.GetTask(id);
                return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] AddTaskDTO task)
        {
                await BL.AddTask(task);
                return Ok();
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskDTO taskDTO)
        {
                await BL.UpdateTask(id, taskDTO); 
                return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await BL.DeleteTask(id);
            return Ok();
        }
    }
}
