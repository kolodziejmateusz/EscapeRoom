using EscapeRoom.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EscapeRoom.MVC.Controllers
{
    public class EscapeRoomController : Controller
    {
        private readonly IEscapeRoomService _escapeRoomService;

        public EscapeRoomController(IEscapeRoomService escapeRoomService)
        {
            _escapeRoomService = escapeRoomService;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.EscapeRoom escapeRoom)
        {
            await _escapeRoomService.Create(escapeRoom);
            return RedirectToAction(nameof(Create)); //TODO
        }
    }
}
