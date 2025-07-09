using Newtonsoft.Json;
using priseRendezVous.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Drawing;
using System.Linq; // Added for .Where() and .ToList()

namespace priseRendezVous.View
{
    public partial class frmPatient : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string apiBaseUrl;
        private readonly string baseUrl;
        private List<Patient> patients = new List<Patient>(); // Pour la recherche

        public frmPatient()
        {
            InitializeComponent();

            apiBaseUrl = ConfigurationManager.AppSettings["BaseApiUrl"];
            baseUrl = $"{apiBaseUrl}/patients";

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.Load += new EventHandler(frmPatient_Load);
            // Démarrer le timer pour l'actualisation automatique
            this.Load += (s, e) => { refreshTimer.Start(); };

            // Modernisation DataGridView
            dgPatient.EnableHeadersVisualStyles = false;
            dgPatient.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgPatient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgPatient.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgPatient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgPatient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPatient.ReadOnly = true;
            dgPatient.SelectionChanged += dgPatient_SelectionChanged;

            // Modernisation boutons
            btnAjouter.BackColor = Color.SeaGreen;
            btnAjouter.ForeColor = Color.White;
            bntModifier.BackColor = Color.DodgerBlue;
            bntModifier.ForeColor = Color.White;
            btnSupprimer.BackColor = Color.IndianRed;
            btnSupprimer.ForeColor = Color.White;
            btnChoisir.BackColor = Color.Gray;
            btnChoisir.ForeColor = Color.White;

            // Désactiver les boutons au départ
            bntModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnChoisir.Enabled = false;

            // Préparer la barre de recherche (champ à ajouter dans le Designer)
            // txtRecherche.TextChanged += txtRecherche_TextChanged;
        }

        private async void refreshTimer_Tick(object sender, EventArgs e)
        {
            await LoadPatients();
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            // Icône patient en ligne (Icons8)
            string urlPatientPng = "https://img.icons8.com/ios-filled/100/000000/user.png";
            picPatient.Image = LoadImageFromUrl(urlPatientPng);
            // Appeler LoadPatients lors du chargement initial
            LoadPatients();
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

        // Charger la liste complète pour la recherche
        private async System.Threading.Tasks.Task LoadPatients()
        {
            var response = await client.GetAsync(baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                patients = JsonConvert.DeserializeObject<List<Patient>>(jsonData);
                dgPatient.DataSource = patients;
            }
            else
            {
                labelErreur.Text = "Erreur lors du chargement des patients";
                labelErreur.Visible = true;
            }
        }

        private void ResetForm()
        {
            txtNomPrenom.Text = "";
            txtEmail.Text = "";
            txtAdresse.Text = "";
            txtTel.Text = "";
            txtGroupSanguin.Text = "";
            txtPoids.Text = "";
            labelErreur.Visible = false;
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            labelErreur.Visible = false;
            try {
                if (!float.TryParse(txtPoids.Text, out float poids))
                {
                    labelErreur.Text = "Le poids doit être un nombre valide.";
                    labelErreur.ForeColor = System.Drawing.Color.Red;
                    labelErreur.Visible = true;
                    return;
                }
                var patient = new Patient
                {
                    NomPrenom = txtNomPrenom.Text,
                    Adresse = txtAdresse.Text,
                    Tel = txtTel.Text,
                    Email = txtEmail.Text,
                    GroupeSanguin = txtGroupSanguin.Text,
                    Poids = poids
                };
                var json = JsonConvert.SerializeObject(patient);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(baseUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    await LoadPatients();
                    ResetForm();
                    labelErreur.Text = "Patient ajouté !";
                    labelErreur.ForeColor = System.Drawing.Color.Green;
                    labelErreur.Visible = true;
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    labelErreur.Text = "Erreur HTTP: " + response.StatusCode + "\n" + errorContent;
                    labelErreur.ForeColor = System.Drawing.Color.Red;
                    labelErreur.Visible = true;
                }
            }
            catch (Exception ex)
            {
                labelErreur.Text = "Erreur de l'ajout : " + ex.Message;
                labelErreur.ForeColor = System.Drawing.Color.Red;
                labelErreur.Visible = true;
            }
        }

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            if (dgPatient.CurrentRow != null)
            {
                txtNomPrenom.Text = dgPatient.CurrentRow.Cells["NomPrenom"].Value.ToString();
                txtAdresse.Text = dgPatient.CurrentRow.Cells["Adresse"].Value.ToString();
                txtEmail.Text = dgPatient.CurrentRow.Cells["Email"].Value.ToString();
                txtTel.Text = dgPatient.CurrentRow.Cells["Tel"].Value.ToString();
                txtGroupSanguin.Text = dgPatient.CurrentRow.Cells["GroupeSanguin"].Value.ToString();
                txtPoids.Text = dgPatient.CurrentRow.Cells["Poids"].Value.ToString();
            }
        }

