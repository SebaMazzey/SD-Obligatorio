using EscruitinioApp.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscruitinioApp.Services
{
    public class ElectionService
    {
        private static List<ElectionInfo> electionInfos;
        public ElectionService()
        {
        }

        public static List<Election> GetElections()
        {
            try
            {
                var jsonResult = HttpService.CallDepartmentApiAsync("Election/GetAll", HttpService.RequestType.Get);
                electionInfos = JsonConvert.DeserializeObject<List<ElectionInfo>>(jsonResult);
                electionInfos.ForEach(e => e.Election.LoadNameDisplay());
                return electionInfos.Select(electionInfo => electionInfo.Election).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static ElectionResults GetElectionResults(Election election, string forceUpdate)
        {
            try
            {
                var electionId = GetElectionId(election);
                if (electionId != -1)
                {
                    var path = "Election/Results?electionId=" + electionId;
                    var jsonResult = HttpService.CallDepartmentApiAsync(path, HttpService.RequestType.Get, forceUpdate);
                    var result = JsonConvert.DeserializeObject<ElectionResults>(jsonResult);
                    return result;
                } else
                {
                    throw new Exception("La elección indicada no existe");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static int GetElectionId(Election election)
        {
            var result = electionInfos.FirstOrDefault(e => e.Election.Equals(election));
            return (result != null) ? result.ElectionId : -1; 
        }

        private class ElectionInfo
        {
            public Election Election { get; set; }
            public int ElectionId { get; set; }
        }

        public static KeyValuePair<string, int> GetElectionWinner(ElectionResults electionResults)
        {
            return electionResults.Summary.Aggregate((x, y) => x.Value > y.Value ? x : y);
        }
    }
}
