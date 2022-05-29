using System.Collections.Generic;
using System.Linq;
using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.Core.Services.Dto;
using Central.DAL.EFCore.Core;

namespace Central.DAL.EFCore.Repositories
{
    public class DepartmentalVoteRepository : EfRepository<DepartmentalVoteEntity>, IDepartmentalVoteRepository
    {
        public DepartmentalVoteRepository(CentralContext dbContext) : base(dbContext) { }

        public List<DepartmentalVoteEntity> GetResults(int electionId)
        {
            return this._dbContext.DepartamentalVotes
                .Join(this._dbContext.Options, dp => dp.OptionName, o => o.Name,
                    (dp, o) => new { Vote = dp, Option = o })
                .Where(e => e.Option.ElectionId == electionId)
                .Select(e => e.Vote)
                .ToList();
        }

        public void DeleteElectionVotes(int electionId)
        {
            this._dbContext.DepartamentalVotes.RemoveRange(
                this._dbContext.DepartamentalVotes
                    .Join(this._dbContext.Options, dp => dp.OptionName, o => o.Name,
                    (dp, o) => new { Vote = dp, Option = o })
                    .Where(e => e.Option.ElectionId == electionId)
                    .Select(e => e.Vote)
            );
        }
    }
}