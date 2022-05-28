using System.Collections.Generic;
using Central.Core.Entities;

namespace Central.Core.Interfaces.Repositories
{
    public interface IDepartmentalVoteRepository : IRepository<DepartmentalVoteEntity>
    {
        /**
         * SELECT Count(*) FROM `DepartmentalVotes` dv
         * INNER JOIN `Options` o ON dv.Option_Name = o.Name
         * WHERE o.Election_Id = {electionId}
         */
        bool WasAlreadyFetched(int electionId);

        /**
         * SELECT dv.Option_Name, dv.Department_Name ,dv.VotesCount FROM DepartmentalVotes d
         * INNER JOIN `Options` o ON dv.Option_Name = o.Name
         * WHERE o.Election_Id = {electionId};
         */
        List<DepartmentalVoteEntity> GetResults(int electionId);

        /**
         * DELETE FROM DepartmentalVotes
         * WHERE Option_Name in (
         *  SELECT o.Name FROM `Options` o
         *  WHERE o.Election_Id = {electionId}
         * );
         */
        void DeleteElectionVotes(int electionId);
    }
}