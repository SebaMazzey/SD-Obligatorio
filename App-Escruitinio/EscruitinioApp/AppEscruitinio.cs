using EscruitinioApp.Entities;
using EscruitinioApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscruitinioApp
{
    public partial class AppEscruitinio : Form
    {
        public AppEscruitinio()
        {
            InitializeComponent();
            LoadElections();
        }

        private void LoadElections()
        {
            List<Election> elections = ElectionService.GetElections();
            this.electionList.DataSource = elections;
            this.electionList.DisplayMember = "ElectionDisplay";
            this.electionList.ClearSelected();
        }

        private void LoadElectionResults(ElectionResults result, Election electionInfo)
        {
            this.resultElectionName.Text = "Elección: " + electionInfo.Name;
            var winner = ElectionService.GetElectionWinner(result);
            this.resultContent.Text = $"La opción mas votada de la elección fue \"{winner.Key}\" con un total de {winner.Value} votos.";

            // Fill global result
            List<string> globalResults = new();
            foreach (var option in electionInfo.Options)
            {
                var optionResults = result.Summary.FirstOrDefault(x => x.Key == option);
                var globalOption = "";
                if (!optionResults.Equals(default(KeyValuePair<string, int>)))
                    globalOption = $"{optionResults.Key}: {optionResults.Value} voto{((optionResults.Value > 1)?"s":"")}";
                else
                    globalOption = $"{option}: no hay votos";
                globalResults.Add(globalOption);
            }
            this.globalResultList.DataSource = globalResults;

            // Fill deparmental result
            List<string> deparmentResults = new();
            foreach (var department in result.DepartmentVoteResults)
            {
                deparmentResults.Add($"{department.Key}");
                foreach (var deparmentVotes in department.Value)
                {
                    var globalOption = $"\t{deparmentVotes.Key}: {deparmentVotes.Value} voto{((deparmentVotes.Value > 1) ? "s" : "")}";
                    deparmentResults.Add(globalOption);
                }
            }
            this.departmentalResult.DataSource = deparmentResults;

            this.initPanel.Hide();
            this.resultPanel.Show();
        }

        private void GetElectionResults_Click(object sender, EventArgs e)
        {
            Election selected = (Election)electionList.SelectedItem;
            if (selected != null)
            {
                var forceUpdate = updateResults.Checked.ToString();
                try
                {
                    var result = ElectionService.GetElectionResults(selected, forceUpdate);
                    LoadElectionResults(result, selected);
                }
                catch (Exception)
                {
                    MessageBox.Show("Se produjo un error al obtener los resultados de la elección.");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una elección para obtener los resultados");
            }
        }

        private void ReturnMenu_Click(object sender, EventArgs e)
        {
            // Clear result labels and lists
            this.resultContent.Text = "";
            this.globalResultList.DataSource = null;
            this.departmentalResult.DataSource = null;

            this.resultPanel.Hide();
            this.initPanel.Show();
        }
    }
}
