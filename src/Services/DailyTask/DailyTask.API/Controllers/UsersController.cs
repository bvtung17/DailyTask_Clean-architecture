using AutoMapper;
using DailyTask.Application.Dtos;
using DailyTask.Application.Features.DailyTasks.Commands;
using DailyTask.Application.Features.DailyTasks.Queries;
using MediatR;

namespace DailyTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        protected ResponseDto _response;
        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            this._response = new ResponseDto();
        }
        [HttpGet("get-all-user")]
        public async Task<IActionResult> GetAllUser([FromQuery] int take = 0)
        {
                GetAllUserQuery requestModel = new (take);
                return await CheckResult(requestModel);
        }
        [HttpGet("get-user-by-id")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
                GetUserByIdQuery requestModel = new (id);
                return await CheckResult(requestModel);
        }
        [HttpPost("create-user")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
                CreateUserCommand requestModel = _mapper.Map<CreateUserCommand>(userDto);
                return await CheckResult(requestModel);
        }
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto userDto)
        {
                UpdateUserCommand requestModel = _mapper.Map<UpdateUserCommand>(userDto);
                requestModel.Id = id;
                return await CheckResult(requestModel);         
        }
        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser([FromQuery] Guid id)
        {
                DeleteUserCommand requestModel = new (id);
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
   