using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application_pour_medecin.Models
{
    public class Register
    {
        
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassowrd { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Date { get; set; }
        public string Genre { get; set; }

        public string Date_Entree { get; set; }

        public string Ville { get; set; }

    }
}
