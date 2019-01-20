using System.Collections.Generic;
using GeekRegistrationSystem.Domains.Entities;

namespace GeekRegistrationSystem.Domains.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        IEnumerable<Skill> GetSkills();
    }
}
