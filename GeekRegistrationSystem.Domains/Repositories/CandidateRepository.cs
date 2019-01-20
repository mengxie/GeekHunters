using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GeekRegistrationSystem.Domains.Entities;
using GeekRegistrationSystem.Domains.Repositories.Interfaces;

namespace GeekRegistrationSystem.Domains.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly GeekHunterContext _dbContext;

        public CandidateRepository(GeekHunterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Candidate> GetCandidates()
        {
                      return _dbContext.Candidates
                    .Include(c => c.CandidateSkills.Select(cs => cs.Skill))
                    .ToList();
        }

        public IEnumerable<Candidate> GetCandidatesBySkills(IEnumerable<string> skills)
        {
            return
                _dbContext.Candidates
                    .Include(c => c.CandidateSkills.Select(cs => cs.Skill))
                    .Where(c => skills.All(s => c.CandidateSkills.Select(cs => cs.Skill.Name).Contains(s)))
                    .ToList();
        }

        public void SaveNewCandidate(Candidate candidate)
        {
            _dbContext.Candidates.Add(candidate);
            _dbContext.SaveChanges();
        }
    }
}
