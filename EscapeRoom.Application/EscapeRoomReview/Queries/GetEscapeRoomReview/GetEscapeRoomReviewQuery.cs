using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoomReview.Queries.GetEscapeRoomReview
{
    public class GetEscapeRoomReviewQuery : IRequest<IEnumerable<EscapeRoomReviewDto>>
    {
        public GetEscapeRoomReviewQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
        public string EncodedName { get; set; } = default!;
    }
}
