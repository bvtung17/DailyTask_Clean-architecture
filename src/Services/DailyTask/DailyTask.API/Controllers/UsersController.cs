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
        public async Task<IActionResult> GetAllTaskDaily([FromQuery] int take = 0)
        {
            try
            {
                GetAllUserQuery requestModel = new (take);
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
                return ExceptionError(e);
            }
        }
        [HttpGet("get-user-by-id")]
        public async Task<IActionResult> GetUserById([FromQuery] Guid id)
        {
            try
            {
                GetUserByIdQuery requestModel = new (id);
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
                return ExceptionError(e);
            }
        }
        [HttpPost("create-user")]
        public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                CreateUserCommand requestModel = _mapper.Map<CreateUserCommand>(userDto);
                var result = await _mediator.Send(requestModel);
                _response.DisplayMessage = "Sucessfully!";
                _response.Result = result;
                return Ok(_response);
            }
            catch (Exception e)
            {
                return ExceptionError(e);
            }
        }
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                UpdateUserCommand requestModel = _mapper.Map<UpdateUserCommand>(userDto);
                requestModel.Id = id;
                var result = await _mediator.Send(requestModel);
                _response.DisplayMessage = "Sucessfully!";
                _response.Result = result;
                return Ok(_response);
            }
            catch (Exception e)
            {
                return ExceptionError(e);
            }
        }
        [HttpDelete("delete-user")]
        public async Task<IActionResult> DeleteUser([FromQuery] Guid id)
        {
            try
            {
                DeleteUserCommand requestModel = new (id);
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
               return ExceptionError(e);
            }
        }
        private IActionResult ExceptionError(Exception e)
        {
            _response.Result = null;
            _response.DisplayMessage = "Error!";
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { e.Message };
            return BadRequest(_response);
        }
    }
}
   