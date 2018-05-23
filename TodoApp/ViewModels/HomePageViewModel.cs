using System.Collections.ObjectModel;
using Models.Classes;
using Prism.Navigation;
using TodoApp.ViewModels.Base;

namespace TodoApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private string _listTitle;

        public ObservableCollection<ToDoItem> ToDoList { get; set; }

        public string ListTitle
        {
            get => _listTitle;

            set
            {
                _listTitle = value;
                RaisePropertyChanged();
            }
        }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Title = "Home";
            ListTitle = "ToDo list";

            LoadData();
        }

        private void LoadData()
        {
            ToDoList = new ObservableCollection<ToDoItem>
            {
                new ToDoItem
                {
                    Id = "6bb8a868-dba1-4f1a-93b7-24ebce87e243",
                    Title = "Learn app development",
                    Description = "Attend Xamarin University",
                    ImageName = "https://alexdunndev.files.wordpress.com/2017/07/screen-shot-2017-07-31-at-11-57-35-am.png"
                },
                new ToDoItem
                {
                    Id = "b94afb54-a1cb-4313-8af3-b7511551b33b",
                    Title = "Develop apps",
                    Description = "Use Visual Studio",
                    ImageName = "https://dl2.macupdate.com/images/icons256/59553.png?d=1526018680"
                },
                new ToDoItem
                {
                    Id = "ecfa6f80-3671-4911-aabe-63cc442c1ecf",
                    Title = "Publish apps",
                    Description = "All app stores",
                    ImageName = "https://i-cdn.phonearena.com/images/article/101373-image/Google-Play-first-time-app-installs-surpassed-App-Stores-by-more-than-double-in-2017.jpg"
                }
            };
        }
    }
}
