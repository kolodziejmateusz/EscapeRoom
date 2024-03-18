using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoom.Queries.GetEscapeRoomByEncodedName
{
    public class GetEscapeRoomByEncodedNameQuery : IRequest<EscapeRoomDto>
    {
        public GetEscapeRoomByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }

        public string EncodedName { get; set; }
    }
}
