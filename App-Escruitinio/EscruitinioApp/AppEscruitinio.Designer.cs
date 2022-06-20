
namespace EscruitinioApp
{
    partial class AppEscruitinio
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
            this.initPanel = new System.Windows.Forms.Panel();
            this.initUpdateResultLabel = new System.Windows.Forms.Label();
            this.updateResults = new System.Windows.Forms.CheckBox();
            this.initDescriptionLabel = new System.Windows.Forms.Label();
            this.getElectionResults = new System.Windows.Forms.Button();
            this.electionList = new EscruitinioApp.ExtraFormElements.RadioButtonList();
            this.initLabelTitle = new System.Windows.Forms.Label();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.departmentalResult = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.globalResultList = new System.Windows.Forms.ListBox();
            this.resultContent = new System.Windows.Forms.Label();
            this.resultTitle = new System.Windows.Forms.Label();
            this.resultElectionName = new System.Windows.Forms.Label();
            this.returnMenu = new System.Windows.Forms.Button();
            this.initPanel.SuspendLayout();
            this.resultPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // initPanel
            // 
            this.initPanel.Controls.Add(this.initUpdateResultLabel);
            this.initPanel.Controls.Add(this.updateResults);
            this.initPanel.Controls.Add(this.initDescriptionLabel);
            this.initPanel.Controls.Add(this.getElectionResults);
            this.initPanel.Controls.Add(this.electionList);
            this.initPanel.Controls.Add(this.initLabelTitle);
            this.initPanel.Location = new System.Drawing.Point(20, 7);
            this.initPanel.Name = "initPanel";
            this.initPanel.Size = new System.Drawing.Size(760, 437);
            this.initPanel.TabIndex = 4;
            // 
            // initUpdateResultLabel
            // 
            this.initUpdateResultLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.initUpdateResultLabel.Location = new System.Drawing.Point(553, 240);
            this.initUpdateResultLabel.Name = "initUpdateResultLabel";
            this.initUpdateResultLabel.Size = new System.Drawing.Size(194, 113);
            this.initUpdateResultLabel.TabIndex = 7;
            this.initUpdateResultLabel.Text = "Si los resultados ya fueron escrutados previamente y desea repetir el proceso mar" +
    "que entonces la casilla a contianuación.\r\n";
            // 
            // updateResults
            // 
            this.updateResults.AutoSize = true;
            this.updateResults.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.updateResults.Location = new System.Drawing.Point(553, 356);
            this.updateResults.Name = "updateResults";
            this.updateResults.Size = new System.Drawing.Size(177, 25);
            this.updateResults.TabIndex = 6;
            this.updateResults.Text = "Actualizar Resultados";
            this.updateResults.UseVisualStyleBackColor = true;
            // 
            // initDescriptionLabel
            // 
            this.initDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.initDescriptionLabel.Location = new System.Drawing.Point(21, 50);
            this.initDescriptionLabel.Name = "initDescriptionLabel";
            this.initDescriptionLabel.Size = new System.Drawing.Size(564, 54);
            this.initDescriptionLabel.TabIndex = 5;
            this.initDescriptionLabel.Text = "A continuación se le presenta la lista de las ultimas elecciones realizadas. Sele" +
    "ccione una para ver los resultados.\r\n";
            // 
            // getElectionResults
            // 
            this.getElectionResults.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.getElectionResults.Location = new System.Drawing.Point(553, 387);
            this.getElectionResults.Name = "getElectionResults";
            this.getElectionResults.Size = new System.Drawing.Size(194, 34);
            this.getElectionResults.TabIndex = 4;
            this.getElectionResults.Text = "Obtener resultados";
            this.getElectionResults.UseVisualStyleBackColor = true;
            this.getElectionResults.Click += new System.EventHandler(this.GetElectionResults_Click);
            // 
            // electionList
            // 
            this.electionList.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.electionList.FormattingEnabled = true;
            this.electionList.Location = new System.Drawing.Point(21, 107);
            this.electionList.Name = "electionList";
            this.electionList.Size = new System.Drawing.Size(526, 314);
            this.electionList.TabIndex = 3;
            // 
            // initLabelTitle
            // 
            this.initLabelTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.initLabelTitle.Location = new System.Drawing.Point(70, 10);
            this.initLabelTitle.Name = "initLabelTitle";
            this.initLabelTitle.Size = new System.Drawing.Size(620, 40);
            this.initLabelTitle.TabIndex = 2;
            this.initLabelTitle.Text = "Bienvenido a la app de resultados electorales\r\n";
            // 
            // resultPanel
            // 
            this.resultPanel.Controls.Add(this.departmentalResult);
            this.resultPanel.Controls.Add(this.label2);
            this.resultPanel.Controls.Add(this.label1);
            this.resultPanel.Controls.Add(this.globalResultList);
            this.resultPanel.Controls.Add(this.resultContent);
            this.resultPanel.Controls.Add(this.resultTitle);
            this.resultPanel.Controls.Add(this.resultElectionName);
            this.resultPanel.Controls.Add(this.returnMenu);
            this.resultPanel.Location = new System.Drawing.Point(20, 7);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(760, 437);
            this.resultPanel.TabIndex = 8;
            this.resultPanel.Visible = false;
            // 
            // departmentalResult
            // 
            this.departmentalResult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.departmentalResult.FormattingEnabled = true;
            this.departmentalResult.ItemHeight = 21;
            this.departmentalResult.Items.AddRange(new object[] {
            "Voto si: x votos"});
            this.departmentalResult.Location = new System.Drawing.Point(347, 200);
            this.departmentalResult.Name = "departmentalResult";
            this.departmentalResult.Size = new System.Drawing.Size(383, 214);
            this.departmentalResult.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(419, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 30);
            this.label2.TabIndex = 6;
            this.label2.Text = "Resultado Departamental:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(52, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "Resultado Global:";
            // 
            // globalResultList
            // 
            this.globalResultList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.globalResultList.FormattingEnabled = true;
            this.globalResultList.ItemHeight = 21;
            this.globalResultList.Items.AddRange(new object[] {
            "Voto si: x votos"});
            this.globalResultList.Location = new System.Drawing.Point(21, 200);
            this.globalResultList.Name = "globalResultList";
            this.globalResultList.Size = new System.Drawing.Size(240, 214);
            this.globalResultList.TabIndex = 4;
            // 
            // resultContent
            // 
            this.resultContent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultContent.Location = new System.Drawing.Point(21, 104);
            this.resultContent.Name = "resultContent";
            this.resultContent.Size = new System.Drawing.Size(726, 46);
            this.resultContent.TabIndex = 3;
            this.resultContent.Text = "La opción mas votada de la elección fue \"Voto Sí\" \r\ncon un total de 5 votos.\r\n";
            // 
            // resultTitle
            // 
            this.resultTitle.AutoSize = true;
            this.resultTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultTitle.Location = new System.Drawing.Point(21, 74);
            this.resultTitle.Name = "resultTitle";
            this.resultTitle.Size = new System.Drawing.Size(112, 30);
            this.resultTitle.TabIndex = 2;
            this.resultTitle.Text = "Resultado:";
            // 
            // resultElectionName
            // 
            this.resultElectionName.AutoSize = true;
            this.resultElectionName.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resultElectionName.Location = new System.Drawing.Point(21, 10);
            this.resultElectionName.Name = "resultElectionName";
            this.resultElectionName.Size = new System.Drawing.Size(131, 37);
            this.resultElectionName.TabIndex = 1;
            this.resultElectionName.Text = "Elección: ";
            // 
            // returnMenu
            // 
            this.returnMenu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.returnMenu.Location = new System.Drawing.Point(590, 10);
            this.returnMenu.Name = "returnMenu";
            this.returnMenu.Size = new System.Drawing.Size(157, 52);
            this.returnMenu.TabIndex = 0;
            this.returnMenu.Text = "Volver al listado";
            this.returnMenu.UseVisualStyleBackColor = true;
            this.returnMenu.Click += new System.EventHandler(this.ReturnMenu_Click);
            // 
            // AppEscruitinio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.initPanel);
            this.Controls.Add(this.resultPanel);
            this.Name = "AppEscruitinio";
            this.Text = "App Escruitinio";
            this.initPanel.ResumeLayout(false);
            this.initPanel.PerformLayout();
            this.resultPanel.ResumeLayout(false);
            this.resultPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel initPanel;
        private System.Windows.Forms.Label initLabelTitle;
        private ExtraFormElements.RadioButtonList electionList;
        private System.Windows.Forms.Button getElectionResults;
        private System.Windows.Forms.Label initDescriptionLabel;
        private System.Windows.Forms.Label initUpdateResultLabel;
        private System.Windows.Forms.CheckBox updateResults;
        private System.Windows.Forms.Panel resultPanel;
        private System.Windows.Forms.Button returnMenu;
        private System.Windows.Forms.Label resultElectionName;
        private System.Windows.Forms.Label resultContent;
        private System.Windows.Forms.Label resultTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox globalResultList;
        private System.Windows.Forms.ListBox departmentalResult;
        private System.Windows.Forms.Label label2;
    }
}

