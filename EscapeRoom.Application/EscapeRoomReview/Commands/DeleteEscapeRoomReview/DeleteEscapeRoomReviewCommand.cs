using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoomReview.Commands.DeleteEscapeRoomReview
{
    public class DeleteEscapeRoomReviewCommand : IRequest
    {
        public DeleteEscapeRoomReviewCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
