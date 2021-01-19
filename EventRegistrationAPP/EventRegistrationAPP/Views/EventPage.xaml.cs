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
            //GetAllEvents();
        }

        //private async void GetAllEvents()
        //{
        //    var accessToken = Preferences.Get("accessToken", string.Empty);
        //    var events = await ApiService.GetLatestEventsInfo(accessToken);
        //    foreach (var donor in events)
        //    {
        //        EventsCollection.Add(donor);
        //    }
        //    EventsListView.ItemsSource = EventsCollection;
        //   // LblInstructions.Text = EventsCollection[0].EventDescription;
        //}

        private void EventsListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushModalAsync(new EventFormPage());
        }


        //private void BtnBook_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}