        private async void bntModifier_Click(object sender, EventArgs e)
        {
            if (dgPatient.CurrentRow == null) return;
            if (!float.TryParse(txtPoids.Text, out float poids))
            {
                labelErreur.Text = "Le poids doit être un nombre valide.";
                labelErreur.ForeColor = System.Drawing.Color.Red;
                labelErreur.Visible = true;
                return;
            }
            int id = (int)dgPatient.CurrentRow.Cells["idU"].Value;
            var patient = new Patient
            {
                NomPrenom = txtNomPrenom.Text,
                Adresse = txtAdresse.Text,
                Tel = txtTel.Text,
                Email = txtEmail.Text,
                GroupeSanguin = txtGroupSanguin.Text,
                Poids = poids
            };

            var json = JsonConvert.SerializeObject(patient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{baseUrl}/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Patient modifié !");
                await LoadPatients();
                ResetForm();
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Erreur lors de la modification : " + response.StatusCode + "\n" + errorContent);
            }

        }

        private async void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgPatient.CurrentRow == null) return;

            int id = (int)dgPatient.CurrentRow.Cells["idU"].Value;
            var response = await client.DeleteAsync($"{baseUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Patient supprimé !");
                await LoadPatients();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Erreur lors de la suppression");
            }
        }

        private void frmPatient_Load_1(object sender, EventArgs e)
        {

        }

        // Exemple d'affichage d'une erreur moderne
        private void ShowError(string message)
        {
            labelErreur.Text = message;
            labelErreur.ForeColor = System.Drawing.Color.Red;
            labelErreur.Visible = true;
        }
        private void ShowSuccess(string message)
        {
            labelErreur.Text = message;
            labelErreur.ForeColor = System.Drawing.Color.Green;
            labelErreur.Visible = true;
        }

        // Désactiver/activer les boutons selon la sélection
        private void dgPatient_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgPatient.CurrentRow != null;
            bntModifier.Enabled = hasSelection;
            btnSupprimer.Enabled = hasSelection;
            btnChoisir.Enabled = hasSelection;
        }

        // Barre de recherche (à activer si champ ajouté dans le Designer)
        private void txtRecherche_GotFocus(object sender, EventArgs e)
        {
            if (txtRecherche.Text == txtRecherche.Tag.ToString())
            {
                txtRecherche.Text = "";
                txtRecherche.ForeColor = Color.Black;
            }
        }

        private void txtRecherche_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecherche.Text))
            {
                txtRecherche.Text = txtRecherche.Tag.ToString();
                txtRecherche.ForeColor = Color.Gray;
            }
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            if (txtRecherche.Text == txtRecherche.Tag.ToString()) return;
            string filtre = txtRecherche.Text.ToLower();
            var patientsFiltres = patients.Where(p => p.NomPrenom.ToLower().Contains(filtre) || p.Email.ToLower().Contains(filtre)).ToList();
            dgPatient.DataSource = patientsFiltres;
        }
    }
}
