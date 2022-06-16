
using System.Globalization;

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
            this.label1 = new System.Windows.Forms.Label();
            this.user_ci = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panelInit = new System.Windows.Forms.Panel();
            this.panelVote = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelInit.SuspendLayout();
            this.panelVote.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "C.I.";
            // 
            // user_ci
            // 
            this.user_ci.Location = new System.Drawing.Point(361, 210);
            this.user_ci.MaxLength = 11;
            this.user_ci.Name = "user_ci";
            this.user_ci.PlaceholderText = "12345678";
            this.user_ci.Size = new System.Drawing.Size(100, 23);
            this.user_ci.TabIndex = 1;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(376, 251);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Ingresar";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // panelInit
            // 
            this.panelInit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelInit.Controls.Add(this.user_ci);
            this.panelInit.Controls.Add(this.buttonLogin);
            this.panelInit.Controls.Add(this.label1);
            this.panelInit.Location = new System.Drawing.Point(10, 10);
            this.panelInit.Name = "panelInit";
            this.panelInit.Size = new System.Drawing.Size(780, 430);
            this.panelInit.TabIndex = 3;
            // 
            // panelVote
            // 
            this.panelVote.Controls.Add(this.label2);
            this.panelVote.Location = new System.Drawing.Point(10, 10);
            this.panelVote.Name = "panelVote";
            this.panelVote.Size = new System.Drawing.Size(780, 430);
            this.panelVote.TabIndex = 3;
            this.panelVote.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(320, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Panel de Votación";
            // 
            // AppVotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox user_ci;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Panel panelInit;
        private System.Windows.Forms.Panel panelVote;
        private System.Windows.Forms.Label label2;
    }
}

