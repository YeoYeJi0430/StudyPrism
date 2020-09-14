using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Prism_SimpleCalc.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region Val
        #endregion

        #region Property
        private string _calcTitle = "계산기";
        public string CalcTitle
        {
            get => _calcTitle;
            set
            {
                SetProperty(ref _calcTitle, value);
            }
        }

        private string _calcText;
        public string CalcText
        {
            get => _calcText;
            set
            {
                SetProperty(ref _calcText, value);
            }
        }

        #endregion

        public MainViewModel()
        {
        }

        #region Command
        //private DelegateCommand num7Command;
        //public DelegateCommand Num7Command
        //{
        //    get
        //    {
        //        if (num7Command == null)
        //        {
        //            num7Command = new DelegateCommand(() => Num7Add());
        //        }
        //        return num7Command;
        //    }
        //}

        //private DelegateCommand num4Command;
        //public DelegateCommand Num4Command
        //{
        //    get
        //    {
        //        if (num4Command == null)
        //        {
        //            num4Command = new DelegateCommand(() => Num4Add());
        //        }
        //        return num4Command;
        //    }
        //}

        private DelegateCommand<string> addNumberCommand;
        public DelegateCommand<string> AddNumberCommand
        {
            get
            {
                if (addNumberCommand == null) 
                {
                    addNumberCommand = new DelegateCommand<string>(AddNumber);
                }
                return addNumberCommand;
            }
        }

        

        #endregion

        #region Method
        //private void Num7Add()
        //{
        //    CalcText += "7";
        //}

        //private void Num4Add()
        //{
        //    CalcText += "4";
        //}

        private void AddNumber(string buttonVal)
        {
            CalcText += buttonVal.ToString();
        }
        #endregion

    }
}
