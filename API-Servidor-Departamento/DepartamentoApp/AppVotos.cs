using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepartamentoApp
{
    public partial class AppVotos : Form
    {
        private string oldText = "";
        private string currText = "";
        private string sessionToken = "";

        public AppVotos()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string userCi = user_ci.Text;
            // Crear request http y guardarToken
            sessionToken = userCi;
            // If login sucess then change to votingMenu and display votin options
            if (sessionToken != "")
            {
                MessageBox.Show("Login sucess");
            } else
            {
                MessageBox.Show("Error al ingresar: CI no valida");
            }
        }

        private void UserCI_TextChanged(object sender, EventArgs e)
        {
            oldText = currText;
            currText = user_ci.Text;
            if (oldText.Length > currText.Length)
            {
                oldText = currText;
                return;
            }
            if (user_ci.Text.Length == currText.Length)
            {
                // Relleno con puntos
                if (new int[]{ 1,5}.Contains(user_ci.SelectionStart))
                {
                    user_ci.Text += ".";
                    user_ci.SelectionStart = user_ci.Text.Length;
                } else if (user_ci.SelectionStart == 2 && user_ci.Text.ElementAt(1) != '.')
                {
                    // Si intenta escribir algo donde va el punto lo agrego
                    user_ci.Text = user_ci.Text.Substring(0, 5) + "." + user_ci.Text.Substring(6,1);
                    user_ci.SelectionStart = user_ci.Text.Length;
                } else if (user_ci.SelectionStart == 6 && user_ci.Text.ElementAt(1) != '.')
                {
                    // Si intenta escribir algo donde va el punto lo agrego
                    user_ci.Text = user_ci.Text.Substring(0, 5) + "." + user_ci.Text.Substring(6, 1);
                    user_ci.SelectionStart = user_ci.Text.Length;
                } else if (user_ci.SelectionStart == 9) // Relleno con guion
                {
                    user_ci.Text += "-";
                    user_ci.SelectionStart = user_ci.Text.Length;
                } else if (user_ci.SelectionStart == 10 && user_ci.Text.ElementAt(9) != '-')
                {
                    // Si intenta escribir algo donde va el guión lo agrego
                    user_ci.Text = user_ci.Text.Substring(0, 9) + "-" + user_ci.Text.Substring(9,1);
                    user_ci.SelectionStart = user_ci.Text.Length;
                }
            }

        }
    }
}
