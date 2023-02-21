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
        [HttpGet("get-all-task")]
        public async Task<IActionResult> GetAllTaskDaily([FromQuery] int take = 0)
        {
                GetAllDailyTaskQuery requestModel = new(take);
                return await CheckResult(requestModel);
        }

        [HttpPost("create-task")]
        public async Task<IActionResult> AddTaskDaily([FromBody] TaskDailyDto taskDailyDto)
        {
                CreateDailyTaskCommand requestModel = _mapper.Map<CreateDailyTaskCommand>(taskDailyDto);
                return await CheckResult(requestModel);
        }
        [HttpPut("update-task")]
        public async Task<IActionResult> UpdateTaskDaily(Guid id, [FromBody] TaskDailyDto taskDailyDto)
        {
                UpdateDailyTaskCommand requestModel = _mapper.Map<UpdateDailyTaskCommand>(taskDailyDto);
                requestModel.Id = id;
                return await CheckResult(requestModel);
        }
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
            _response.DisplayMessage = "Sucessfully!";
            return Ok(_response);
        }    
    }
}