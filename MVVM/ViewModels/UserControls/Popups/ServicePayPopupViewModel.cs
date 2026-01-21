using ipgt_oop.Core;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;
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

namespace ipgt_oop.MVVM.ViewModels.UserControls.Popups
{
    internal class ServicePayPopupViewModel : ObservableObject
    {

        private string _catName;

        public string CatName
        {
            get { return _catName; }
            set
            {
                _catName = value;
                OnPropertyChanged();
            }
        }

       


    }
}
