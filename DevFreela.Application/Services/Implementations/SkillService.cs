using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly string _connectionString;
        private readonly DevFreelaDbContext _dbContext;
        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public List<SkillViewModel> GetAll()
        {
            /* var skills = _dbContext.Skills;
               var skillsViewModel = skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();

               return skillsViewModel;
            */

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var query = "SELECT Id, Description FROM Skills";

                return sqlConnection.Query<SkillViewModel>(query).ToList();
            }
        }
    }
}
