using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Parts.API.Domain.Models;
using Parts.API.Domain.Repositories;
using Parts.API.Persistence.Contexts;

namespace Parts.API.Persistence.Repositories
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(PartsDBContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Role>> ListAsync()
        {
            return await context.Role.ToListAsync();
        }
    }
}