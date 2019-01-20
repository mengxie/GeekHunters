using System.Collections.Generic;
using System.Linq;
using GeekRegistrationSystem.Domains.Entities;
using GeekRegistrationSystem.Domains.Repositories.Interfaces;

namespace GeekRegistrationSystem.Domains.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly GeekHunterContext _dbContext;

        public SkillRepository(GeekHunterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Skill> GetSkills()
        {
            return _dbContext.Skills.ToList();
        }

    }
}
