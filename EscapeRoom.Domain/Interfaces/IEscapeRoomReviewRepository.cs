﻿using EscapeRoom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Domain.Interfaces
{
    public interface IEscapeRoomReviewRepository
    {
        Task Create(EscapeRoomReview escapeRoomReview);
        Task<IEnumerable<EscapeRoomReview>> GetAllByEncodedName(string encodedName);
        Task<Domain.Entities.EscapeRoomReview> GetById(int id);
        Task Delete(int id);
    }
}
