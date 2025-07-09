using Newtonsoft.Json;
using priseRendezVous.helper;
using priseRendezVous.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace priseRendezVous
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPwd.PasswordChar = '*';
            chkShowPwd.CheckedChanged += chkShowPwd_CheckedChanged;
            this.Load += Form1_Load;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chkShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            txtPwd.PasswordChar = chkShowPwd.Checked ? '\0' : '*';
        }

        /// <summary>
        /// Bouton pour se connecter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string identifiant = txtUser.Text.Trim();
            string motDePasse = txtPwd.Text;
            labelErreur.Visible = false;
            if (string.IsNullOrEmpty(identifiant) || string.IsNullOrEmpty(motDePasse))
            {
                labelErreur.Text = "Veuillez saisir l'identifiant et le mot de passe";
                labelErreur.Visible = true;
                return;
            }
            try
            {
                var utilisateur = await AuthentifierUtilisateurAsync(identifiant, motDePasse);
                if (utilisateur != null)
                {
                    OuvrirInterfaceSelonRole(utilisateur);
                    this.Hide();
                }
                else
                {
                    labelErreur.Text = "Identifiant ou mot de passe incorrect";
                    labelErreur.Visible = true;
                }
            }
            catch (Exception ex)
            {
                labelErreur.Text = $"Erreur lors de la connexion : {ex.Message}";
                labelErreur.Visible = true;
            }
        }

        private async Task<Utilisateur> AuthentifierUtilisateurAsync(string identifiant, string motDePasse)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44348/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var loginInfo = new
                {
                    Identifiant = identifiant,
                    MotDePasse = motDePasse // Non hashé ici, c’est l’API qui hash
                };

                string jsonData = JsonConvert.SerializeObject(loginInfo);
                HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("api/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var utilisateur = JsonConvert.DeserializeObject<Utilisateur>(json);
                    return utilisateur;
                }

                return null;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Liens PNG libres de droits (Icons8)
            string urlUserPng = "https://img.icons8.com/ios-filled/50/000000/user.png";
            string urlLockPng = "https://img.icons8.com/ios-filled/50/000000/lock-2.png";

            var imgUser = LoadImageFromUrl(urlUserPng);
            if (imgUser != null) picUser.Image = imgUser;
            var imgPwd = LoadImageFromUrl(urlLockPng);
            if (imgPwd != null) picPwd.Image = imgPwd;
            var imgIcon = LoadImageFromUrl(urlLockPng);
            if (imgIcon != null) picIcon.Image = imgIcon;
        }

        private Image LoadImageFromUrl(string url)
        {
            using (WebClient wc = new WebClient())
            {
                using (var stream = new System.IO.MemoryStream(wc.DownloadData(url)))
                {
                    return Image.FromStream(stream);
                }
            }
        }


        private void OuvrirInterfaceSelonRole(Utilisateur utilisateur)
        {
           

            if (utilisateur is Admin)
            {
                rfPatient frmPatient = new rfPatient();
                frmPatient.Show();
                //var formAdmin = new frmAdminInterface();
                //formAdmin.Show();
            }
            else if (utilisateur is Medecin)
            {
                //var formMedecin = new frmMedecinInterface();
                //formMedecin.Show();
            }
            else if (utilisateur is Secretaire)
            {
                //var formSecretaire = new frmSecretaireInterface();
                //formSecretaire.Show();
            }
            else
            {
                rfPatient frmPatient = new rfPatient();
                frmPatient.Show();
               // MessageBox.Show("Votre rôle ne vous permet pas d'accéder au système", "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // this.Show(); // Affiche à nouveau le formulaire de connexion
            }
        }



    }
}
