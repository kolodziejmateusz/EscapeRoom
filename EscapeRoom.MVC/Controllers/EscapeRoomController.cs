using AutoMapper;
using EscapeRoom.Application.EscapeRoom;
using EscapeRoom.Application.EscapeRoom.Commands.CreateEscapeRoom;
using EscapeRoom.Application.EscapeRoom.Commands.EditEscapeRoom;
using EscapeRoom.Application.EscapeRoom.Queries.GetAllEscapeRooms;
using EscapeRoom.Application.EscapeRoom.Queries.GetEscapeRoomByEncodedName;
using EscapeRoom.Application.EscapeRoomReview.Commands;
using EscapeRoom.MVC.Extensions;
using EscapeRoom.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        [Authorize(Roles = "Owner,Moderator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Owner,Moderator")]
        public async Task<IActionResult> Create(CreateEscapeRoomCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            //await _mediator.Send(command);

            this.SetNotification("success", $"Utworzono nowy Escape Room: {command.Name}");

            return RedirectToAction(nameof(Index));
        }

        [Route("EscapeRoom/{encodedName}/Edit")]
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
        [Route("EscapeRoom/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditEscapeRoomCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("EscapeRoom/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetEscapeRoomByEncodedNameQuery(encodedName));
            return View(dto);
        }


        [HttpPost]
        [Authorize(Roles = "Owner,Moderator")]
        [Route("EscapeRoom/EscapeRoomReview")]
        public async Task<IActionResult> CreateEscapeRoomReview(CreateEscapeRoomReviewCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);

            return Ok();
        }
    }
}
