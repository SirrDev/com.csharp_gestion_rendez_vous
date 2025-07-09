using APIRvMedical.DTO;
using Newtonsoft.Json;
using priseRendezVous.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace priseRendezVous.View
{
    public partial class frmRendezVous : Form
    {
        private readonly HttpClient _httpClient;
        private readonly string apiBaseUrl;
        private readonly string apiUrl;
        private List<RendezVous> rendezVousList = new List<RendezVous>(); // Pour la recherche


        public frmRendezVous()
        {
            InitializeComponent();
            apiBaseUrl = ConfigurationManager.AppSettings["BaseApiUrl"];
            apiUrl = $"{apiBaseUrl}/rendezVous";

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Load += frmRendezVous_Load;

            // Modernisation DataGridView
            dgRendezVous.EnableHeadersVisualStyles = false;
            dgRendezVous.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.SteelBlue;
            dgRendezVous.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgRendezVous.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            dgRendezVous.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgRendezVous.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgRendezVous.ReadOnly = true;
            dgRendezVous.SelectionChanged += dgRendezVous_SelectionChanged;

            // Modernisation boutons
            btnAjouter.BackColor = System.Drawing.Color.SeaGreen;
            btnAjouter.ForeColor = System.Drawing.Color.White;
            bntModifier.BackColor = System.Drawing.Color.DodgerBlue;
            bntModifier.ForeColor = System.Drawing.Color.White;
            btnSupprimer.BackColor = System.Drawing.Color.IndianRed;
            btnSupprimer.ForeColor = System.Drawing.Color.White;
            btnChoisir.BackColor = System.Drawing.Color.Gray;
            btnChoisir.ForeColor = System.Drawing.Color.White;

            // Désactiver les boutons au départ
            bntModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnChoisir.Enabled = false;
        }

        private async void frmRendezVous_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadPatientsAsync();
                await LoadMedecinsAsync();
                await LoadSoinsAsync();
                await LoadRendezVousAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement : " + ex);
            }
        }

        private async Task LoadPatientsAsync()
        {
            var response = await _httpClient.GetAsync($"{apiBaseUrl}/patients");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var patients = JsonConvert.DeserializeObject<List<Patient>>(json);
            cbPatient.DataSource = patients;
            cbPatient.DisplayMember = "NomPrenom";
            cbPatient.ValueMember = "idU";
        }

        private async Task LoadMedecinsAsync()
        {
            var response = await _httpClient.GetAsync($"{apiBaseUrl}/medecins");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var medecins = JsonConvert.DeserializeObject<List<Medecin>>(json);
            cbMedecin.DataSource = medecins;
            cbMedecin.DisplayMember = "NomPrenom";
            cbMedecin.ValueMember = "idU";
        }

        private async Task LoadSoinsAsync()
        {
            var response = await _httpClient.GetAsync($"{apiBaseUrl}/soins");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var soins = JsonConvert.DeserializeObject<List<Soin>>(json);
            cbSoin.DataSource = soins;
            cbSoin.DisplayMember = "Libelle";
            cbSoin.ValueMember = "IdSoin";
        }

        private async Task LoadRendezVousAsync()
        {
            var response = await _httpClient.GetAsync($"{apiUrl}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            rendezVousList = JsonConvert.DeserializeObject<List<RendezVous>>(json);

            // S'assurer que la liste des patients est bien chargée
            var patients = cbPatient.DataSource as List<Patient>;
            if (patients == null || patients.Count == 0)
            {
                await LoadPatientsAsync();
                patients = cbPatient.DataSource as List<Patient> ?? new List<Patient>();
            }
            var medecins = cbMedecin.DataSource as List<Medecin> ?? new List<Medecin>();
            var soins = cbSoin.DataSource as List<Soin> ?? new List<Soin>();

            var data = rendezVousList.Select(r => new
            {
                IdRv = r.IdRv,
                Date = r.DateRv.ToString("dd/MM/yyyy HH:mm"),
                Statut = string.IsNullOrWhiteSpace(r.Statut) ? "Non renseigné" : r.Statut,
                Patient = (r.IdPatient != null) ? patients.FirstOrDefault(p => p.idU == r.IdPatient)?.NomPrenom ?? "" : "",
                Medecin = (r.IdMedecin != null) ? medecins.FirstOrDefault(m => m.idU == r.IdMedecin)?.NomPrenom ?? "" : "",
                Soin = (r.IdSoin != null) ? soins.FirstOrDefault(s => s.IdSoin == r.IdSoin)?.libelle ?? "" : ""
            }).ToList();

            dgRendezVous.DataSource = data;
            PersonnaliserColonnes();
            // Agrandir le DataGridView
            dgRendezVous.Width = 600;
            dgRendezVous.Height = 350;
        }

        private async void btnAjouter_Click(object sender, EventArgs e)
        {
            var rv = GetRendezVousFromForm();
            if (rv == null) return;

            var json = JsonConvert.SerializeObject(rv);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{apiUrl}", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Rendez-vous ajouté !");
                await LoadRendezVousAsync();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout : " + response.ReasonPhrase);
            }
        }

        private async void bntModifier_Click(object sender, EventArgs e)
        {
            if (dgRendezVous.CurrentRow != null){

                var selected = (RendezVous)dgRendezVous.CurrentRow.DataBoundItem;

                var rv = GetRendezVousFromForm();
                if (rv == null) return;

                rv.IdRv = selected.IdRv;

                var json = JsonConvert.SerializeObject(rv);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{apiUrl}/{rv.IdRv}", content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Rendez-vous modifié !");
                    await LoadRendezVousAsync();
                }
                else
                {
                    MessageBox.Show("Erreur de modification : " + response.ReasonPhrase);
                }
            }
        }

        //private void btnChoisir_Click(object sender, EventArgs e)
        //{
        //    if (dgRendezVous.CurrentRow?.DataBoundItem is not RendezVousDTO selected) return;

        //    dtpDateRv.Value = selected.DateRv;
        //    txtStatut.Text = selected.Statut;
        //    cbPatient.SelectedValue = selected.IdPatient;
        //    cbMedecin.SelectedValue = selected.IdMedecin;
        //    cbSoin.SelectedValue = selected.IdSoin;
        //}

        private void btnChoisir_Click(object sender, EventArgs e)
        {
            if (dgRendezVous.CurrentRow != null)
            {
                int idRv = (int)dgRendezVous.CurrentRow.Cells["IdRv"].Value;
                var selected = rendezVousList.FirstOrDefault(r => r.IdRv == idRv);
                if (selected != null)
                {
                    dtpDateRv.Value = selected.DateRv;
                    txtStatut.Text = selected.Statut;
                    cbPatient.SelectedValue = selected.IdPatient;
                    cbMedecin.SelectedValue = selected.IdMedecin;
                    cbSoin.SelectedValue = selected.IdSoin;
                }
            }
        }

        private RendezVous GetRendezVousFromForm()
        {
            if (cbPatient.SelectedValue == null || cbMedecin.SelectedValue == null || cbSoin.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un patient, un médecin et un soin.");
                return null;
            }

            return new RendezVous
            {
                DateRv = dtpDateRv.Value,
                Statut = txtStatut.Text.Trim(),
                IdPatient = (int)cbPatient.SelectedValue,
                IdMedecin = (int)cbMedecin.SelectedValue,
                IdSoin = (int)cbSoin.SelectedValue
            };
        }

        private void dgRendezVous_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgRendezVous.CurrentRow != null;
            bntModifier.Enabled = hasSelection;
            btnSupprimer.Enabled = hasSelection;
            btnChoisir.Enabled = hasSelection;
        }

        private void txtRecherche_GotFocus(object sender, EventArgs e)
        {
            if (txtRecherche.Text == txtRecherche.Tag.ToString())
            {
                txtRecherche.Text = "";
                txtRecherche.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtRecherche_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecherche.Text))
            {
                txtRecherche.Text = txtRecherche.Tag.ToString();
                txtRecherche.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtStatut_GotFocus(object sender, EventArgs e)
        {
            if (txtStatut.Text == txtStatut.Tag.ToString())
            {
                txtStatut.Text = "";
                txtStatut.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtStatut_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStatut.Text))
            {
                txtStatut.Text = txtStatut.Tag.ToString();
                txtStatut.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            if (txtRecherche.Text == txtRecherche.Tag.ToString()) return;
            string filtre = txtRecherche.Text.ToLower();
            var rdvFiltres = rendezVousList.Where(r => r.Statut.ToLower().Contains(filtre) || r.DateRv.ToString().ToLower().Contains(filtre)).ToList();
            dgRendezVous.DataSource = rdvFiltres;
        }

        private void PersonnaliserColonnes()
        {
            if (dgRendezVous.Columns.Contains("IdRv"))
                dgRendezVous.Columns["IdRv"].Visible = false;
            if (dgRendezVous.Columns.Contains("Date"))
                dgRendezVous.Columns["Date"].HeaderText = "Date";
            if (dgRendezVous.Columns.Contains("Statut"))
                dgRendezVous.Columns["Statut"].HeaderText = "Statut";
            if (dgRendezVous.Columns.Contains("Patient"))
                dgRendezVous.Columns["Patient"].HeaderText = "Patient";
            if (dgRendezVous.Columns.Contains("Medecin"))
                dgRendezVous.Columns["Medecin"].HeaderText = "Médecin";
            if (dgRendezVous.Columns.Contains("Soin"))
                dgRendezVous.Columns["Soin"].HeaderText = "Soin";

            dgRendezVous.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgRendezVous.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgRendezVous.AutoResizeColumns();
        }
    }
}
