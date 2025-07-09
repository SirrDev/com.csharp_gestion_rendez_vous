using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using priseRendezVous.View;
using System.Net;

namespace priseRendezVous
{
    public partial class rfPatient : Form
    {
        public rfPatient()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            // Effet de survol moderne sur le menu
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomMenuColorTable());
        }

        public rfPatient(string nomUtilisateur = null)
        {
            InitializeComponent();
            this.Load += rfPatient_Load;
            if (!string.IsNullOrEmpty(nomUtilisateur))
                labelBienvenue.Text = $"Bienvenue, {nomUtilisateur} !";
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPatient patientForm = new frmPatient();
            patientForm.MdiParent = this;
            patientForm.Show();
            patientForm.WindowState = FormWindowState.Maximized;
        }

        private void diponbiliteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            frmPatient patientForm = new frmPatient();
            patientForm.MdiParent = this;
            patientForm.Show();
            patientForm.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMedecin frmMedecin = new frmMedecin();
            frmMedecin.MdiParent = this;
            frmMedecin.Show();
            frmMedecin.WindowState = FormWindowState.Maximized;
        }

        private void rfPatient_Load(object sender, EventArgs e)
        {
            // Icône médicale (stéthoscope) en ligne (Icons8)
            string urlMedicalPng = "https://img.icons8.com/ios-filled/100/4a90e2/stethoscope.png";
            picAccueil.Image = LoadImageFromUrl(urlMedicalPng);
        }

        private System.Drawing.Image LoadImageFromUrl(string url)
        {
            using (var wc = new WebClient())
            {
                using (var s = new System.IO.MemoryStream(wc.DownloadData(url)))
                {
                    return System.Drawing.Image.FromStream(s);
                }
            }
        }

        private void OpenMdiChild(Form child)
        {
            // Fermer la fenêtre enfant courante s'il y en a une
            foreach (Form frm in this.MdiChildren)
                frm.Close();
            // Masquer l'accueil
            panelAccueil.Visible = false;
            // Ouvrir la nouvelle fenêtre enfant
            child.MdiParent = this;
            child.WindowState = FormWindowState.Maximized;
            child.FormClosed += (s, e) => {
                // Quand la fenêtre enfant se ferme, réafficher l'accueil
                if (this.MdiChildren.Length == 0)
                    panelAccueil.Visible = true;
            };
            child.Show();
            child.BringToFront();
        }

        // Préparer les handlers pour les boutons d'accueil (à compléter selon la navigation souhaitée)
        private void btnAccueilPatients_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new View.frmPatient());
        }
        private void btnAccueilMedecins_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new View.frmMedecin());
        }
        private void btnAccueilRdv_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new View.frmRendezVous());
        }
        private void btnAccueilSoins_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new View.frmSoin());
        }
        // Désactiver le handler du bouton paramètres (pas de frmParametres)
        private void btnAccueilParametres_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La page Paramètres n'est pas encore disponible.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void medecinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new View.frmMedecin());
        }

        /// <summary>
        /// Methode Pour quitter le programme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            // Afficher une boîte de dialogue de confirmation
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment vous deconnecter ?", // Message
                "Confirmation", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question
            );

            // Vérifier la réponse de l'utilisateur
            if (result == DialogResult.OK)
            {
                Form1 connection = new Form1();
                connection.MdiParent = this;
                this.Close();
                connection.Show();
                //Application.Exit();
            }
        }

        private void rendezvousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new View.frmRendezVous());
        }

        private void soinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new View.frmSoin());
        }

        private void rendezVousToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenMdiChild(new View.frmRendezVous());
        }

        private void quiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment quitter le programme ?", // Message
                "Confirmation", // Titre de la boîte de dialogue
                MessageBoxButtons.OKCancel, // Boutons : OK (Quitter) et Annuler
                MessageBoxIcon.Question // Icône de question
            );

            // Vérifier la réponse de l'utilisateur
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }

    // Classe pour effet de survol sur le menu (doit être dans rfPatient, sans private)
    class CustomMenuColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(200, 220, 255); } // bleu plus foncé au survol
        }
        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(100, 160, 220); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(200, 220, 255); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(200, 220, 255); }
        }
    }
}
