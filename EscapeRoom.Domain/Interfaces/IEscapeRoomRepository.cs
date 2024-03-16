﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Domain.Interfaces
{
    public interface IEscapeRoomRepository
    {
        Task Create(Domain.Entities.EscapeRoom escapeRoom);
        Task<Domain.Entities.EscapeRoom?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.EscapeRoom>> GetAll();
    }
}
