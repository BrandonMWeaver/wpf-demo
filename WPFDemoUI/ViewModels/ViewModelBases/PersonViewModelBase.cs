using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemoUI.ViewModels.ViewModelBases
{
    class PersonViewModelBase : NotificationBase
    {
        private string _dataString;

        public string DataString
        {
            get { return this._dataString; }
            set
            {
                this._dataString = value;
                this.OnPropertyChanged(nameof(this.DataString));
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set
            {
                this._errorMessage = value;
                this.OnPropertyChanged(nameof(this.ErrorMessage));
            }
        }
    }
}
