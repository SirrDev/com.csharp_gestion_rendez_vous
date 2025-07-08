﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MetierRvMedical.model;

namespace MetierRvMedical
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        bdRvMedicalContext db = new bdRvMedicalContext();

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public List<Agenda> GetListeAgenda()
        {
            return db.agendas.ToList();
        }
        public bool AddAgenda(Agenda agenda)
        {
            try
            {
                db.agendas.Add(agenda);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public bool UpdateAgenda(Agenda agenda)
        {
            try
            {
                db.Entry(agenda).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        public Medecin GetMedecinbyId(int id)
        {
            return db.medecins.Find(id);
        }
        public List<patient> GetPatients()
        {
            return db.patients.ToList();
        }

        public bool AddPatient(patient p)
        {
            try
            {
                db.patients.Add(p);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdatePatient(patient p)
        {
            try
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePatient(int id)
        {
            try
            {
                var p = db.patients.Find(id);
                if (p != null)
                {
                    db.patients.Remove(p);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public patient GetPatientById(int id)
        {
            return db.patients.Find(id);
        }
        public Utilisateur Connexion(string identifiant, string motDePasseHash)
        {
            using (var db = new bdRvMedicalContext())
            {
                var user = db.utilisateurs
                             .Include("Role")
                             .FirstOrDefault(u => u.Identifiant.ToLower() == identifiant.ToLower());

                if (user != null && user.Motdepasse == motDePasseHash)
                {
                    return new Utilisateur
                    {
                        IdU = user.IdU,
                        Identifiant = user.Identifiant,
                        Motdepasse = user.Motdepasse,
                        Role = new Role
                        {
                            code = user.Role.code,
                            libelle = user.Role.libelle
                        }
                    };
                }
                return null;
            }
        }
    }
}

