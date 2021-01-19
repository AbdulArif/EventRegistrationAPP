using EventRegistrationAPP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventRegistrationAPP
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new EventDayPage());
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
