using Central.Core.Services.Dto;

namespace Central.Core.Interfaces.Services
{
    public interface IElectionService
    {
        public ElectionResults GetElectionResults(string electionId);
    }
}