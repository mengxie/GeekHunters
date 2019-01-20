using System;
using AutoMapper;
using GeekRegistrationSystem.Domains.Entities;
using GeekRegistrationSystem.Domains.Repositories.Interfaces;
using GeekRegistrationSystem.ApplicationServices.DTO;
using GeekRegistrationSystem.ApplicationServices.Interfaces;
using System.Collections.Generic;
using log4net;

namespace GeekRegistrationSystem.ApplicationServices
{
    public class GeekHunterService: IGeekHunterService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ISkillRepository _skillRepository;
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GeekHunterService(ICandidateRepository candidateRepository, ISkillRepository skillRepository)
        {
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
        }

        public IEnumerable<CandidateDto> GetAllCandidates()
        {
            try
            {
                var candidates = _candidateRepository.GetCandidates();
                return (Mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateDto>>(candidates));

            }
            catch (Exception ex)
            {
                Log.Error("Error occurred in GetAllCandidates: " + ex.Message);
                throw;
            }
        }

        public IEnumerable<CandidateDto> FilterCandidates(IEnumerable<string> skills)
        {
            try
            {
                var candidate = _candidateRepository.GetCandidatesBySkills(skills);
                return (Mapper.Map<IEnumerable<Candidate>, IEnumerable<CandidateDto>>(candidate));
            }
            catch (Exception ex)
            {
                Log.Error("Error occurred in FilterCandidates: " + ex.Message);
                throw;
            }
        }

        public void AddCandidate(CandidateDto candidate)
        {
            if (candidate.FirstName == null || candidate.LastName == null)
                throw new ArgumentNullException();

            var newCandidate = new Candidate()
            {
                FirstName = candidate.FirstName,
                LastName = candidate.LastName
            };
            if (candidate.Skills.Count > 0)
            {
                foreach (var skill in candidate.Skills)
                {
                    var candidateSkill = new CandidateSkill
                    {
                        SkillId = skill.Id,
                        CandidateId = candidate.Id
                    };
                    newCandidate.CandidateSkills.Add(candidateSkill);
                }
            }

            try
            {
                _candidateRepository.SaveNewCandidate(newCandidate);
            }

            catch (Exception ex)
            {
                Log.Error("Error occurred in AddCandidate: " + ex.Message);
                throw;
            }
        }

        public IEnumerable<SkillDto> GetAllSkills()
        {
            try
            {
                var skills = _skillRepository.GetSkills();
                return (Mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDto>>(skills));
            }
            catch (Exception ex)
            {
                Log.Error("Error occurred in GetAllSkills: " + ex.Message);
                throw;
            }
        }
    }
}
