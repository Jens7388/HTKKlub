using HTKKlub.DataAccess;
using HTKKlub.DataAccess.Repos;
using HTKKlub.Entities;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTKKlub.MSTests
{
    [TestClass]
    public class RepoTests
    {
        /// <summary>
        /// Tests if a member returned by id is not null
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetMemberById()
        {
            MemberRepository repository;
            Member member;

            repository = new MemberRepository();
            member = await repository.GetByIdAsync(1);

            Assert.IsNotNull(member);
        }

        /// <summary>
        /// Tests if all members are returned
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetAllMembers()
        {
            MemberRepository repository;
            IEnumerable<Member> members;

            repository = new MemberRepository();
            members = await repository.GetAllAsync();

            Assert.IsTrue(members.Count() > 0);
        }

        [TestMethod]
        public async Task GetAllRankings()
        {
            RankingRepository repo;
            IEnumerable<Ranking> rankings;

            repo = new RankingRepository();
            rankings = await repo.GetAllAsync();

            Assert.IsTrue(rankings.Count() > 0);
        }
    }
}