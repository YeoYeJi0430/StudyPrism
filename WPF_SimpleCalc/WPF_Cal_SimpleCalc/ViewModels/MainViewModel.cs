using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Cal_SimpleCalc.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        string result;
        public string Result
        {
            get => result;
            set
            {
                result = value;
                NotifyOfPropertyChange(() => Result);
                NotifyOfPropertyChange(() => Num);
                NotifyOfPropertyChange(() => CanChangeNum);
            }
        }
        string num;
        public string Num
        {
            get => num;
            set
            {
                num = value;
                NotifyOfPropertyChange(() => Num);
                NotifyOfPropertyChange(() => Result);
                NotifyOfPropertyChange(() => CanChangeNum);
            }
        }
        
        public void ChangeNum()
        {
            Result = Num;
        }

        public bool CanChangeNum
        {
            get => (string.IsNullOrEmpty(Result));
        }

    }
}
