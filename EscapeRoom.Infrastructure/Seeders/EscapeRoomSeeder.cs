using EscapeRoom.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoom.Infrastructure.Seeders
{
    public class EscapeRoomSeeder
    {
        private readonly EscapeRoomDbContext _dbContext;

        public EscapeRoomSeeder(EscapeRoomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync()) 
            {
                if(!_dbContext.EscapeRooms.Any())
                {
                    var escapeRoom1 = new Domain.Entities.EscapeRoom()
                    {
                        Name = "Stary sklep z zabawkami",
                        Description = "Pewnego dnia, ukazała się szokująca wiadomość... W trakcie tworzenia zabawek właściciel przypadkowo zabił swoją córeczkę. Pogrążony w rozpaczy, zaszył się w warsztacie na wiele miesięcy i rzucił w wir pracy.",
                        AddressDetails = new()
                        {
                            PhoneNumber = "+48 123 456 789",
                            Street = "Szlak 16a/2",
                            City = "Kraków",
                            PostalCode = "31-000"
                        }
                    };
                    var escapeRoom2 = new Domain.Entities.EscapeRoom()
                    {
                        Name = "Tajemnicza willa doktora Jekylla",
                        Description = "Wizyta w dawno opuszczonej willi doktora Jekylla staje się niebezpieczną podróżą przez mroczne sekrety i eksperymenty. Czy uda Ci się uniknąć losu jego pacjentów?",
                        AddressDetails = new()
                        {
                            PhoneNumber = "+48 111 222 333",
                            Street = "Jekylla 5",
                            City = "Warszawa",
                            PostalCode = "00-001"
                        }
                    };
                    escapeRoom1.EncodeName();
                    escapeRoom2.EncodeName();
                    _dbContext.EscapeRooms.Add(escapeRoom1);
                    _dbContext.EscapeRooms.Add(escapeRoom2);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
