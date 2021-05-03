using NbaScore.Model.Entities;
using Newtonsoft.Json;
using RestSharp;

namespace NbaScore.View.Services
{
    public static class ApiService
    {
        private static RestClient client;

        static ApiService()
        {
            client = new RestClient("https://www.balldontlie.io/api/v1/{command}");
        }

        public static Games GetGames()
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "games", ParameterType.UrlSegment);

            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Games>(response.Content);
            }
            return null;
        }

        public static Games GetGamesByDate(string startDate, string endDate)
        {
            RestRequest request = new RestRequest();
            request.Method = Method.GET;
            request.AddParameter("command", "games", ParameterType.UrlSegment);
            request.AddParameter("start_date", startDate);
            request.AddParameter("end_date", endDate);

            IRestResponse response = client.Execute(request);
            if(response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Games>(response.Content);
            }
            return null;
        }
    }
}
