using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Central.Core.Entities;
using Central.Core.Interfaces.Repositories;
using Central.Core.Services.Dto;
using Central.DAL.EFCore.Core;

namespace Central.DAL.EFCore.Repositories
{
    public class ElectionRepository : EfRepository<ElectionEntity>, IElectionRepository
    {
        public ElectionRepository(CentralContext dbContext) : base(dbContext) { }

        public bool ElectionIsValid(int electionId)
        {
            return this._dbContext.Elections.Any(e => e.Id == electionId && e.EndDate < System.DateTime.Now);
        }

        public bool IsDateAvailable(DateTime startDate, DateTime endDate)
        {
            return this._dbContext.Elections.Any(e => startDate > e.EndDate || endDate < e.StartDate);
        }

        public ElectionEntity CreateElection(ElectionEntity entity)
        {
            return this._dbContext.Elections.Add(entity).Entity;
        }

        public IEnumerable<ElectionInfo> GetAllElectionsInfo()
        {
            return this._dbContext.Elections.Select(e => new ElectionInfo()
            {
                ElectionId = e.Id,
                Election = new Election()
                {
                    Name = e.Name,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Options = this._dbContext.Options.Where(o => o.ElectionId == e.Id).Select(o => o.Name).ToList()
                }
            });
        }
    }
}