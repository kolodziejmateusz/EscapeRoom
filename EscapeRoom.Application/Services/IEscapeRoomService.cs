using EscapeRoom.Application.EscapeRoom;

namespace EscapeRoom.Application.Services
{
    public interface IEscapeRoomService
    {
        Task Create(EscapeRoomDto escapeRoomDto);
    }
}