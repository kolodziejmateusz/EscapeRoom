using EscapeRoom.Application.EscapeRoom;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EscapeRoomDto escapeRoomDto)
        {
            await _escapeRoomService.Create(escapeRoomDto);
            return RedirectToAction(nameof(Create)); //TODO
        }
    }
}
