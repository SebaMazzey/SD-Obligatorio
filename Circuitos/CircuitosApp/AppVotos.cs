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
        private string sessionToken = "";
        private static readonly HttpClient client = new HttpClient();

        private enum RequestType
        {
            Get,
            Post
        }

        public AppVotos()
        {
            client.BaseAddress = new Uri("http://localhost:8001");
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string userCi = user_ci.Text;
            // Crear request http y guardarToken
            try
            {
                this.sessionToken = CallDepartmentApiAsync("User/Verify?ci=" + userCi, RequestType.Get).Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un Error: " + ex.Message);
            }
            // If login sucess then change to votingMenu and display votin options
            if (sessionToken != "")
            {
                this.panelInit.Hide();
                this.panelVote.Show();
                MessageBox.Show("Login sucess. Token = " + sessionToken);
            } else
            {
                MessageBox.Show("Error al ingresar: CI no valida");
            }
        }

        private async Task<string> CallDepartmentApiAsync(string url, RequestType requestType, string authToken = "", string body = "")
        {
            
            if (authToken.Length != 0)
                client.DefaultRequestHeaders.Add("PEPITO", authToken);

            var response = "";
            try
            {
                switch (requestType)
                {
                    case RequestType.Get:
                        var httpResponse = client.GetAsync(url).GetAwaiter().GetResult();
                        if (httpResponse.StatusCode == HttpStatusCode.OK)
                            response = await httpResponse.Content.ReadAsStringAsync();
                        break;
                    case RequestType.Post:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
    }
}
