using Prism.Mvvm;

namespace TodoApp.ViewModels.Base
{
    public class ViewModelBase : BindableBase
    {
        private string _title;

        public string Title
        {
            get => _title;

            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }
    }
}