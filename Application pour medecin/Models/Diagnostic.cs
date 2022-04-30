using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application_pour_medecin.Models
{
    internal interface IDiagnostic
    {
        //float[] Features { get; }
        bool? Label { get; }
        void PrintInfo();
    }
    public class Diagnostic : IDiagnostic , INotifyPropertyChanged
    {
        
        [Ignore]
        public int DiagnosticID { get; set; }

        [Name("cp")]
        

        public float cp { get; set; }
  
        [Name("ca")]
        

        public float ca { get; set; }
        [Name("oldpeak")]
       

        public float oldpeak { get; set; }
        [Name("thal")]
        

        public float thal { get; set; }
        [Name("target")]

        public int target { get; set; }
        //private float[] _features = new float[5] { 0, 0, 0, 0, 0 };
        [Ignore]
        public int PID { get; set; }

        [Ignore]
        public int k { get; set; }
        [Ignore]
        public int distance { get; set; }

        //public float[] Features { get; }

        public bool? Label { get; set; }
        public void PrintInfo()
        {
            Console.WriteLine($"{thal} + {target}");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
