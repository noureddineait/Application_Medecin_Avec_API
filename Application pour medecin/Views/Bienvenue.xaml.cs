﻿using System;
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

namespace Application_pour_medecin
{
    /// <summary>
    /// Interaction logic for Bienvenue_Dr.xaml
    /// </summary>
    public partial class Bienvenue_Dr : Window
    {
        public Bienvenue_Dr(Models.LoginResponse login)
        {
            
            InitializeComponent();
            DataContext = new ViewModels.BienvenueViewModel(this,login);
            
        }

        
    }
}
