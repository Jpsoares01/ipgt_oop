using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen
{
    class TransactionScreenViewModel
    {
        internal Action<object, string> RequestErrorPopup;

        public Action<object, string> RequestSuccessPopup { get; internal set; }
    }
}
