namespace EscapeRoom.Application.Services
{
    public interface IEscapeRoomService
    {
        Task Create(Domain.Entities.EscapeRoom escapeRoom);
    }
}