using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Application_pour_medecin.ViewModels
{
    internal class InformationViewModel : INotifyPropertyChanged
    {
        private Window _window;
        public Models.Patient Patient { get; set; }
        private ObservableCollection<string> _villesPatient;

        public ObservableCollection<string> VillesPatient
        {
            get { return _villesPatient; }
        }

        private bool _radio3IsCheck;
        public bool Radio3IsCheck
        {
            get { return this._radio3IsCheck; }
            set
            {
                this._radio3IsCheck = value;
                this.OnPropertyChanged("Radio3IsCheck");
                this.OnPropertyChanged("TextValue2");
            }
        }

        private bool _radio4IsCheck;
        public bool Radio4IsCheck
        {
            get { return this._radio4IsCheck; }
            set
            {
                this._radio4IsCheck = value;
                this.OnPropertyChanged("Radio4IsCheck");
                this.OnPropertyChanged("TextValue2");
            }
        }
        public string TextValue2
        {
            get
            {
                string selected;
                if (!this._radio3IsCheck && !this._radio4IsCheck)
                {
                    selected = null;
                }
                else if (this._radio4IsCheck)
                {
                    selected = "Femme";
                }
                else
                {
                    selected = "Homme";
                }
                return selected;
            }
        }
        private string _predictString = $"Résultat : Présence / Absence de maladie";
        public string PredictString
        {
            get { return _predictString; }
            set
            {
                _predictString = value;
                OnPropertyChanged();

            }
        }
        public ICommand QuitterCommand { get; private set; }
        public InformationViewModel(Window window , Models.Patient patient)
        {
            _window = window;
            Patient = patient;
            _villesPatient = new ObservableCollection<string>()
            {
                "Casablanca",
                "Marrakech",
                "Tanger",
                "Rabat",
                "Fez",
                "Rimouski"
            };

            if (Patient.Genre == "Homme")
            {
                Radio3IsCheck = true;
            }
            else Radio4IsCheck = true;

            if (Patient.Diagnostic != null && Patient.Diagnostic.target != null)
            {
                if (Patient.Diagnostic.target == 1)
                {
                    _predictString = "Résultat : Présence ";
                    PredictString = _predictString;
                }
                else
                {
                    _predictString = "Résultat : Absence de maladie ";
                    PredictString = _predictString;
                }
            }
            
            QuitterCommand = new RelayCommand(
                o => true,
                o => Quitter()
                );
        }
        private void Quitter()
        {
            _window.Close();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
