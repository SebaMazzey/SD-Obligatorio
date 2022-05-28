using System.Collections.ObjectModel;

namespace Central.Core.Services.Dto
{
    public class DepartmentVoteResults
    {
        public string DepartmentName { get; set; }
        public VoteResults VoteResults { get; set; }

        public DepartmentVoteResults(string departmentName, VoteResults voteResults)
        {
            DepartmentName = departmentName;
            VoteResults = voteResults;
        }
    }
}