using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism1.Events;
using System;

namespace Prism1.ViewModels
{
    public class AViewModel : BindableBase
    {
        //private string _firstName;
        //public string FirstName
        //{
        //    get { return _firstName; }
        //    set 
        //    {
        //        _firstName = value;
        //        OnPropertyChanged();
        //    }
        //}
        //public event PropertyChangedEventHandler PropertyChanged;
        //void OnPropertyChanged([CallerMemberName] string propertyName="")
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        private readonly IEventAggregator _eventAggregator;

        private string _firstName = "YeoYeji";
        public string FirstName
        {
            get => _firstName;
            set
            {
                SetProperty(ref _firstName, value);
            }
        }

        private string _lastName;
        public string LastName
        {
            //get { return _lastName; }
            //set { SetProperty(ref _lastName, value); }
            get => _lastName;
            set
            {
                SetProperty(ref _lastName, value);
            }
        }

        private DateTime? _lastUpdated;
        public DateTime? LastUpdated
        {
            get => _lastUpdated;
            set
            {
                SetProperty(ref _lastUpdated, value);
            }
        }

        public DelegateCommand UpdateCommand { get; set; }


        public AViewModel(IEventAggregator eventAggregator)
        {
            //UpdateCommand = new MyCommand(this);
            //FirstName = "Jebal2???";

            _eventAggregator = eventAggregator;
            UpdateCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => FirstName).ObservesProperty(() => LastName);
        }

        private bool CanExecute()
        {
            //공백이 아니면 업데이트버튼 활성화
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName);
        }

        private void Execute()
        {
            //업데이트버튼 활성화 후 동작
            LastUpdated = DateTime.Now;

            _eventAggregator.GetEvent<UpdateEvent>().Publish(LastUpdated.ToString());
        }


        ////DataContext = new AViewModel();
        //static class ViewModelLocator
        //{
        //    static AViewModel AviewModel { get; set; }
        //}
        //누겟
    }

    //class MyCommand : ICommand
    //{
    //    public MyCommand(AViewModel vm)
    //    {

    //    }
    //    public event EventHandler CanExecuteChanged;

    //    public bool CanExecute(object parameter)
    //    {
    //        return true;
    //    }

    //    public void Execute(object parameter)
    //    {

    //    }
    //}
}
