using AutoMapper;
using Backend.Application.Dtos;
using Backend.Application.Features.DailyTasks.Commands;
using Backend.Application.UseCases.DailyTasks.Queries;
using MediatR;

namespace Backend.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DailyTasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        protected ResponseDto _response;

        public DailyTasksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            this._response = new ResponseDto();
        }

        /// <summary>
        /// Gets all daily tasks.
        /// </summary>
        /// <param name="take">The number of tasks to take.</param>
        /// <returns>A list of daily tasks.</returns>
        [HttpGet("get-all-task")]
        public async Task<IActionResult> GetAllTaskDaily([FromQuery] int take = 0)
        {
            GetAllDailyTaskQuery requestModel = new(take);
            return await CheckResult(requestModel);
        }

        /// <summary>
        /// Gets a daily task by ID.
        /// </summary>
        /// <param name="id">The task ID.</param>
        /// <returns>The daily task.</returns>
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetDailyTaskById([FromQuery] Guid id)
        {
            GetDailyTaskByIdQuery requestModel = new(id);
            var result = await _mediator.Send(requestModel);
            
            if (result == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Task not found!";
                return NotFound(_response);
            }

            _response.Result = result;
            _response.DisplayMessage = "Successfully!";
            return Ok(_response);
        }

        /// <summary>
        /// Gets daily tasks filtered by status.
        /// </summary>
        /// <param name="status">The status to filter by.</param>
        /// <param name="take">The number of tasks to take.</param>
        /// <returns>A list of daily tasks with the specified status.</returns>
        [HttpGet("get-by-status")]
        public async Task<IActionResult> GetDailyTasksByStatus([FromQuery] Status status, [FromQuery] int take = 10)
        {
            GetDailyTasksByStatusQuery requestModel = new(status, take);
            return await CheckResult(requestModel);
        }

        /// <summary>
        /// Gets statistics of daily tasks.
        /// </summary>
        /// <returns>Task statistics.</returns>
        [HttpGet("statistics")]
        public async Task<IActionResult> GetDailyTaskStatistics()
        {
            GetDailyTaskStatisticsQuery requestModel = new();
            return await CheckResult(requestModel);
        }

        /// <summary>
        /// Searches daily tasks by title or note.
        /// </summary>
        /// <param name="searchTerm">The search term.</param>
        /// <param name="take">The number of tasks to take.</param>
        /// <returns>A list of matching daily tasks.</returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchDailyTasks([FromQuery] string searchTerm, [FromQuery] int take = 10)
        {
            SearchDailyTasksQuery requestModel = new(searchTerm, take);
            return await CheckResult(requestModel);
        }

        /// <summary>
        /// Creates a new daily task.
        /// </summary>
        /// <param name="taskDailyDto">The task data.</param>
        /// <returns>True if successful.</returns>
        [HttpPost("create-task")]
        public async Task<IActionResult> AddTaskDaily([FromBody] TaskDailyDto taskDailyDto)
        {
            CreateDailyTaskCommand requestModel = _mapper.Map<CreateDailyTaskCommand>(taskDailyDto);
            return await CheckResult(requestModel);
        }

        /// <summary>
        /// Updates an existing daily task.
        /// </summary>
        /// <param name="id">The task ID.</param>
        /// <param name="taskDailyDto">The updated task data.</param>
        /// <returns>True if successful.</returns>
        [HttpPut("update-task")]
        public async Task<IActionResult> UpdateTaskDaily(Guid id, [FromBody] TaskDailyDto taskDailyDto)
        {
            UpdateDailyTaskCommand requestModel = _mapper.Map<UpdateDailyTaskCommand>(taskDailyDto);
            requestModel.Id = id;
            return await CheckResult(requestModel);
        }

        /// <summary>
        /// Deletes a daily task.
        /// </summary>
        /// <param name="id">The task ID.</param>
        /// <returns>True if successful.</returns>
        [HttpDelete("delete-task")]
        public async Task<IActionResult> DeleteTaskDaily([FromQuery] Guid id)
        {
            DeleteDailyTaskCommand requestModel = new(id);
            return await CheckResult(requestModel);
        }

        private async Task<IActionResult> CheckResult(object model)
        {
            var result = await _mediator.Send(model);
            if (result == null)
            {
                _response.IsSuccess = false;
                return BadRequest(_response);
            }

            _response.Result = result;
            _response.DisplayMessage = "Successfully!";
            return Ok(_response);
        }
    }
}