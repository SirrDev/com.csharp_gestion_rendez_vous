namespace priseRendezVous
{
    partial class rfPatient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rendezvousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medecinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rendezVousToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.agendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.quiterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelAccueil = new System.Windows.Forms.Panel();
            this.picAccueil = new System.Windows.Forms.PictureBox();
            this.labelBienvenue = new System.Windows.Forms.Label();
            this.btnAccueilPatients = new System.Windows.Forms.Button();
            this.btnAccueilMedecins = new System.Windows.Forms.Button();
            this.btnAccueilRdv = new System.Windows.Forms.Button();
            this.btnAccueilSoins = new System.Windows.Forms.Button();
            this.btnAccueilParametres = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelAccueil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAccueil)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientToolStripMenuItem,
            this.parametresToolStripMenuItem,
            this.quiterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(698, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(230, 240, 255); // bleu clair
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.soinToolStripMenuItem,
            this.rendezvousToolStripMenuItem,
            this.ajouterToolStripMenuItem});
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.patientToolStripMenuItem.Text = "Patient";
            // 
            // soinToolStripMenuItem
            // 
            this.soinToolStripMenuItem.Name = "soinToolStripMenuItem";
            this.soinToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.soinToolStripMenuItem.Text = "Soin";
            this.soinToolStripMenuItem.Click += new System.EventHandler(this.soinToolStripMenuItem_Click);
            // 
            // rendezvousToolStripMenuItem
            // 
            this.rendezvousToolStripMenuItem.Name = "rendezvousToolStripMenuItem";
            this.rendezvousToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rendezvousToolStripMenuItem.Text = "Rendez-Vous";
            this.rendezvousToolStripMenuItem.Click += new System.EventHandler(this.rendezvousToolStripMenuItem_Click);
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            this.ajouterToolStripMenuItem.Click += new System.EventHandler(this.ajouterToolStripMenuItem_Click);
            // 
            // parametresToolStripMenuItem
            // 
            this.parametresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.medecinsToolStripMenuItem,
            this.rendezVousToolStripMenuItem1,
            this.agendaToolStripMenuItem});
            this.parametresToolStripMenuItem.Name = "parametresToolStripMenuItem";
            this.parametresToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.parametresToolStripMenuItem.Text = "Parametres";
            // 
            // medecinsToolStripMenuItem
            // 
            this.medecinsToolStripMenuItem.Name = "medecinsToolStripMenuItem";
            this.medecinsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.medecinsToolStripMenuItem.Text = "Medecins";
            this.medecinsToolStripMenuItem.Click += new System.EventHandler(this.medecinsToolStripMenuItem_Click);
            // 
            // rendezVousToolStripMenuItem1
            // 
            this.rendezVousToolStripMenuItem1.Name = "rendezVousToolStripMenuItem1";
            this.rendezVousToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.rendezVousToolStripMenuItem1.Text = "Rendez-Vous";
            this.rendezVousToolStripMenuItem1.Click += new System.EventHandler(this.rendezVousToolStripMenuItem1_Click);
            // 
            // agendaToolStripMenuItem
            // 
            this.agendaToolStripMenuItem.Name = "agendaToolStripMenuItem";
            this.agendaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agendaToolStripMenuItem.Text = "Soin";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // btnQuitter
            // 
            this.btnQuitter.Location = new System.Drawing.Point(601, 0);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(97, 24);
            this.btnQuitter.TabIndex = 3;
            this.btnQuitter.Text = "Se deconnecter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // quiterToolStripMenuItem
            // 
            this.quiterToolStripMenuItem.Name = "quiterToolStripMenuItem";
            this.quiterToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.quiterToolStripMenuItem.Text = "Quiter";
            this.quiterToolStripMenuItem.Click += new System.EventHandler(this.quiterToolStripMenuItem_Click);
            // 
            // panelAccueil
            // 
            this.panelAccueil.BackColor = System.Drawing.Color.White;
            this.panelAccueil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAccueil.Location = new System.Drawing.Point(100, 60);
            this.panelAccueil.Size = new System.Drawing.Size(700, 400);
            this.panelAccueil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAccueil.Controls.Add(this.picAccueil);
            this.panelAccueil.Controls.Add(this.labelBienvenue);
            this.panelAccueil.Controls.Add(this.btnAccueilPatients);
            this.panelAccueil.Controls.Add(this.btnAccueilMedecins);
            this.panelAccueil.Controls.Add(this.btnAccueilRdv);
            this.panelAccueil.Controls.Add(this.btnAccueilSoins);
            this.panelAccueil.Controls.Add(this.btnAccueilParametres);
            // 
            // picAccueil
            // 
            this.picAccueil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAccueil.Size = new System.Drawing.Size(80, 80);
            this.picAccueil.Location = new System.Drawing.Point(310, 20);
            // 
            // labelBienvenue
            // 
            this.labelBienvenue.Text = "Bienvenue !";
            this.labelBienvenue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelBienvenue.Location = new System.Drawing.Point(200, 110);
            this.labelBienvenue.Size = new System.Drawing.Size(300, 40);
            this.labelBienvenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccueilPatients
            // 
            this.btnAccueilPatients.Text = "Gérer les patients";
            this.btnAccueilPatients.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAccueilPatients.Size = new System.Drawing.Size(200, 40);
            this.btnAccueilPatients.Location = new System.Drawing.Point(70, 180);
            this.btnAccueilPatients.Click += new System.EventHandler(this.btnAccueilPatients_Click);
            // 
            // btnAccueilMedecins
            // 
            this.btnAccueilMedecins.Text = "Gérer les médecins";
            this.btnAccueilMedecins.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAccueilMedecins.Size = new System.Drawing.Size(200, 40);
            this.btnAccueilMedecins.Location = new System.Drawing.Point(430, 180);
            this.btnAccueilMedecins.Click += new System.EventHandler(this.btnAccueilMedecins_Click);
            // 
            // btnAccueilRdv
            // 
            this.btnAccueilRdv.Text = "Prendre un rendez-vous";
            this.btnAccueilRdv.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAccueilRdv.Size = new System.Drawing.Size(270, 40);
            this.btnAccueilRdv.Location = new System.Drawing.Point(215, 240);
            this.btnAccueilRdv.Click += new System.EventHandler(this.btnAccueilRdv_Click);
            // 
            // btnAccueilSoins
            // 
            this.btnAccueilSoins.Text = "Gérer les soins";
            this.btnAccueilSoins.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAccueilSoins.Size = new System.Drawing.Size(200, 40);
            this.btnAccueilSoins.Location = new System.Drawing.Point(70, 300);
            this.btnAccueilSoins.Click += new System.EventHandler(this.btnAccueilSoins_Click);
            // 
            // btnAccueilParametres
            // 
            this.btnAccueilParametres.Text = "Paramètres";
            this.btnAccueilParametres.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAccueilParametres.Size = new System.Drawing.Size(200, 40);
            this.btnAccueilParametres.Location = new System.Drawing.Point(430, 300);
            this.btnAccueilParametres.Click += new System.EventHandler(this.btnAccueilParametres_Click);
            // 
            // rfPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panelAccueil);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "rfPatient";
            this.Text = "Prise de rendez-vous medical";
            this.Load += new System.EventHandler(this.rfPatient_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelAccueil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAccueil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rendezvousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.ToolStripMenuItem medecinsToolStripMenuItem;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.ToolStripMenuItem rendezVousToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem agendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quiterToolStripMenuItem;
        private System.Windows.Forms.Panel panelAccueil;
        private System.Windows.Forms.PictureBox picAccueil;
        private System.Windows.Forms.Label labelBienvenue;
        private System.Windows.Forms.Button btnAccueilPatients;
        private System.Windows.Forms.Button btnAccueilMedecins;
        private System.Windows.Forms.Button btnAccueilRdv;
        private System.Windows.Forms.Button btnAccueilSoins;
        private System.Windows.Forms.Button btnAccueilParametres;
    }
}