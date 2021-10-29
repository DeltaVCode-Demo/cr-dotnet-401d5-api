using SchoolAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Services.Database
{
    public class DatabaseHotelRoomRepository : IHotelRoomRepository
    {
        private readonly SchoolDbContext _context;

        public DatabaseHotelRoomRepository(SchoolDbContext context)
        {
            _context = context;
        }
    }
}
