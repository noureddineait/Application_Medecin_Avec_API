using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application_pour_medecin.Models
{
    public class PatientR
    {
        public int PatientId { get; set; }

        public Diagnostic Diagnostic { get; set; }

        
        public string Nom { get; set; }

        public string Prenom { get; set; }
        
        public string Date { get; set; }
        public string Ville { get; set; }
        public string Genre { get; set; }

        public bool IsValid()
        {
            return (!string.IsNullOrEmpty(this.Nom) &&
                !string.IsNullOrEmpty(this.Prenom) &&
                !string.IsNullOrEmpty(this.Date) &&
                !string.IsNullOrEmpty(this.Ville) &&
                !string.IsNullOrEmpty(this.Genre)
                );
        }
    }
}
