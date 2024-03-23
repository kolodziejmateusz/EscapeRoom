using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoom.Commands.DeleteEscapeRoom
{
    public class DeleteEscapeRoomCommand : IRequest
    {
        public DeleteEscapeRoomCommand(string encodedName)
        {
            EncodedName = encodedName;
        }

        public string EncodedName { get; set; }
    }
}
