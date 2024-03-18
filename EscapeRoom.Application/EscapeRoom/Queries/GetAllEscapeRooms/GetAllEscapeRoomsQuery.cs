using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoom.Queries.GetAllEscapeRooms
{
    public class GetAllEscapeRoomsQuery : IRequest<IEnumerable<EscapeRoomDto>>
    {
    }
}
