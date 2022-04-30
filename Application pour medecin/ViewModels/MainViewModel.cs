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
    internal class MainViewModel : INotifyPropertyChanged
    {

        public string Password { private get; set; }
        public string PasswordRegister { private get; set; }
        public string PasswordConfirm { private get; set; }


        private Window _window; 
        public Models.Medecin Medecin { get; set; }
        public Models.Login Login { get; set; }
        public Models.Register Register { get; set; }
        
        private ObservableCollection<string> _villes;

        public ObservableCollection<string> Villes
        {
            get { return _villes; }
        }

        private bool _radio1IsCheck;
        public bool Radio1IsCheck
        {
            get { return this._radio1IsCheck; }
            set
            {
                this._radio1IsCheck = value;
                this.OnPropertyChanged("Radio1IsCheck");
                this.OnPropertyChanged("TextValue");
            }
        }

        private bool _radio2IsCheck;
        public bool Radio2IsCheck
        {
            get { return this._radio2IsCheck; }
            set
            {
                this._radio2IsCheck = value;
                this.OnPropertyChanged("Radio1IsCheck");
                this.OnPropertyChanged("TextValue");
            }
        }
        public string TextValue
        {
            get
            {
                string selected;
                if (!this._radio1IsCheck && !this._radio2IsCheck)
                {
                    selected = null;
                }
                else if (this._radio2IsCheck){
                    selected = "Femme";
                }
                else
                {
                    selected = "Homme";
                }
                return selected;
            }
        }
        private Models.Medecin _selectDoctor;
        public Models.Medecin SelectedDoctor
        {
            get
            {
                return _selectDoctor;
            }
            set
            {
                if (_selectDoctor != value)
                {
                    _selectDoctor = value;

                }
            }
        }
        public ICommand AddDoctorCommand { get; private set; }
        public ICommand ConnexionCommand { get; private set; }
        //public ICommand MyCommand { get; private set; }

        public ICommand QuitterCommand { get; private set; }
        public ICommand OpenCreation { get; private set; }

        
        public MainViewModel(Window window)
        {
            _window = window;
            Medecin = new Models.Medecin();
            Login = new Models.Login();
            Register = new Models.Register();
            _selectDoctor = new Models.Medecin();
            _villes = new ObservableCollection<string>()
            {
                "Casablanca",
                "Marrakech",
                "Tanger",
                "Rabat",
                "Fez",
                "Rimouski"
            };

            ConnexionCommand = new RelayCommand(
                o => true,
                o =>SeConnecter()
                );
            AddDoctorCommand = new RelayCommand(
                o => true,
                o => AddDoctor()
            );

            QuitterCommand = new RelayCommand (
                o=>true,
                o => quitCreation()
            );

            OpenCreation = new RelayCommand(
                o => true,
                o => openCreation()
                );
            
        }
        private void SeConnecter()
        {
            Login.Password = Password;
            RestApiQueries restApiQueries = new RestApiQueries();
            Models.LoginResponse loginResponse = restApiQueries.Login(Login, "Home/Login");
            if (loginResponse!=null)
            {
                //MessageBox.Show(loginResponse.Token.ToString());
                Bienvenue_Dr bienvenue_Dr = new Bienvenue_Dr(loginResponse);
                bienvenue_Dr.Show();
                _window.Close();
            }
            else
            {
                MessageBox.Show("Veuillez choisir votre Nom !","Erreur",MessageBoxButton.OK,MessageBoxImage.Error);
            }
                      
        }
        private void openCreation()
        {
            Medecin.Nom = "";
            Medecin.Prenom = "";
            Medecin.Ville = "";
            Medecin.Date = "";
            Medecin.Date_Entree = "";
            Medecin.Mail = "";
            Creation creation = new Creation();
            creation.DataContext = this;
            creation.ShowDialog();
            //_window.Close();
            
        }
        
        private void quitCreation()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != _window)
                {
                    window.Close();
                }
            }

        }
        private void AddDoctor()
        {
            
            Register.Password = PasswordRegister;
            Register.ConfirmPassowrd = PasswordConfirm;
            Register.Genre = TextValue;
            RestApiQueries restApiQueries = new RestApiQueries();
            Models.StatusCode out_register = restApiQueries.Register(Register, "Home/Register");
            if (out_register.Status != "Error")
            {
                MessageBox.Show(out_register.Status);
                /*Bienvenue_Dr bienvenue_Dr = new Bienvenue_Dr(SelectedDoctor);
                bienvenue_Dr.Show();
                _window.Close();*/
                foreach (Window window in Application.Current.Windows)
                {
                    if (window != _window)
                    {
                        window.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Une erreur est survenue lors de la création", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
