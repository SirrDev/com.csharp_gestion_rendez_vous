//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIRvMedical.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class spt_fallback_db
    {
        public string xserver_name { get; set; }
        public System.DateTime xdttm_ins { get; set; }
        public System.DateTime xdttm_last_ins_upd { get; set; }
        public Nullable<short> xfallback_dbid { get; set; }
        public string name { get; set; }
        public short dbid { get; set; }
        public short status { get; set; }
        public short version { get; set; }
    }
}
