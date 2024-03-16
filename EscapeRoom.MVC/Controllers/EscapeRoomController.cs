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

        public async Task<IActionResult> Index()
        {
            var escapeRoom = await _escapeRoomService.GetAll();
            return View(escapeRoom);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EscapeRoomDto escapeRoomDto)
        {
            if (!ModelState.IsValid)
            {
                return View(escapeRoomDto);
            }
            await _escapeRoomService.Create(escapeRoomDto);
            return RedirectToAction(nameof(Index)); //TODO
        }
    }
}
