using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GeekRegistrationSystem.ApplicationServices;
using GeekRegistrationSystem.ApplicationServices.DTO;
using GeekRegistrationSystem.Domains.Entities;
using GeekRegistrationSystem.Domains.Repositories.Interfaces;
using GeekRegistrationSystem.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GeekRegistrationSystem.Tests.Services
{
    [TestClass]
    public class GeekHunterServiceTests
    {

        private Mock<ICandidateRepository> _candidateRepository;

        private Mock<ISkillRepository> _skillRepository;

        private GeekHunterService _geekHunterService;

        [TestInitialize]
        public void TestInitialize()
        {
            Mapper.Reset();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _candidateRepository = new Mock<ICandidateRepository>();
            _skillRepository = new Mock<ISkillRepository>();
            _geekHunterService = new GeekHunterService(_candidateRepository.Object, _skillRepository.Object);
        }


        public IEnumerable<Candidate> GetFakeCandidatesList()
        {
            return new List<Candidate>()
            {
                new Candidate() { Id = 1, FirstName = "do", LastName = "test"},
                new Candidate() { Id = 2, FirstName = "test", LastName = "this"}
            };
        }
        public IEnumerable<Skill> GetFakeSkills()
        {
            return new List<Skill>()
            {
                new Skill() {Id = 1, Name = "Java"},
                new Skill() {Id = 2, Name = "JavaScript"}
            };
        }

        public IEnumerable<string> GetFakeSkillList()
        {
            return new List<string>()
            {
                "Java"
            };
        }

        public CandidateDto GetNewCandidate()
        {
            return new CandidateDto()
            {
                FirstName = "dj"
            };
        }

        [TestMethod]
        public void GetAllCandidatesTest()
        {
            _candidateRepository.Setup(c => c.GetCandidates()).Returns(GetFakeCandidatesList);
            var candidates = _geekHunterService.GetAllCandidates();
            Assert.AreEqual(GetFakeCandidatesList().Count(), candidates.Count());
        }

        [TestMethod]
        public void FilterCandidatesTest()
        {

            _candidateRepository.Setup(c => c.GetCandidates()).Returns(GetFakeCandidatesList);
            var candidate = _geekHunterService.FilterCandidates(GetFakeSkillList());
            Assert.AreEqual(0, candidate.Count());
        }

        [TestMethod]
        public void GetCandidateTest_EmptyList()
        {

            _candidateRepository.Setup(c => c.GetCandidates()).Returns(GetFakeCandidatesList);
            var candidate = _geekHunterService.FilterCandidates(new List<string>());
            Assert.AreEqual(0, candidate.Count());
        }
        [TestMethod]
        public void GetAllSkillsTest()
        {
            _skillRepository.Setup(c => c.GetSkills()).Returns(GetFakeSkills);
            var skills = _geekHunterService.GetAllSkills();
            Assert.AreEqual(GetFakeSkills().Count(), skills.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SaveNewCandidateTest()
        {
            _geekHunterService.AddCandidate(GetNewCandidate());
        }

    }
}
