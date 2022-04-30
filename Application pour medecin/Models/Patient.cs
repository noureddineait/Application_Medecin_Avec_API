using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Application_pour_medecin.Models
{
    public class Patient : INotifyPropertyChanged
    {
        //DIAGNOSTIQUE MISSING !!!!!!

        public event PropertyChangedEventHandler PropertyChanged;
        public int PatientId { get; set; }

        private string _nom="";

        private string _prenom = "";
        private string _date;
        private string _ville = "";
        private string _genre = "";
        private Diagnostic _diagnostic;

        public Diagnostic Diagnostic
        {
            get { return this._diagnostic; }
            set
            {
                if(this._diagnostic != value)
                {
                    this._diagnostic = value;
                }
            }
        }
        public string Nom
        {
            get { return this._nom; }

            set
            {
                if (this._nom != value)
                {
                    this._nom = value;
                    
                }
            }
        }
        

        public string Prenom
        {
            get { return this._prenom; }

            set
            {
                if (this._prenom != value)
                {
                    this._prenom = value;
                }
            }
        }
        public string Date
        {
            get { return this._date; }

            set
            {
                if (this._date != value)
                {
                    this._date = value;
                }
            }
        }
        public string Ville
        {
            get { return this._ville; }

            set
            {
                if (this._ville != value)
                {
                    this._ville = value;
                }
            }
        }
        public string Genre
        {
            get { return this._genre; }

            set
            {
                if (this._genre != value)
                {
                    this._genre = value;
                }
            }
        }
        public bool IsValid()
        {
            return (!string.IsNullOrEmpty(this._nom) && 
                !string.IsNullOrEmpty(this._prenom)&&
                !string.IsNullOrEmpty(this._date)&&
                !string.IsNullOrEmpty(this._ville)&&
                !string.IsNullOrEmpty(this._genre)
                );
        }
        public int? MID { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Patient() { }
        public Patient(string nom,string prenom)
        {
            this._nom = nom;
            this._prenom = prenom;
        }
        public Patient(string nom, string prenom,string date,string ville,string genre)
        {
            this._nom = nom;
            this._prenom = prenom;
            this._date = date;
            this._genre = genre;
            this._ville = ville;
        }

    }
}
