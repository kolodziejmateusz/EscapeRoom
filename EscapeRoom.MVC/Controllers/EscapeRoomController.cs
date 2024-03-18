using EscapeRoom.Application.EscapeRoom;
using EscapeRoom.Application.EscapeRoom.Commands.CreateEscapeRoom;
using EscapeRoom.Application.EscapeRoom.Queries.GetAllEscapeRooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EscapeRoom.MVC.Controllers
{
    public class EscapeRoomController : Controller
    {
        private readonly IMediator _mediator;

        public EscapeRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var escapeRoom = await _mediator.Send(new GetAllEscapeRoomsQuery());
            return View(escapeRoom);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEscapeRoomCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
