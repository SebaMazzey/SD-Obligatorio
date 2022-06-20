
using CircuitosApp.ExtraFormElements;

namespace DepartamentoApp
{
    partial class AppVotos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppVotos));
            this.ci_label = new System.Windows.Forms.Label();
            this.user_ci = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panelInit = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelVote = new System.Windows.Forms.Panel();
            this.confirmVoteElection = new System.Windows.Forms.Button();
            this.votingExplanationLabel = new System.Windows.Forms.Label();
            this.votingOptions = new CircuitosApp.ExtraFormElements.RadioButtonList();
            this.label2 = new System.Windows.Forms.Label();
            this.panelInit.SuspendLayout();
            this.panelVote.SuspendLayout();
            this.SuspendLayout();
            // 
            // ci_label
            // 
            this.ci_label.AutoSize = true;
            this.ci_label.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ci_label.Location = new System.Drawing.Point(238, 204);
            this.ci_label.Name = "ci_label";
            this.ci_label.Size = new System.Drawing.Size(42, 30);
            this.ci_label.TabIndex = 0;
            this.ci_label.Text = "C.I.";
            // 
            // user_ci
            // 
            this.user_ci.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.user_ci.Location = new System.Drawing.Point(286, 201);
            this.user_ci.MaxLength = 11;
            this.user_ci.Name = "user_ci";
            this.user_ci.PlaceholderText = "12345678";
            this.user_ci.Size = new System.Drawing.Size(100, 35);
            this.user_ci.TabIndex = 1;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLogin.Location = new System.Drawing.Point(330, 255);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(100, 37);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Ingresar";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.ButtonLogin_Click);
            // 
            // panelInit
            // 
            this.panelInit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelInit.Controls.Add(this.label4);
            this.panelInit.Controls.Add(this.label3);
            this.panelInit.Controls.Add(this.label1);
            this.panelInit.Controls.Add(this.user_ci);
            this.panelInit.Controls.Add(this.buttonLogin);
            this.panelInit.Controls.Add(this.ci_label);
            this.panelInit.Location = new System.Drawing.Point(12, 12);
            this.panelInit.Name = "panelInit";
            this.panelInit.Size = new System.Drawing.Size(760, 437);
            this.panelInit.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(250, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 50);
            this.label4.TabIndex = 5;
            this.label4.Text = "Por favor ingrese su cedula y \r\npresione el boton \"Ingresar\".";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(98, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(565, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bienvenido al Sistema de Votación Digital";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(392, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "(Sin puntos ni guiones)";
            // 
            // panelVote
            // 
            this.panelVote.Controls.Add(this.confirmVoteElection);
            this.panelVote.Controls.Add(this.votingExplanationLabel);
            this.panelVote.Controls.Add(this.votingOptions);
            this.panelVote.Controls.Add(this.label2);
            this.panelVote.Location = new System.Drawing.Point(12, 12);
            this.panelVote.Name = "panelVote";
            this.panelVote.Size = new System.Drawing.Size(760, 437);
            this.panelVote.TabIndex = 3;
            this.panelVote.Visible = false;
            // 
            // confirmVoteElection
            // 
            this.confirmVoteElection.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confirmVoteElection.Location = new System.Drawing.Point(595, 362);
            this.confirmVoteElection.Name = "confirmVoteElection";
            this.confirmVoteElection.Size = new System.Drawing.Size(138, 70);
            this.confirmVoteElection.TabIndex = 3;
            this.confirmVoteElection.Text = "Confirmar mi elección";
            this.confirmVoteElection.UseVisualStyleBackColor = true;
            this.confirmVoteElection.Click += new System.EventHandler(this.ConfirmVoteElection_Click);
            // 
            // votingExplanationLabel
            // 
            this.votingExplanationLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.votingExplanationLabel.Location = new System.Drawing.Point(12, 48);
            this.votingExplanationLabel.Name = "votingExplanationLabel";
            this.votingExplanationLabel.Size = new System.Drawing.Size(736, 107);
            this.votingExplanationLabel.TabIndex = 2;
            this.votingExplanationLabel.Text = resources.GetString("votingExplanationLabel.Text");
            // 
            // votingOptions
            // 
            this.votingOptions.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.votingOptions.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.votingOptions.FormattingEnabled = true;
            this.votingOptions.Location = new System.Drawing.Point(12, 158);
            this.votingOptions.Name = "votingOptions";
            this.votingOptions.Size = new System.Drawing.Size(250, 274);
            this.votingOptions.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(256, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 38);
            this.label2.TabIndex = 0;
            this.label2.Text = "Menu de Votación";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AppVotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panelVote);
            this.Controls.Add(this.panelInit);
            this.Name = "AppVotos";
            this.Text = "App Votación";
            this.panelInit.ResumeLayout(false);
            this.panelInit.PerformLayout();
            this.panelVote.ResumeLayout(false);
            this.panelVote.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ci_label;
        private System.Windows.Forms.TextBox user_ci;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Panel panelInit;
        private System.Windows.Forms.Panel panelVote;
        private System.Windows.Forms.Label label2;
        private RadioButtonList votingOptions;
        private System.Windows.Forms.Label votingExplanationLabel;
        private System.Windows.Forms.Button confirmVoteElection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

