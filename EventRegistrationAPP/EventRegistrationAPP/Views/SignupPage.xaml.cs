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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            if (!EntPassword.Text.Equals(EntConfirmPassword.Text))
            {
                await DisplayAlert("Password mismatch", "Password and confirm password is not match", "Cancel");
            }
            else
            {

                var response = await ApiService.RegisterUser(EntEmail.Text, EntPassword.Text, EntConfirmPassword.Text);
                if (response)
                {
                    await DisplayAlert("HI", "Your account has been created ", "OK");
                    var userId = Preferences.Get("userId", string.Empty);
                    // Preferences.Set("role", role);                    
                    //await Navigation.PushModalAsync(new UpdateDonorPage(userId));
                }
                else
                {
                    await DisplayAlert("Oops!", "User already registered ", "Cancel");
                }
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new LoginPage());
        }
    }
}