using EventRegistrationAPP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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


        #region Get ALL Events
        public static async Task<List<EventsInfo>> GetLatestEventsInfo(string accessToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.ApiUrl + "Events/GetLatestEventsInfo");

            var events = JsonConvert.DeserializeObject<List<EventsInfo>>(json);

            return events;
        }
        #endregion


        #region GetCapacityByCapacityId
        public static async Task<Capacity> GetCapacityByCapacityId(string CapacityId,string accessToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.ApiUrl + "Capacity/GetCapacityByCapacityId/"+ CapacityId);
            dynamic resp = JsonConvert.DeserializeObject(json);
            //Capacity capacity = JsonConvert.DeserializeObject<Capacity>(json);
            Capacity capacity = resp.ToObject<Capacity>();
            return capacity;
        }
        #endregion

        #region GetCapacityByEventId
        public static async Task<List<Capacity>> GetCapacityByEventId(string EventId, string accessToken)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.ApiUrl + "Capacity/GetCapacityByEventId/"+ EventId);

            var capacities = JsonConvert.DeserializeObject<List<Capacity>>(json);

            return capacities;
        }
        #endregion

        #region Add Reservation Details
        public static async Task PostReservationAsync(Reservation reservation, string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(reservation);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(Constants.ApiUrl + "Reservation/PostReservation", content);
            
        }
        #endregion

    }
}
