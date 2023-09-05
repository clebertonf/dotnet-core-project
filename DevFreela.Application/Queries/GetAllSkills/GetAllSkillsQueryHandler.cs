using DevFreela.Application.ViewModels;
using DevFreela.infrastructure.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetAllSkillsQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<SkillViewModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = _dbContext.Skills;
            var skillsViewModel = skills.Select(s => new SkillViewModel(s.Id, s.Description)).ToList();

            return skillsViewModel;
        }
    }
}
