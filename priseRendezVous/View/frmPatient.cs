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

namespace priseRendezVous.View
{
    public partial class frmPatient : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string apiBaseUrl;
        private readonly string baseUrl;

        public frmPatient()
        {
            InitializeComponent();

            apiBaseUrl = ConfigurationManager.AppSettings["BaseApiUrl"];
            baseUrl = $"{apiBaseUrl}/patients";

            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.Load += new EventHandler(frmPatient_Load);
        }

        private void frmPatient_Load(object sender, EventArgs e)
        {
            // Icône patient en ligne (Icons8)
            string urlPatientPng = "https://img.icons8.com/ios-filled/100/000000/user.png";
            picPatient.Image = LoadImageFromUrl(urlPatientPng);
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

        private async System.Threading.Tasks.Task LoadPatients()
        {
            var response = await client.GetAsync(baseUrl);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var patients = JsonConvert.DeserializeObject<List<Patient>>(jsonData);
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
    }
}
