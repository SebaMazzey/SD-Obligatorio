using CircuitosApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartamentoApp
{
    public partial class AppVotos : Form
    {
        private readonly UserService _userService;
        private string userCi = "";
        private List<string> options = new();
        private readonly int circuitNumber;

        public AppVotos(int circuitNumber)
        {
            _userService = new UserService();
            this.circuitNumber = circuitNumber;
            InitializeComponent();
            LoadVotingOptions();
        }

        private void LoadVotingOptions()
        {
            try
            {
                // Get options and total rows to create
                List<string> options = VoteService.GetVotingOptions();
                this.options = options;
                this.votingOptions.DataSource = options;
                this.votingOptions.ClearSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener opciones de votación" + ex.Message +
                    ". Por favor informar al encargado del circuito");
            }
        }

        private void ClearAndShuffleOptions()
        {
            // Randomize list order
            var rnd = new Random();
            this.options = this.options.OrderBy(x => rnd.Next()).ToList();
            // Reasign list and clear selection
            this.votingOptions.DataSource = this.options;
            this.votingOptions.ClearSelected();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            this.userCi = user_ci.Text;
            try
            {
                // If login sucess then change to votingMenu and display votin options
                if (_userService.LogInUser(userCi))
                {
                    this.panelInit.Hide();
                    this.panelVote.Show();
                    MessageBox.Show("Exito al ingresar. Proceda a votar");
                } else
                {
                    MessageBox.Show("Error al ingresar: CI no valida o ya voto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un Error: " + ex.Message);
            }
        }

        private void ConfirmVoteElection_Click(object sender, EventArgs e)
        {
            string selectedOption = (string)votingOptions.SelectedValue;
            if(!String.IsNullOrEmpty(selectedOption))
            {
                string message = "Usted a seleccionado la opcion \"" + selectedOption + "\". Desea confirmar su elección?";
                string title = "Confirmar elección";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message,title,buttons);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Enviar el voto
                        if (VoteService.SubmitVote(_userService.SessionToken, selectedOption, userCi, circuitNumber))
                        {
                            MessageBox.Show("Su voto fue enviado con exito");
                        }
                        else
                        {
                            string messageError = "Se produjo un error al enviar el voto." +
                                "Es posible que el tiempo expiro y tenga que volver a repetir el proceso." +
                                "Sera enviado nuevamente al menu de inicio";
                            MessageBox.Show(messageError, "Error al enviar voto");
                        }
                        _userService.ClearToken(); // Limpiar token
                        ClearAndShuffleOptions(); // Reordenar lista de opciones
                        this.user_ci.Text = ""; // Volver al home y limpiar campo CI
                        this.panelVote.Hide();
                        this.panelInit.Show();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Se produjo un error al enviar el voto." +
                            "Intente nuevamente o contacte al encargado");
                    }
                }
            } else
            {
                MessageBox.Show("Debe seleccionar una opción antes de confirmar");
            }
        }
    }
}
