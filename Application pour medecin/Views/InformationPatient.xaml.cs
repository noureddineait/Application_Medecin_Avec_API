using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Application_pour_medecin.Views
{
    /// <summary>
    /// Interaction logic for InformationPatient.xaml
    /// </summary>
    public partial class InformationPatient : Window
    {
        public InformationPatient(Models.Patient patient)
        {
            InitializeComponent();
            DataContext = new ViewModels.InformationViewModel(this, patient);
        }
    }
    
}
