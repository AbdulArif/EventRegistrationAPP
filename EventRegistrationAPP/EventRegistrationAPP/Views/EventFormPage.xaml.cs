using EventRegistrationAPP.Models;
using EventRegistrationAPP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventRegistrationAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventFormPage : ContentPage
    {
        //string capactyId = "ec9a555f-e3f2-4492-b6ea-327786f779ec";
        public EventFormPage(string id,string eventHours,int availableSeats, DateTime lDate)
        {
            InitializeComponent();
            string eventDate = Preferences.Get("eventDate", string.Empty);
            LblTime.Text = eventHours;
            LblDate.Text = eventDate;
            LblSeatsAvailable.Text = availableSeats.ToString();
        }

        private async void BtnSubmitSeats_Clicked(object sender, EventArgs e)
        {
            DateTime date = DateTime.UtcNow;
            var accessToken = Preferences.Get("accessToken", string.Empty);
            var capacityId = Preferences.Get("capacityId", string.Empty);

            var reservation = new Reservation
            {
                CapacityId = capacityId,
                Name = EntName.Text,
                PhoneNo = EntPhoneNumber.Text,
                Email = EntEmail.Text,
                SeatsBooked = Int32.Parse(EntSeatsBooked.Text),
                Comments = EntComments.Text,
                AddedBy = "User",
                AddedDate = date,
                UpdatedDate = date
            };
            await ApiService.PostReservationAsync(reservation, accessToken);
            await DisplayAlert("Success!", "Seats reserved successfully", "OK");
            await Navigation.PopModalAsync();
            Preferences.Clear();

        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}