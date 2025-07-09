namespace priseRendezVous
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLogin = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.picPwd = new System.Windows.Forms.PictureBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.chkShowPwd = new System.Windows.Forms.CheckBox();
            this.labelErreur = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPwd)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.White;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Location = new System.Drawing.Point(60, 40);
            this.panelLogin.Size = new System.Drawing.Size(350, 400);
            this.panelLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelLogin.Controls.Add(this.picIcon);
            this.panelLogin.Controls.Add(this.picUser);
            this.panelLogin.Controls.Add(this.txtUser);
            this.panelLogin.Controls.Add(this.picPwd);
            this.panelLogin.Controls.Add(this.txtPwd);
            this.panelLogin.Controls.Add(this.chkShowPwd);
            this.panelLogin.Controls.Add(this.labelErreur);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.btnClose);
            // 
            // picIcon
            // 
            // this.picIcon.Image = global::priseRendezVous.Properties.Resources.cadenas; // Ajoute cadenas.png dans Resources
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.Size = new System.Drawing.Size(64, 64);
            this.picIcon.Location = new System.Drawing.Point(143, 20);
            // 
            // picUser
            // 
            // this.picUser.Image = global::priseRendezVous.Properties.Resources.user; // Ajoute user.png dans Resources
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.Size = new System.Drawing.Size(24, 24);
            this.picUser.Location = new System.Drawing.Point(30, 100);
            // 
            // txtUser
            // 
            // this.txtUser.PlaceholderText = "Nom d'utilisateur"; // PlaceholderText non supporté en .NET Framework
            this.txtUser.Location = new System.Drawing.Point(60, 100);
            this.txtUser.Width = 220;
            // 
            // picPwd
            // 
            // this.picPwd.Image = global::priseRendezVous.Properties.Resources.lock_icon; // Ajoute lock_icon.png dans Resources
            this.picPwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPwd.Size = new System.Drawing.Size(24, 24);
            this.picPwd.Location = new System.Drawing.Point(30, 150);
            // 
            // txtPwd
            // 
            // this.txtPwd.PlaceholderText = "Mot de passe"; // PlaceholderText non supporté en .NET Framework
            this.txtPwd.Location = new System.Drawing.Point(60, 150);
            this.txtPwd.Width = 220;
            this.txtPwd.PasswordChar = '*';
            // 
            // chkShowPwd
            // 
            this.chkShowPwd.Text = "Afficher le mot de passe";
            this.chkShowPwd.Location = new System.Drawing.Point(60, 180);
            this.chkShowPwd.CheckedChanged += new System.EventHandler(this.chkShowPwd_CheckedChanged);
            // 
            // labelErreur
            // 
            this.labelErreur.Text = "";
            this.labelErreur.ForeColor = System.Drawing.Color.Red;
            this.labelErreur.Location = new System.Drawing.Point(60, 210);
            this.labelErreur.Size = new System.Drawing.Size(220, 20);
            this.labelErreur.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Text = "Se connecter";
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(60, 250);
            this.btnLogin.Size = new System.Drawing.Size(100, 35);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Text = "Fermer";
            this.btnClose.Location = new System.Drawing.Point(180, 250);
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(470, 480);
            this.Controls.Add(this.panelLogin);
            this.Name = "Form1";
            this.Text = "Authentification";
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPwd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.PictureBox picPwd;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.CheckBox chkShowPwd;
        private System.Windows.Forms.Label labelErreur;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnClose;
    }
}

