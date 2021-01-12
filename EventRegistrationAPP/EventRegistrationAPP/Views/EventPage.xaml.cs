using EventRegistrationAPP.Models;
using EventRegistrationAPP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventRegistrationAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventPage : ContentPage
    {
        public static ObservableCollection<EventsInfo> EventsCollection;
        public EventPage()
        {
            InitializeComponent();
            EventsCollection = new ObservableCollection<EventsInfo>();
            GetAllEvents();
        }

        private async void GetAllEvents()
        {
            var accessToken = Preferences.Get("accessToken", string.Empty);
            var donors = await ApiService.GetAllEvents(accessToken);
            foreach (var donor in donors)
            {
                EventsCollection.Add(donor);
            }
            DonorListView.ItemsSource = EventsCollection;
        }


        //private void BtnBook_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}