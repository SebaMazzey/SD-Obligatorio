using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Central.Core.Entities;
using Central.Core.Services.Dto;

namespace Central.Core.Interfaces.Repositories
{
    public interface IElectionRepository : IRepository<ElectionEntity>
    {
        bool ElectionIsValid(int electionId);

        bool IsDateAvailable(DateTime startDate, DateTime endDate);

        ElectionEntity CreateElection(ElectionEntity entity);
        IEnumerable<ElectionInfo> GetAllElectionsInfo();
    }
}