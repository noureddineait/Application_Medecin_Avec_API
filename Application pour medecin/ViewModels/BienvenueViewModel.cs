using Application_pour_medecin.Models;
using Application_pour_medecin.Views;
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
    internal class BienvenueViewModel : INotifyPropertyChanged
    {
        private Window _window;
        public Models.Medecin Medecin { get; set; }

        
        // POUR INFORMATION
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
                else if (this._radio2IsCheck)
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
        
        public ICommand InfoModifier { get; private set; }

        
        //ATENTION !!!!!!!!!!!!!!!!!!!!!!!
        //POUR DIAGNOSTIQUE
        //ATENTION !!!!!!!!!!!!!!!!!!!!!!!


        public Models.Patient Patient { get; set; }

        private ObservableCollection<Models.Patient> _patients;
        public ObservableCollection<Models.Patient> PatientsView
        {
            get { return _patients; }
        }

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
        private Models.Patient _selectedPatient;
        public Models.Patient SelectedPatient
        {
            get
            {
                return _selectedPatient;
            }
            set
            {
                if (_selectedPatient != value)
                {
                    _selectedPatient = value;

                }
            }
        }
        private ObservableCollection<string> _douleursThalassemie;

        public ObservableCollection<string> DouleursThalassemie
        {
            get { return _douleursThalassemie; }
        }
        private ObservableCollection<string> _douleursThoracique;

        public ObservableCollection<string> DouleursThoracique
        {
            get { return _douleursThoracique; }
        }
        
        private string _selectedThalString;

        public string SelectedThalString
        {
            get { return _selectedThalString; }
            set { _selectedThalString = value; OnPropertyChanged();
            }
        }
        private string _selectedThorString;

        public string SelectedThorString
        {
            get { return _selectedThorString; }
            set { _selectedThorString = value;
                OnPropertyChanged();
            }
        }

        private string _selectedDepString;

        public string SelectedDepString
        {
            get { return _selectedDepString; }
            set { _selectedDepString = value; }
        }
        private string _selectedVaisString;

        public string SelectedVaisString
        {
            get { return _selectedVaisString; }
            set { _selectedVaisString = value; }
        }

        private int _selectedThal;

        
        private float _selectedThor;

        

        private float _selectedDep;

        
        private float _selectedVais;

        private string _predictString= $"Résultat : Présence / Absence de maladie";
        public string PredictString
        {
            get { return _predictString; }
            set
            {
                _predictString = value;
                OnPropertyChanged();

            }
        }


        /*Content="Résultat : Presence \ Absence de maladie"*/

        public ICommand AddDoctorCommand { get; private set; }
        public ICommand QuitterCommand { get; private set; }
        public ICommand OpenAjoutPatientCommand { get; private set; }
        public ICommand InformationPatientCommand { get; private set; }

        public ICommand DiagnostiquerCommand { get; private set; }
        //ATENTION !!!!!!!!!!!!!!!!!!!!!!!
        //POUR CONFIGURATION
        //ATENTION !!!!!!!!!!!!!!!!!!!!!!!

        private string _trainSet;
        private string _testSet;
        
        public ICommand OpenTrainCommand { get; private set; }
        public ICommand OpenTestCommand { get; private set; }
        Models.KNN KNN { get; set; }

        private ObservableCollection<string> _distances;

        public ObservableCollection<string> Distances
        {
            get { return _distances; }
        }

        private int _parametreK = 1;
        public int ParametreK
        {
            get { return _parametreK; }
            set { _parametreK = value; }
        }
        private string _selectedDistance;

        public string SelectedDistance
        {
            get { return _selectedDistance; }
            set { _selectedDistance = value; }
        }
        private int _distance;
        public int Distance
        {
            get { return _distance; }
            set
            {
                if (SelectedDistance == "Euclidienne")
                {
                    _distance = 0;
                }
                else if (SelectedDistance == "Manhattan")
                {
                    _distance = 1;
                }
            }
        }
        private float _accuracy;
        public float Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; 
            }
        }
        private string _accuracyString = "Taux de reconnaissance : ...%";
        public string AccuracyString
        {
            get { return _accuracyString; }
            set
            {
                _accuracyString = value;
                OnPropertyChanged();

            }
        }

        public ICommand EvaluerCommand { get; private set; }

        private readonly LoginResponse _login;

        public string Token { get; set; }
        public BienvenueViewModel(Window window,Models.LoginResponse login)
        {
            _login = login;
            Token = login.Token;
            _window = window;
            Medecin = Information();
            _villes = new ObservableCollection<string>()
            {
                "Berrechid",
                "Casablanca",
                "Marrakech",
                "Tanger",
                "Rabat",
                "Fez",
                "Rimouski"
            };
            _douleursThalassemie = new ObservableCollection<string>()
            {
                "Normale",
                "Défaut corrigé",
                "Défaut"
            };

            _douleursThoracique = new ObservableCollection<string>()
            {
                "Angine typique",
                "Angine atypique",
                "Douleur non angineuse",
                "Asymptomatique"
            };
            //ATENTION !!!!!!!!!!!!!!!!!!!!!!!
            //POUR INFORMATION
            //ATENTION !!!!!!!!!!!!!!!!!!!!!!!

            if (Medecin.Genre == "Homme")
            {
                Radio1IsCheck = true;
            }else Radio2IsCheck = true;
            
            InfoModifier = new RelayCommand(
                o => true,
                o => Modifier()
                );
            //ATENTION !!!!!!!!!!!!!!!!!!!!!!!
            //POUR DIAGNOSTIQUE
            //ATENTION !!!!!!!!!!!!!!!!!!!!!!!

            Patient = new Models.Patient();
            List<Models.Patient> patients = Patients();
            _patients = new ObservableCollection<Models.Patient>();
            Refresh();

            _selectedPatient = new Models.Patient();
            //_selectedDiagnostic = new Models.Diagnostic();

            _villesPatient = new ObservableCollection<string>()
            {
                "Berrechid",
                "Casablanca",
                "Marrakech",
                "Tanger",
                "Rabat",
                "Fez",
                "Rimouski"
            };

            
            AddDoctorCommand = new RelayCommand(
                o => true,
                o => AddPatient()
            );

            QuitterCommand = new RelayCommand(
                o => true,
                o => QuitAjoutPatient()
            );

            OpenAjoutPatientCommand = new RelayCommand(
                o => true,
                o => OpenAjoutPatient()
                );
            InformationPatientCommand = new RelayCommand(
                o => true,
                o => InfoPatient()
                );
            DiagnostiquerCommand = new RelayCommand(
                o => true,
                o => Diagnostiquer()
                );
            //POUR CONFIGURATION
            KNN= new Models.KNN();
            _distances = new ObservableCollection<string>()
            {
                "Euclidienne",
                "Manhattan"
            };
            OpenTrainCommand = new RelayCommand(
                o => true,
                o => OpenTrain()
                );
            OpenTestCommand = new RelayCommand(
                o => true,
                o => OpenTest()
                );
            EvaluerCommand = new RelayCommand(
                o => true,
                o => Evaluer()
                );
        }
        //POUR INFORMATION

        private void Modifier()
        {
            if (Medecin.IsValid())
            {
                RestApiQueries restApiQueries = new RestApiQueries();
                bool result = restApiQueries.EditInfo(Medecin, Token, "Home/Information");
                if (result)
                {
                    MessageBox.Show("Modifier avec succés", "Error");       
                }
                else
                {
                    MessageBox.Show("Erreur dans la modification", "Error");
                }
            }
            else
            {
                MessageBox.Show("Un champs est vide !","Error");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // POUR DIAGNOSTIQUE

        private void OpenAjoutPatient()
        {
            Patient.Nom = "";
            Patient.Prenom = "";
            Patient.Date = "";
            AjoutPatient ajoutPatient = new AjoutPatient(_login);
            ajoutPatient.DataContext = this;
            ajoutPatient.ShowDialog();
            //_window.Close();
        }

        private void QuitAjoutPatient()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != _window)
                {
                    window.Close();
                }
            }
        }
        private void AddPatient()
        {
            Patient.Genre = TextValue2;
            Patient.MID = Medecin.MedecinId;
            if (Patient.IsValid())
            {
                
                RestApiQueries restApiQueries = new RestApiQueries();
                Models.Patient out_patient = restApiQueries.AddPatient(Patient,Token, "Home/Patients");
                if (out_patient != null)
                {
                    
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window != _window)
                        {
                            window.Close();
                        }
                    }
                    Refresh();
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue lors de la création", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                MessageBox.Show("Une erreur est survenue lors de la création", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        private void Diagnostiquer()
        {
            if (SelectedDepString != null && SelectedThalString != null && SelectedThorString != null && SelectedVaisString != null && SelectedPatient.IsValid())
            {
                if (SelectedThorString == "Angine typique") { _selectedThor = 0; }
                else if (SelectedThorString == "Angine atypique") { _selectedThor = 1; }
                else if (SelectedThorString == "Douleur non angineuse") { _selectedThor = 2; }
                else if (SelectedThorString == "Asymptomatique") { _selectedThor = 3; }

                if (_selectedThalString == "Normale") { _selectedThal = 1; }
                else if (_selectedThalString == "Défaut corrigé") { _selectedThal = 2; }
                else if (_selectedThalString == "Défaut") { _selectedThal = 3; }

                _selectedDep = float.Parse(SelectedDepString);
                _selectedVais = float.Parse(SelectedVaisString);
                if (_selectedDepString.Length <= 3 && (_selectedDep >= 0 && _selectedDep <= 6.2) && (_selectedVais == 0 || _selectedVais == 1 || _selectedVais == 2 || _selectedVais == 3))
                {
                    if (KNN.k != null && KNN.distance != null)
                    {
                        Diagnostic diagnostic = new Diagnostic() { thal = _selectedThal, oldpeak = _selectedDep, cp = _selectedThor, ca = _selectedVais, k = ParametreK, distance = Distance, PID = SelectedPatient.PatientId };
                        RestApiQueries restApiQueries = new RestApiQueries();
                        Models.Diagnostic diagnosticResult = restApiQueries.Diagnose(diagnostic, Token, $"Home/Patient/{SelectedPatient.PatientId}/Diagnose");
                        if (diagnosticResult != null)
                        {
                            SelectedPatient.Diagnostic = diagnosticResult;
                            if (diagnosticResult.Label == true)
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
                        
                        else
                            MessageBox.Show("Une erreur est survenue", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);


                    }
                    else
                    {
                        MessageBox.Show("Veuillez faire une configuration du KNN avant", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else 
                    MessageBox.Show("Les données sont incorrectes", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
                MessageBox.Show("Veuillez saisir toutes les données", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            
        }
        private void InfoPatient()
        {
            if (SelectedPatient.IsValid())
            {
                InformationPatient informationPatient = new InformationPatient(SelectedPatient);
                informationPatient.ShowDialog();
            }
            else
                MessageBox.Show("Veuillez choisir un patient","Erreur",MessageBoxButton.OK,MessageBoxImage.Error);
            
        }
        //POUR CONFIGURATION

        private void OpenTrain()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if (dlg.ShowDialog()==true)
            {
                
                if (MessageBox.Show(dlg.FileName, "Fichier TRAIN Choisi ?", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    _trainSet = dlg.FileName;
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas choisi un fichier", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void OpenTest()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                if (MessageBox.Show(dlg.FileName,"Fichier TEST Choisi ?", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes) {
                    _testSet = dlg.FileName;
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas choisi un fichier", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void Evaluer()
        {
            if(_testSet != null && _trainSet != null)
            {
                KNN.Train(_trainSet, ParametreK, Distance);
                float taux = KNN.Evaluate(_testSet);
                _accuracy = taux;
                _accuracyString = "Taux de reconnaissance : " + _accuracy.ToString("0.00") + " %";
                AccuracyString = _accuracyString;
            }
            else
            {
                MessageBox.Show("Veuillez saisir toutes les données", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private Models.Medecin Information()
        {
            RestApiQueries restApiQueries = new RestApiQueries();
            Models.Medecin medecin = restApiQueries.GetInfo(Token, "Home/Information");
            return medecin;
        }
        private List<Models.Patient> Patients()
        {
            RestApiQueries restApiQueries = new RestApiQueries();
            List<Models.Patient> patients = restApiQueries.GetPatients(Token, "Home/Patients");
            return patients;
        }

        private void Refresh()
        {
            RestApiQueries restApiQueries = new RestApiQueries();
            List<Models.Patient> out_patients = restApiQueries.GetPatients(Token,"Home/Patients");

            if (out_patients != null)
            {
                PatientsView.Clear();

                foreach (Models.Patient patient in out_patients)
                {
                    _patients.Add(patient);
                }
            }
            else
            {
                MessageBox.Show("Une erreur est survenue lors de la récupération des conversions", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
