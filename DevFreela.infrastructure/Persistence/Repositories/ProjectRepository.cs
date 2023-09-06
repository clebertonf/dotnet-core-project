using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevFreela.infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _devFreelaDb;

        public ProjectRepository(DevFreelaDbContext devFreelaDb)
        {
            _devFreelaDb = devFreelaDb;
        }

        public async Task<List<Project>> GetAll()
        {
            return await _devFreelaDb.Projects.ToListAsync();
        }
    }
}
