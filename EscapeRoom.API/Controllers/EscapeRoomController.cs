using AutoMapper;
using EscapeRoom.Application.EscapeRoom;
using EscapeRoom.Application.EscapeRoom.Queries.GetAllEscapeRooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EscapeRoom.API.Controllers
{
    [Route("api/escaperoom")]
    [ApiController]
    public class EscapeRoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EscapeRoomController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EscapeRoomDto>>> GetAll()
        {
            var escapeRooms = await _mediator.Send(new GetAllEscapeRoomsQuery());

            return Ok(escapeRooms);
        }
    }
}
