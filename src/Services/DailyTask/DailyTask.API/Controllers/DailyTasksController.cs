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
            try
            {
                GetAllTaskDailyQuery requestModel = new GetAllTaskDailyQuery(take);
                var result = await _mediator.Send(requestModel);
                if (result == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                _response.Result = result;
                _response.DisplayMessage = "Sucessfully!";
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Result = null;
                _response.DisplayMessage = "Error!";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.Message };
                return BadRequest(_response);
            }
        }
        [HttpGet("get-task-by-id")]
        public async Task<IActionResult> GetTaskDailyById([FromQuery] int id)
        {
            try
            {
                GetTaskDailyByIdQuery requestModel = new GetTaskDailyByIdQuery(id);
                var result = await _mediator.Send(requestModel);
                if (result == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                _response.Result = result;
                _response.DisplayMessage = "Sucessfully!";
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Result = null;
                _response.DisplayMessage = "Error!";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.Message };
                return BadRequest(_response);
            }
        }
        [HttpGet("get-task-by-user-id")]
        public async Task<IActionResult> GetTaskDailyByUserId([FromQuery] int userId)
        {
            try
            {
                GetTaskDailyByUserIdQuery requestModel = new GetTaskDailyByUserIdQuery(userId);
                var result = await _mediator.Send(requestModel);
                if (result == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                _response.Result = result;
                _response.DisplayMessage = "Sucessfully!";
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Result = null;
                _response.DisplayMessage = "Error!";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.Message };
                return BadRequest(_response);
            }
        }
        [HttpPost("create-task")]
        public async Task<IActionResult> AddTaskDaily([FromBody] TaskDailyDto taskDailyDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                CreateTaskDailyCommand requestModel = _mapper.Map<CreateTaskDailyCommand>(taskDailyDto);
                var result = await _mediator.Send(requestModel);
                _response.DisplayMessage = "Sucessfully!";
                _response.Result = result;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Result = null;
                _response.DisplayMessage = "Error!";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.Message };
                return BadRequest(_response);
            }
        }
        [HttpPut("update-task")]
        public async Task<IActionResult> UpdateTaskDaily(int id, [FromBody] TaskDailyDto taskDailyDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                UpdateTaskDailyCommand requestModel = _mapper.Map<UpdateTaskDailyCommand>(taskDailyDto);
                requestModel.Id = id;
                var result = await _mediator.Send(requestModel);
                _response.DisplayMessage = "Sucessfully!";
                _response.Result = result;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Result = null;
                _response.DisplayMessage = "Error!";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.Message };
                return BadRequest(_response);
            }
        }
        [HttpDelete("delete-task")]
        public async Task<IActionResult> DeleteTaskDaily([FromQuery] int id)
        {
            try
            {
                DeleteTaskDailyCommand requestModel = new DeleteTaskDailyCommand(id);
                var result = await _mediator.Send(requestModel);
                if (result == null)
                {
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                _response.Result = result;
                _response.DisplayMessage = "Sucessfully!";
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Result = null;
                _response.DisplayMessage = "Error!";
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.Message };
                return BadRequest(_response);
            }
        }
    }
}