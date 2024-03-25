using AutoMapper;
using EscapeRoom.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Application.EscapeRoomReview.Queries.GetEscapeRoomReview
{
    public class GetEscapeRoomReviewQueryHandler : IRequestHandler<GetEscapeRoomReviewQuery, IEnumerable<EscapeRoomReviewDto>>
    {
        private readonly IEscapeRoomReviewRepository _escapeRoomReviewRepository;
        private readonly IMapper _mapper;

        public GetEscapeRoomReviewQueryHandler(IEscapeRoomReviewRepository escapeRoomReviewRepository, IMapper mapper)
        {
            _escapeRoomReviewRepository = escapeRoomReviewRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EscapeRoomReviewDto>> Handle(GetEscapeRoomReviewQuery request, CancellationToken cancellationToken)
        {
            var result = await _escapeRoomReviewRepository.GetAllByEncodedName(request.EncodedName);

            var dtos = _mapper.Map<IEnumerable<EscapeRoomReviewDto>>(result);

            return dtos;
        }
    }
}
