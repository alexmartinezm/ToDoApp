﻿using Prism.Navigation;

namespace TodoApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Title = "Home";
        }
    }
}