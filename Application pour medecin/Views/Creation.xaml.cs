﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Creation.xaml
    /// </summary>
    public partial class Creation : Window
    {
        public Creation()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainViewModel(this);
        }

        private void PasswordRegisterBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).PasswordRegister = ((PasswordBox)sender).Password; }
        }
        private void PasswordConfirmBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).PasswordConfirm = ((PasswordBox)sender).Password; }
        }
    }
}
