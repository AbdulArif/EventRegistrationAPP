using EventRegistrationAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EventRegistrationAPP.Services
{
    public static class ApiService
    {
        #region  Register User
        public static async Task<bool> RegisterUser(string email, string password, string ConfirmPassword)
        {
            var register = new Register()
            {
                Email = email,
                Password = password,
                ConfirmPassword = ConfirmPassword
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(register);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(Constants.ApiUrl + "api/Account/Register", content);
            var resultJson = response.Content.ReadAsStringAsync().Result; // Getting GuId
            dynamic resultObj = JsonConvert.DeserializeObject(resultJson);
            string userId = resultObj.UserId;
            Preferences.Set("userId", userId);
            if (!response.IsSuccessStatusCode)
                return false;
            else
                return true;
        }
        #endregion
    }
}
