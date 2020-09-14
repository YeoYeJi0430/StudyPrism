using Prism.Events;
using Prism.Mvvm;
using Prism1.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism1.ViewModels
{
    public class BViewModel : BindableBase
    {
        private string _message ;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public BViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<UpdateEvent>().Subscribe(Updated);
        }

        private void Updated(string obj)
        {
            Message = obj;
        }
    }
}
