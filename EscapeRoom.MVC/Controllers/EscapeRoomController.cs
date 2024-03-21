using AutoMapper;
using EscapeRoom.Application.EscapeRoom;
using EscapeRoom.Application.EscapeRoom.Commands.CreateEscapeRoom;
using EscapeRoom.Application.EscapeRoom.Commands.EditEscapeRoom;
using EscapeRoom.Application.EscapeRoom.Queries.GetAllEscapeRooms;
using EscapeRoom.Application.EscapeRoom.Queries.GetEscapeRoomByEncodedName;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EscapeRoom.MVC.Controllers
{
    public class EscapeRoomController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EscapeRoomController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var escapeRoom = await _mediator.Send(new GetAllEscapeRoomsQuery());
            return View(escapeRoom);
        }

        [Authorize(Roles = "Owner")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateEscapeRoomCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("EscapeRoom/{encodedName}/edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetEscapeRoomByEncodedNameQuery(encodedName));

            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditEscapeRoomCommand model = _mapper.Map<EditEscapeRoomCommand>(dto);
            return View(model);
        }

        [HttpPost]
        [Route("EscapeRoom/{encodedName}/edit")]
        public async Task<IActionResult> Edit(string encodedName, EditEscapeRoomCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("EscapeRoom/{encodedName}/details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetEscapeRoomByEncodedNameQuery(encodedName));
            return View(dto);
        }
    }
}
