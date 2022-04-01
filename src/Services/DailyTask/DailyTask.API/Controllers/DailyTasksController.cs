using AutoMapper;
using DailyTask.Application.Dtos;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Features.DailyTasks.Queries;
using MediatR;

namespace DailyTask.API.Controllers
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
        [HttpGet("get-all-task")]
        public async Task<IActionResult> GetAllTaskDaily([FromQuery] int take = 0)
        {
                GetAllTaskDailyQuery requestModel = new(take);
                return await CheckResult(requestModel);
        }
        [HttpGet("get-task-by-id")]
        public async Task<IActionResult> GetTaskDailyById([FromQuery] Guid id)
        {
                GetTaskDailyByIdQuery requestModel = new(id);
                return await CheckResult(requestModel);
        }
        [HttpGet("get-task-by-user-id")]
        public async Task<IActionResult> GetTaskDailyByUserId(Guid userId)
        {
                GetTaskDailyByUserIdQuery requestModel = new(userId);
                return await CheckResult(requestModel);
        }
        [HttpPost("create-task")]
        public async Task<IActionResult> AddTaskDaily([FromBody] TaskDailyDto taskDailyDto)
        {
                CreateTaskDailyCommand requestModel = _mapper.Map<CreateTaskDailyCommand>(taskDailyDto);
                return await CheckResult(requestModel);
        }
        [HttpPut("update-task")]
        public async Task<IActionResult> UpdateTaskDaily(Guid id, [FromBody] TaskDailyDto taskDailyDto)
        {
                UpdateTaskDailyCommand requestModel = _mapper.Map<UpdateTaskDailyCommand>(taskDailyDto);
                requestModel.Id = id;
                return await CheckResult(requestModel);
        }
        [HttpDelete("delete-task")]
        public async Task<IActionResult> DeleteTaskDaily([FromQuery] Guid id)
        {
                DeleteTaskDailyCommand requestModel = new(id);
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
            _response.DisplayMessage = "Sucessfully!";
            return Ok(_response);
        }    
    }
}