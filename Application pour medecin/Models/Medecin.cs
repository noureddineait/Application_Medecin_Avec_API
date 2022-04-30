using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application_pour_medecin.Models
{
    public class Medecin : INotifyPropertyChanged
    {
        public int MedecinId { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string _nom = "";
        private string _prenom = "";
        private string _date;
        private string _genre = "";
        private string _date_Entree;
        private string _mail = "";
        private string _ville = "";
        public string Nom
        {
            get { return this._nom; }

            set
            {
                if (this._nom != value)
                {
                    this._nom = value;
                    OnPropertyChanged();
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
                    OnPropertyChanged();

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
                    OnPropertyChanged();

                }
            }
        }

        public string Date_Entree
        {
            get { return this._date_Entree; }

            set
            {
                if (this._date_Entree != value)
                {
                    this._date_Entree = value;
                    OnPropertyChanged();

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
                    OnPropertyChanged();

                }
            }
        }
        public string Mail
        {
            get { return this._mail; }

            set
            {
                if (this._mail != value)
                {
                    this._mail = value;
                    OnPropertyChanged();

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
                    OnPropertyChanged();

                }
            }
        }
        public Medecin(string nom, string prenom)
        {
            this._nom = nom;
            this._prenom = prenom;
        }
        public Medecin(string nom, string prenom,string date,string dateEntrée,string ville,string mail,string genre)
        {
            this._nom = nom;
            this._prenom = prenom;
            this._date=date;
            this._date_Entree = dateEntrée;
            this._ville=ville;
            this._mail = mail;
            this._genre=genre;

        }
        public bool IsValid()
        {
            return (
                !string.IsNullOrEmpty(this.Nom) &&
                !string.IsNullOrEmpty(this.Prenom) &&
                !string.IsNullOrEmpty(this.Mail)&&
                !string.IsNullOrEmpty(this.Ville) &&    
                !string.IsNullOrEmpty(this.Date) &&
                !string.IsNullOrEmpty(this.Date_Entree) &&
                !string.IsNullOrEmpty(this.Genre)
            );
        }
        public Medecin(string nom)
        {
            this._nom = nom;
        }
        public Medecin()
        {
            
        }
    }
}
