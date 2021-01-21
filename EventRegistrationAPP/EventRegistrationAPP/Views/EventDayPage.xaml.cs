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
    public partial class EventDayPage : ContentPage
    {
        //public static string eventId;
        public static ObservableCollection<Capacity> CapacityCollection;
        public EventDayPage()
        {
            InitializeComponent();
            CapacityCollection = new ObservableCollection<Capacity>();
            GetLatestEvent();
            //GetCapacityByEventId(eventId);
            this.BindingContext = this;
        }

        private async void GetLatestEvent()
        {
            var accessToken = Preferences.Get("accessToken", string.Empty);
            var eventsInfos = await ApiService.GetLatestEventsInfo(accessToken);
            string eventDate = string.Format("{0:D}", eventsInfos.EventDate);
            string eventId = eventsInfos.EventId;
            //Preferences.Set("eventId", eventId);
            Preferences.Set("eventDate", eventDate);
            LblEventDate.Text = eventDate;
            GetCapacityByEventId(eventId);
        }
        private async void GetCapacityByEventId(string eventId)
        {
            var accessToken = Preferences.Get("accessToken", string.Empty);
            //var eventID = Preferences.Get("eventId", string.Empty);
            var capacities = await ApiService.GetCapacityByEventId(eventId, accessToken);
            foreach (var capacity in capacities)
            {
                CapacityCollection.Add(capacity);
            }
            CapacitiesListView.ItemsSource = CapacityCollection;
        }
        private void BtnBookSeats_Clicked(object sender, EventArgs e)
        {
             //string capactyId = CapacityCollection   
            //Navigation.PushModalAsync(new EventFormPage(capacityId));
        }

        private void CapacitiesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var itm = (Models.Capacity)e.Item;
            string capacityId = itm.CapacityId;
            Preferences.Set("capacityId", capacityId);
            var id = Preferences.Get("capacityId", string.Empty);


            int availableSeats = itm.AvailableSeats;
            string eventHours = itm.EventHours;
            DateTime lDate = itm.AddedDate;


            Navigation.PushModalAsync(new EventFormPage(capacityId, eventHours, availableSeats, lDate));
        }
    }
}